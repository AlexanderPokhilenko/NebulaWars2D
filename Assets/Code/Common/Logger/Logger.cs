using System;

namespace Code.Common
{
    /// <summary>
    /// Все методы могут вызываться из разных потоков
    /// </summary>
    public class Logger :ILog
    {
        private readonly string typeName;
        private readonly LogManager logManager;

        public Logger(LogManager logManager, Type type)
        {
            this.logManager = logManager;
            typeName = " "+type.FullName+" ";
        }
        
        public void Debug(string message)
        {
            const string levelName = " "+nameof(Debug)+" ";
            string log = DateTime.Now.ToLongTimeString() + levelName + typeName + message;
            logManager.AddLog(log);
            UnityThread.Execute(()=>UnityEngine.Debug.LogWarning(log));
        }

        public void Debug(object message)
        {
            Debug(message.ToString());
        }

        public void Info(string message)
        {
            const string levelName = " "+nameof(Info)+" ";
            string log = DateTime.Now.ToLongTimeString() + levelName + typeName + message;
            logManager.AddLog(log);
            UnityThread.Execute(()=>UnityEngine.Debug.Log(log));
        }

        public void Info(object message)
        {
            Info(message.ToString());
        }

        public void Warn(string message)
        {
            const string levelName = " "+nameof(Warn)+" ";
            string log = DateTime.Now.ToLongTimeString() + levelName + typeName + message;
            logManager.AddLog(log);
            UnityThread.Execute(()=>UnityEngine.Debug.LogWarning(log));
        }

        public void Warn(object message)
        {
            Warn(message.ToString());
        }

        public void Error(string message)
        {
            const string levelName = " "+nameof(Error)+" ";
            string log = DateTime.Now.ToLongTimeString() + levelName + typeName + message;
            logManager.AddLog(log);
            UnityThread.Execute(()=>UnityEngine.Debug.LogError(log));
        }

        public void Error(object message)
        {
            Error(message.ToString());
        }

        public void Fatal(string message)
        {
            const string levelName = " "+nameof(Fatal)+" ";
            string log = DateTime.Now.ToLongTimeString() + levelName + typeName + message;
            logManager.AddLog(log);
            UnityThread.Execute(()=>UnityEngine.Debug.LogError(log));
        }

        public void Fatal(object message)
        {
            Fatal(message.ToString());
        }

        public void Print()
        {
            LogManager.Print();
        }
    }
}