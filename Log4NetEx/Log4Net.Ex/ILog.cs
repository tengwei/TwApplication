

using System;

namespace Log4Net.Ex
{
	
	public interface ILog
	{
        void Debug(Log4NetMessageModel message, Exception exception=null);
        void Info(Log4NetMessageModel message, Exception exception=null);
        void Warn(Log4NetMessageModel message, Exception exception=null);
        void Error(Log4NetMessageModel message, Exception exception=null);
        void Fatal(Log4NetMessageModel message, Exception exception=null);
	}
}
