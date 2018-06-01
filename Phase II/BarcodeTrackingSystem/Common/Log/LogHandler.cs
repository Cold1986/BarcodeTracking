using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.IO;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Maticsoft.Common
{
    [Serializable]
    public class LogHandler
    {
        public static readonly ILog _loginfo = LogManager.GetLogger("loginfo");

        public static readonly ILog _logerror = LogManager.GetLogger("logerror");

        private static bool _isConfigured = false;

        public static ILog GetLogger(Type type)
        {
            return GetLogger(string.Empty, type);
        }



        public static ILog GetLogger(string path, Type type)
        {
            if (!_isConfigured)
            {
                if (!string.IsNullOrEmpty(path))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    if (fileInfo.Exists)
                    {
                        XmlConfigurator.Configure(fileInfo);
                    }
                    else
                    {
                        XmlConfigurator.Configure();
                    }
                }
                else
                {
                    XmlConfigurator.Configure();
                }

                _isConfigured = true;
            }

            return LogManager.GetLogger(type);
        }

        public static ILog GetLogger(string name)
        {
            if (!_isConfigured)
            {
                XmlConfigurator.Configure();

                _isConfigured = true;
            }

            return LogManager.GetLogger(name);
        }

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public static void WriteLog(string info)
        {
            if (_loginfo.IsInfoEnabled)
            {
                _loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception se)
        {
            if (_logerror.IsErrorEnabled)
            {
                _logerror.Error(info, se);
            }
        }
    }
}