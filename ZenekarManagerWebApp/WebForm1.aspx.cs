using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DaO Database = new DaO();
            User teszt = new User();
            

            teszt.Users_email = "gorogbence@gmail.com";
            teszt.Users_nev = "Görög G. Bence";
            teszt.Users_password = "titkositatlan jelszo";
            teszt.Aktiv = true;
            teszt.Koncertre_jar = true;
            teszt.Jogkor_id = 2;

            tesztLabel.Text = teszt.Users_nev + " " + teszt.Users_email + " " + teszt.Users_password + " " + teszt.Aktiv + " " +
                teszt.Koncertre_jar + " " + teszt.Jogkor_id;

            teszt.createProfile();
        }
    }
}