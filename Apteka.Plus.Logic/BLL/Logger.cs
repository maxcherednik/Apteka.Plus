using System;
using System.Collections.Generic;
using System.Text;
using log4net;


namespace Apteka.Plus.Logic.BLL
{
    public class Logger:ILog 
    {
        private readonly ILog log;

        public Logger(string name)
        {
            log = LogManager.GetLogger(name);
            if (Common.User != null)
            {
                log4net.GlobalContext.Properties["UserID"] = Common.User.Login;
            }
        }

        #region ILog Members

        public void Debug(object message, Exception exception)
        {
            if (log.IsDebugEnabled)
                log.Debug(message, exception);
        }

        public void Debug(object message)
        {
            if (log.IsDebugEnabled)
                log.Debug(message);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log.IsDebugEnabled)
                log.DebugFormat(provider, format, args);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log.IsDebugEnabled)
                log.DebugFormat(format, arg0,  arg1,  arg2);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            if (log.IsDebugEnabled)
                log.DebugFormat(format, arg0, arg1);
        }

        public void DebugFormat(string format, object arg0)
        {
            if (log.IsDebugEnabled)
                log.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (log.IsDebugEnabled)
                log.DebugFormat(format, args);
        }

        public void Error(object message, Exception exception)
        {
            if (log.IsErrorEnabled)
                log.Error(message,exception);
        }

        public void Error(object message)
        {
            if (log.IsErrorEnabled)
                log.Error(message);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log.IsErrorEnabled)
                log.ErrorFormat(provider, format, args);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log.IsErrorEnabled)
                log.ErrorFormat(format, arg0, arg1, arg2);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            if(log.IsErrorEnabled)
                log.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0)
        {
            if (log.IsErrorEnabled)
                log.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (log.IsErrorEnabled)
                log.ErrorFormat(format, args);
        }

        public void Fatal(object message, Exception exception)
        {
            if (log.IsFatalEnabled)
                log.Fatal(message,exception);
        }

        public void Fatal(object message)
        {
            if (log.IsFatalEnabled)
                log.Fatal(message);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log.IsFatalEnabled)
                log.FatalFormat(provider, format, args);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log.IsFatalEnabled)
                log.FatalFormat(format, arg0, arg1, arg2);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            if (log.IsFatalEnabled)
                log.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0)
        {
            if (log.IsFatalEnabled)
                log.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (log.IsFatalEnabled)
                log.FatalFormat(format, args);
        }

        public void Info(object message, Exception exception)
        {
            if (log.IsInfoEnabled)
                log.Info(message,exception);
        }

        public void Info(object message)
        {
            if (log.IsInfoEnabled)
                log.Info(message);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log.IsInfoEnabled)
                log.InfoFormat(provider, format, args);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log.IsInfoEnabled)
                log.InfoFormat(format, arg0, arg1, arg2);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            if (log.IsInfoEnabled)
                log.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0)
        {
            if (log.IsInfoEnabled)
                log.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (log.IsInfoEnabled)
                log.InfoFormat(format, args);
        }
        

        public void Warn(object message, Exception exception)
        {
            if (log.IsWarnEnabled)
                log.Warn(message,exception);
        }

        public void Warn(object message)
        {
            if (log.IsWarnEnabled)
                log.Warn(message);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (log.IsWarnEnabled)
                log.WarnFormat(provider, format, args);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            if (log.IsWarnEnabled)
                log.WarnFormat(format, arg0, arg1, arg2);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            if (log.IsWarnEnabled)
                log.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0)
        {
            if (log.IsWarnEnabled)
                log.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (log.IsWarnEnabled)
                log.WarnFormat(format, args);
        }

        #endregion



        #region ILog Members


        public bool IsDebugEnabled
        {
            get { return log.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return log.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return log.IsWarnEnabled; }
        }

        #endregion

        #region ILoggerWrapper Members

        log4net.Core.ILogger log4net.Core.ILoggerWrapper.Logger
        {
            get { return log.Logger; }
        }

        #endregion
    }
}
