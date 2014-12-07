using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Site
{
    public struct UserOut
    {
        public string name { get; set; }
        public string email { get; set; }
        public string jogkör { get; set; }
        public string hangszerek { get; set; }
    }
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
            var ctx = Request.GetOwinContext();
            var currUser = ctx.Authentication.User;
            IEnumerable<Claim> claims2 = currUser.Claims;
            int role = 0;
            foreach (var claim in claims2)
            {
                if (claim.Type == ClaimTypes.Role)
                {
                    role = Convert.ToInt32(claim.Value);
                }
            }
            if (role == Guest.REGISZTRALT)
            {
                Response.Redirect("~/Site/Profile");
            }
            else if (role == Guest.ZENÉSZ)
            {
                Response.Redirect("~/Site/Index");
            }
        }


        public List<UserOut> getUsers()
        {
            List<UserOut> ret = new List<UserOut>();
            Manager me = new Manager();
            foreach (var user in me.getUserList())
            {
                UserOut usr = new UserOut();
                usr.name = user.Users_nev;
                usr.email = user.Users_email;
                switch (user.Jogkor_id)
                {
                    case Guest.REGISZTRALT:
                        usr.jogkör = "regisztrált";
                        break;
                    case Guest.ZENÉSZ:
                        usr.jogkör = "zenész";
                        break;
                    case Guest.MANAGER:
                        usr.jogkör = "manager";
                        break;
                    default:
                        break;
                }
                usr.hangszerek = "";
                user.readProfile(user.Users_email);
                if (user.Hangszerek != null)
                foreach (var hangszer in user.Hangszerek)
                {
                    usr.hangszerek += hangszer.Value + ", ";
                }
                if (usr.hangszerek != "")
                {
                    usr.hangszerek = usr.hangszerek.Remove(usr.hangszerek.Length - 2);
                }
                ret.Add(usr);
            }
            return ret;
        }


        protected void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/Profile?email=" + ListView2.SelectedDataKey.Value.ToString());
        }



    }
}