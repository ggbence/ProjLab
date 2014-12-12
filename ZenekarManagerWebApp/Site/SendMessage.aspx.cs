using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Site
{
    public partial class SendMessage : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            var ctx = Request.GetOwinContext();
            var currUser = ctx.Authentication.User;
            IEnumerable<Claim> claims2 = currUser.Claims;
            string email = "";
            foreach (var claim in claims2){
                if (claim.Type == ClaimTypes.Email){
                    email = claim.Value;
                }
            }
            if (email != "")
            {
                user.readProfile(email);
            }
        }

        public List<User> getUsers()
        {
            Manager manager = new Manager();
            return manager.getUserList();
        }

        protected void SendMessageButton_Click(object sender, EventArgs e)
        {
            Message msg = new Message();
            msg.Cimzett.Add(Convert.ToInt32(DropDownList1.SelectedValue));
            msg.Kuldo = user.Users_id;
            msg.Uzenet = MessageBox.Text;
            msg.Datum = DateTime.Now.ToString();
            msg.Ervenyesseg = DateTime.Now.AddYears(1).ToString();
            user.sendMessage(msg);
        }

    }

    public class UserList
    {
        public List<User> getUsers()
        {
            Manager manager = new Manager();
            return manager.getUserList();
        }
    }
}