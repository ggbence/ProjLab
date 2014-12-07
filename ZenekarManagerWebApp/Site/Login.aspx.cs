using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Site
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*EmailBox.Text = "gorogbence@gmail.com";
            PasswordBox.Text = "WbsNA51M";*/
            var ctx = Request.GetOwinContext();
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

            //if (guest.checkEmail()) 
            //{
            //    tesztLabel.Text += "Letezik az email cim ";
            //}
            //else
            //{
            //    tesztLabel.Text += "nem letezik ";
            //}



            User user = guest.signIn();
            if (user == null)
            {
                tesztLabel.Text += " Guest bejelentkezes sikertelen <br>";
                /*
                user = guest.signUp(guest.Email, nev, guest.Password);
                if (user == null)
                {
                    tesztLabel.Text += " Guest regisztracio sikertelen <br>";
                }
                else
                {
                    tesztLabel.Text += " Guest regisztralt <br>";

                    if (!guest.checkUser())
                    {
                        tesztLabel.Text += " Guest adatok nem leteznek <br>";
                    }
                    else
                    {
                        tesztLabel.Text += " Guest adatok megtalalhatok <br>";
                        tesztLabel.Text += " User password: " + user.Users_password + " <br>";

                        tesztLabel.Text += " Guest megvaltoztatott jelszo: " + guest.newPass() + " <br>";

                    }

                }*/



            }
            else
            {
                tesztLabel.Text += " Guest bejelentkezett <br>";
                /*var message = new Message();
                message.addRecipient(21);
                message.Kuldo = 21;
                message.Datum = "2014-11-24 23:49:00";
                message.Ervenyesseg = "2015-11-24 23:49:00";
                message.Uzenet = "Az alvás jó.";

                if (user.sendMessage(message))
                {
                    tesztLabel.Text += " üzenet elküldve <br>";
                    message = user.readMessage(3);
                    tesztLabel.Text += message.Uzenet + " <br>";
                }
                else
                {
                    tesztLabel.Text += " nem sikerült elküldeni az üzenetet <br>";
                }*/
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


            /* 
                        teszt.Users_email = "gorogbence@gmail.com";
                        //teszt.Users_nev = "Görög G. Bence";
                        //teszt.Users_password = "titkositatlan jelszo";
                        //teszt.Aktiv = 1;
                        //teszt.Koncertre_jar = 1;
                        //teszt.Jogkor_id = 2;

                        //tesztLabel.Text = teszt.Users_nev + " " + teszt.Users_email + " " + teszt.Users_password + " " + teszt.Aktiv + " " +
                        //    teszt.Koncertre_jar + " " + teszt.Jogkor_id;

                        //teszt.createProfile();
                        //tesztLabel.Text += " beirt adatok: " + teszt.Users_nev + " " + teszt.Users_email + " " + teszt.Users_password + " " + teszt.Aktiv + " " +
                        //    teszt.Koncertre_jar + " " + teszt.Jogkor_id + " id: " + teszt.Users_id;

                        teszt.readProfile(teszt.Users_email);
                        tesztLabel.Text += " olvasott adatok: " + teszt.Users_nev + " " + teszt.Users_email + " " + teszt.Users_password + " " + teszt.Aktiv + " " +
                            teszt.Koncertre_jar + " " + teszt.Jogkor_id + " id: " + teszt.Users_id;

                        teszt.Users_nev = "Görög Bence";
                        if (teszt.profileModify())
                        {
                            tesztLabel.Text += " modositott";
                        }
                        else
                        {
                            tesztLabel.Text += " siekrtelen";
                        }
            */
        }
        
        
    }
}