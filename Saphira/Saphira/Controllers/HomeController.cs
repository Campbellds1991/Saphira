using Saphira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Saphira.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (Session["UserID"] != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Login");
			}			
		}
		public ActionResult Login()
		{
			SaphiraDB db = new SaphiraDB();
			return View(db.Accounts);
		}
		public ActionResult Login(Account objUser)
		{
			if (ModelState.IsValid)
			{
				using (SaphiraDB db = new SaphiraDB())
				{
					var obj = db.Accounts.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
					if (obj != null)
					{
						Session["UserID"] = obj.ID.ToString();
						Session["UserName"] = obj.UserName.ToString();
						return RedirectToAction("UserDashBoard");
					}
				}
			}
			return View(objUser);
		}
				

	}
}