using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            var guest = new Guest();
            
            if (guest.signUp(EmailTextBox.Text, NameTextBox.Text, PwTextBox.Text) != null)
            {
                SuccessfulLabel.Text = "A regisztráció sikeres!";
            }
            else
            {
                SuccessfulLabel.Text = "A regisztráció sikertelen!";
            }
        }
    }
}