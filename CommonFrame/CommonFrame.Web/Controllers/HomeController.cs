using CommonFrame.IService;
using CommonFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonFrame.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        public IService_Common_Members Iservice_common_members { get; set; }
        // GET: Index
        [Aop_PostSharp]
        public ActionResult Index()
        {
            string numstr = "";
            try
            {
                int num = Convert.ToInt32(numstr);
            }
            catch (Exception)
            {
                throw;
            }
            var member = Iservice_common_members.Query(a => a.Id > 0);
            ViewBag.Id = member.Id;
            ViewBag.UserName = member.UserName;
            return View();
        }
    }
}