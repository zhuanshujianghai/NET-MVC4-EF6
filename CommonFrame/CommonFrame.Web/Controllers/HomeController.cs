using CommonFrame.IService;
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
        public ActionResult Index()
        {
            var member = Iservice_common_members.Query(a => a.Id > 0);
            ViewBag.Id = member.Id;
            ViewBag.UserName = member.UserName;
            return View();
        }
    }
}