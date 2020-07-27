using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Common.Logger
{
    /// <summary>
    /// 1) Применяет конфиг к логгеру.
    /// 2) Создаёт логгеры для разных классов.
    /// 3) Принимает сообщения от логгеров и хранит их.
    /// 4) Печатает сообщения в файл.
    /// </summary>
    public class LogManager
    {
        private static readonly Lazy<LogManager> Lazy = new Lazy<LogManager>(() => new LogManager());
        
        private static readonly object LockObj = new object();
        private readonly List<string> logs = new List<string>();
        
        private LoggerConfig config;
        private LogPrinter logPrinter;
        private int maxPrintingPeriodMs;

        private LogManager()
        {
        }

        public static bool TrySetConfig(LoggerConfig loggerConfig)
        {
            return Lazy.Value.TrySetConfiguration(loggerConfig);
        }

        private void LogFromUnity(string condition, string stacktrace, LogType type)
        {
            if (!logs.Contains(condition))
            {
                string logType;
                if (type == LogType.Exception)
                {
                    logType = LogType.Error.ToString();
                }
                else
                {
                    logType = type.ToString();
                }
                
                AddLog($"UNITY LOG {logType} {nameof(condition)} {condition} {nameof(stacktrace)} {stacktrace}");
            }
            
        }

        public static ILog CreateLogger(Type type)
        {
            return new Logger(Lazy.Value, type);
        }

        public void AddLog(string message)
        {
            lock (LockObj)
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
            Lazy.Value.PrintAll();
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
            
            Application.logMessageReceivedThreaded += Lazy.Value.LogFromUnity;
            AddLog(loggerConfig.ToString());
            lock (LockObj)
            {
                config = loggerConfig;
                logPrinter = new LogPrinter(loggerConfig.PersistentDataPath);
                maxPrintingPeriodMs = loggerConfig.MaxPrintingPeriodMs;
            }
            ThreadPool.QueueUserWorkItem(ThreadWork);
            return true;
        }
        
        /// <summary>
        /// Бесконечно дописывает логи в файл.
        /// </summary>
        /// <param name="state"></param>
        private async void ThreadWork(object state)
        {
            try
            {
                while (true)
                {
                    await Task.Delay(maxPrintingPeriodMs);
                    string[] logsCopy = new string[logs.Count];
                    lock (LockObj)
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
            lock (LockObj)
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