using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Common.Logger
{
    public class LogManager
    {
        private static readonly Lazy<LogManager> lazy = new Lazy<LogManager>(() => new LogManager());
        
        private static readonly object lockObj = new object();
        private readonly List<string> logs = new List<string>();
        
        private LoggerConfig config;
        private LogPrinter logPrinter;
        private int maxPrintingPeriodMs;

        private LogManager()
        {
        }

        public static bool TrySetConfig(LoggerConfig loggerConfig)
        {
            return lazy.Value.TrySetConfiguration(loggerConfig);
        }

        public static ILog CreateLogger(Type type)
        {
            return new Logger(lazy.Value, type);
        }

        public void AddLog(string message)
        {
            lock (lockObj)
            {
                logs.Add(message);
                if (logPrinter != null && config.MaxNumberOfRecordsToPrint <= logs.Count)
                {
                    Print(logs);
                    logs.Clear();
                }
            }
        }

        public static void Print()
        {
            lazy.Value.PrintAll();
        }

        private void PrintAll()
        {
            Print(logs);
        }
        
        private bool TrySetConfiguration(LoggerConfig loggerConfig)
        {
            if (config != null)
            {
                return false;
            }
            
            AddLog(loggerConfig.ToString());
            lock (lockObj)
            {
                config = loggerConfig;
                logPrinter = new LogPrinter(loggerConfig.PersistentDataPath);
                maxPrintingPeriodMs = loggerConfig.MaxPrintingPeriodMs;
            }
            ThreadPool.QueueUserWorkItem(ThreadWork);
            return true;
        }
        
        private async void ThreadWork(object state)
        {
            try
            {
                while (true)
                {
                    await Task.Delay(maxPrintingPeriodMs);
                    string[] logsCopy = new string[logs.Count];
                    lock (lockObj)
                    {
                        if (logs.Count > 0)
                        {
                            logs.CopyTo(logsCopy);
                            logs.Clear();
                        }
                    }
                    Print(logsCopy);
                }
            }
            catch (Exception e)
            {
                UnityThread.Execute(()=>
                {
                    Debug.LogError("Было брошено исключение в логгере " + e.Message);
                });
            }
            
            // ReSharper disable once FunctionNeverReturns
        }
        
        private void Print(List<string> messages)
        {
            lock (lockObj)
            {
                if (messages.Count == 0)
                {
                    return;
                }
                logPrinter.Print(messages);
            }
        }
        
        private void Print(string[] messages)
        {
            if (messages.Length == 0)
            {
                return;
            }
            
            logPrinter.Print(messages);
        }
    }
}