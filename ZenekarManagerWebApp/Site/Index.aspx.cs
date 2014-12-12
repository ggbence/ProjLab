using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Site
{
    public struct Messages
    {
        public string sender { get; set; }
        public string date { get; set; }
        public string ID { get; set; }
    }
    public struct Kottak
    {
        public string author { get; set; }
        public string title { get; set; }
        public string ID { get; set; }
    }

    public partial class Index : System.Web.UI.Page
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
            int role = 0;
            foreach (var claim in claims2)
            {
                if (claim.Type == ClaimTypes.Email)
                {
                    email = claim.Value;
                }
                else if (claim.Type == ClaimTypes.Role)
                {
                    role = Convert.ToInt32(claim.Value);
                }
            }
            if (!IsPostBack)
            {
                if (role == Guest.REGISZTRALT)
                {
                    Response.Redirect("~/Site/Profile");
                }
                else if (role == Guest.MANAGER)
                {
                    Response.Redirect("~/Site/Admin");
                }
            }
            if (email != "")
            {
                user.readProfile(email);
                if (!IsPostBack)
                {
                    List<Message> msgs = user.getMessages();
                    DropDownList1.DataSource = msgs;
                    DropDownList1.DataBind();
                    ListView2.DataSource = getMessages();
                    ListView2.DataBind();
                    SheetListView.DataSource = getSheets();
                    SheetListView.DataBind();
                }
            }
            if (!IsPostBack)
            {
                MultiView1.SetActiveView(SheetsView);
            }
        }

        protected void SendMessageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/SendMessage");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            user.deleteMessage(Convert.ToInt32(DropDownList1.SelectedValue));
        }

        public List<Messages> getMessages()
        {
            List<Messages> ret = new List<Messages>();
            foreach (var msg in user.getMessages())
            {
                Messages temp = new Messages();
                Manager mng = new Manager();
                foreach (var usr in mng.getUserList())
                {
                    if (usr.Users_id == msg.Kuldo)
                    {
                        temp.sender = usr.Users_nev;
                    }
                }
                temp.ID = msg.Uzenet_id.ToString();
                temp.date = msg.Datum;
                ret.Add(temp);
            }
            return ret;
        }
        public List<Kottak> getSheets()
        {
            List<Kottak> ret = new List<Kottak>();
            Kottak temp = new Kottak();
            temp.author = "Mozart";
            temp.title = "Varázsfuvola nyitány";
            temp.ID = "1";
            Kottak temp2 = new Kottak();
            temp2.author = "Beethoven";
            temp2.title = "9. Szimfónia";
            temp2.ID = "2";
            ret.Add(temp);
            ret.Add(temp2);
            return ret;
        }

        protected void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(ListView2.SelectedDataKey.Value);
            foreach (var i in user.getMessages())
            {
                if (i.Uzenet_id == ID)
                {
                    Manager mng = new Manager();
                    foreach (var usr in mng.getUserList())
                    {
                        if (usr.Users_id == i.Kuldo)
                        {
                            SenderLabel.Text = usr.Users_nev;
                        }
                    }
                    DateLabel.Text = i.Datum;
                    MessageLabel.Text = i.Uzenet;
                }
            }
            ListView2.SelectedIndex = -1;
            MultiView1.SetActiveView(MessageView);
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(MultiMessageView);
        }

        protected void ListView2_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void SheetListView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }
    }

}