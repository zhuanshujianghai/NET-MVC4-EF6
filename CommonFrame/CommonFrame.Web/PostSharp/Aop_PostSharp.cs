using log4net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrame.Web
{
    [Serializable]
    public class Aop_PostSharp : OnMethodBoundaryAspect
    {
        private static readonly log4net.ILog _logger;

        private string _methodName;
        
        private int _hashCode;

        static Aop_PostSharp()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                _logger =
                    log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
        }

        
        public Aop_PostSharp()
        {
            // Do nothing
        }

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            _methodName = "【类名："+method.DeclaringType.Name + "/方法名：" + method.Name+"】";
        }
        
        public override void RuntimeInitialize(MethodBase method)
        {
            _hashCode = this.GetHashCode();
        }

        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="args"></param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            //_logger.InfoFormat(">>> Entry [{0}] {1}", _hashCode, _methodName);
        }

        /// <summary>
        /// 正常结束时
        /// </summary>
        /// <param name="args"></param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            //_logger.InfoFormat(">>> Success [{0}] {1}", _hashCode, _methodName);
        }

        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {
            //_logger.InfoFormat("<<< Exit [{0}] {1}", _hashCode, _methodName);
        }

        /// <summary>
        /// 抛出异常时,记录程序无法处理的异常信息
        /// 已经try catch处理过的，不进入该流程
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {
            string expMsg = string.Format("!!! Exception [{0}] {1} {2}", _hashCode, _methodName, args.Exception.ToString());
            _logger.ErrorFormat(expMsg, args.Exception);
            //重定向到指定的错误页面
            string errorurl = "/Error/Index";
            System.Web.HttpContext.Current.Response.Redirect(errorurl);
        }
    }
}
