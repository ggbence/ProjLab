using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        private User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login");
                }
                var ctx = Request.GetOwinContext();
                var currUser = ctx.Authentication.User;
                IEnumerable<Claim> claims2 = currUser.Claims;
                string email = "";
                foreach (var claim in claims2)
                {
                    if (claim.Type == ClaimTypes.Email)
                    {
                        email = claim.Value;
                        EmailTextBox.Text = email;
                    }
                    else if (claim.Type == ClaimTypes.Name)
                    {
                        NameTextBox.Text = claim.Value;
                    }
                }
                user.readProfile(email);
                if (!IsPostBack)
                {
                    ListBox1.ClearSelection();
                }
                foreach (var j in user.Hangszerek)
                {
                    ListBox1.Items.FindByValue(j.Key.ToString()).Selected = true;
                }
            
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            user.Users_email = EmailTextBox.Text;
            user.Users_nev = NameTextBox.Text;
            int[] stuff = ListBox1.GetSelectedIndices();
            user.Hangszerek.Clear();
            foreach (var i in ListBox1.GetSelectedIndices())
            {
                foreach (var j in user.getInstruments())
                {
                    if (j.Key == Convert.ToInt32(ListBox1.Items[i].Value))
                    {
                        KeyValuePair<int, string> temp = new KeyValuePair<int, string>(j.Key, j.Value.Key);
                        user.Hangszerek.Add(temp);
                    }
                }
            }
            user.profileModify();
        }
    }
}