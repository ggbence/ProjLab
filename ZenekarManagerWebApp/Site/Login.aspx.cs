using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;

namespace ZenekarManagerWebApp.Site
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleConnect.ClientId = "528370555612-2ijorp2unl8l5ugpvu6gmhe24fpuims2.apps.googleusercontent.com";
            GoogleConnect.ClientSecret = "oTf69TWDSvC6_L0DfgFvQgJO";
            GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];

            var ctx = Request.GetOwinContext();
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string code = Request.QueryString["code"];
                string json = GoogleConnect.Fetch("me", code);
                GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
                Manager mng = new Manager();
                foreach (var usr in mng.getUserList())
                {
                    foreach (var email in profile.Emails)
                    {
                        if (usr.Users_email == email.Value)
                        {
                            var claims = new List<Claim>();
                            claims.Add(new Claim(ClaimTypes.Name, usr.Users_nev));
                            claims.Add(new Claim(ClaimTypes.Email, usr.Users_email));
                            claims.Add(new Claim(ClaimTypes.Role, usr.Jogkor_id.ToString()));
                            var id = new ClaimsIdentity(claims,
                                                        DefaultAuthenticationTypes.ApplicationCookie);

                            var authenticationManager = ctx.Authentication;
                            authenticationManager.SignIn(id);
                            Response.Redirect("~/Site/Index");
                        }
                    }
                }
            }
            /*EmailBox.Text = "gorogbence@gmail.com";
            PasswordBox.Text = "WbsNA51M";*/
            var currUser = ctx.Authentication.User;
            IEnumerable<Claim> claims2 = currUser.Claims;
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Site/Index");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DaO Database = new DaO();
            //User teszt = new User();


            var ctx = Request.GetOwinContext();

            Guest guest = new Guest();
            guest.Email = EmailBox.Text;
            guest.Password = PasswordBox.Text;
            User user = guest.signIn();
            if (user == null)
            {
                tesztLabel.Text += " Guest bejelentkezes sikertelen <br>";
            }
            else
            {
                tesztLabel.Text += " Guest bejelentkezett <br>";
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Users_nev));
                claims.Add(new Claim(ClaimTypes.Email, user.Users_email));
                claims.Add(new Claim(ClaimTypes.Role, user.Jogkor_id.ToString()));
                var id = new ClaimsIdentity(claims,
                                            DefaultAuthenticationTypes.ApplicationCookie);

                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(id);
                Response.Redirect("~/Site/Index");
            }

        }

        protected void GoogleLoginButton_Click(object sender, EventArgs e)
        {
            GoogleConnect.Authorize("profile", "email");
        }
        
        
    }
}