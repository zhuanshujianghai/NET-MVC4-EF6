using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CommonFrame.Web.lognet
{
    public class Log
    {
        public static void WriteFatal(Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Fatal("严重错误", ex);
        }

        /// <summary>
        /// 输出异常信息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="e"></param>
        public static void WriteLog(Type t, Exception e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Error("Error", e);
        }

        /// <summary>
        /// 输出普通错误信息
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteLog(Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Error("Error", ex);
        }

        /// <summary>
        /// 输出DEBUG信息
        /// </summary>
        /// <param name="text"></param>
        public static void WriteDebug(object text)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Debug信息");
            log.Debug(text);
        }

        /// <summary>
        /// 输出程序运行信息
        /// </summary>
        /// <param name="text"></param>
        public static void WriteInfo(string text)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("程序运行信息");
            log.Info(text);
        }
    }
}