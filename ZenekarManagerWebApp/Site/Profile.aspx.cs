using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Site
{
    public struct Hangszer
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public partial class Profile : System.Web.UI.Page
    {
        private User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Site/Login");
            }
            var ctx = Request.GetOwinContext();
            var currUser = ctx.Authentication.User;
            IEnumerable<Claim> claims2 = currUser.Claims;
            string email = "";
            email = Request.QueryString["email"];
            InitList();
            if (email == null)
            {
                user.readProfile(email);
                UpdateButton.Text = "Frissít";
                CurrPassLabel.Visible = true;
                CurrPassTextBox.Visible = true;
                NewPassConfirmLabel.Visible = true;
                NewPassConfirmTextBox.Visible = true;
                NewPassLabel.Visible = true;
                NewPassTextBox.Visible = true;
                PassChangeButton.Visible = true;
                PassReturnLabel.Visible = true;
                foreach (var claim in claims2)
                {
                    if (claim.Type == ClaimTypes.Email)
                    {
                        email = claim.Value;
                    }
                }
            }
            else
            {
                user.readProfile(email);
                if (!IsPostBack)
                {
                    if (user.Jogkor_id == Guest.REGISZTRALT)
                    {
                        UpdateButton.Text = "Felhasználó aktiválása";
                    }
                    else
                    {
                        UpdateButton.Text = "Frissít";
                    }
                }
                CurrPassLabel.Visible = false;
                CurrPassTextBox.Visible = false;
                NewPassConfirmLabel.Visible = false;
                NewPassConfirmTextBox.Visible = false;
                NewPassLabel.Visible = false;
                NewPassTextBox.Visible = false;
                PassChangeButton.Visible = false;
                PassReturnLabel.Visible = false;
                foreach (var claim in claims2)
                {
                    if (claim.Type == ClaimTypes.Role)
                    {
                        if (Convert.ToInt32(claim.Value) != Guest.MANAGER)
                        {
                            Response.Redirect("~/Site/Index");
                        }
                    }
                }
            }
            if (!IsPostBack)
            {
                EmailTextBox.Text = user.Users_email;
                NameTextBox.Text = user.Users_nev;
                ActiveCheckBox.Checked = user.Aktiv;
                ConcertCheckBox.Checked = user.Koncertre_jar;
                foreach (ListItem i in ListBox1.Items)
                {
                    foreach (var j in user.Hangszerek)
                    {
                        if (i.Value == j.Key.ToString())
                        {
                            i.Selected = true;
                        }
                    }
                }
            }
        }

        public List<Hangszer> getInstruments()
        {
            List<Hangszer> ret = new List<Hangszer>();
            User usr = new User();
            foreach (var instr in usr.getInstruments())
            {
                Hangszer temp = new Hangszer();
                temp.id = instr.Key;
                temp.name = instr.Value.Key;
                ret.Add(temp);
            }
            return ret;
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (user.Jogkor_id == Guest.REGISZTRALT)
            {
                user.Jogkor_id = Guest.ZENÉSZ;
                UpdateButton.Text = "Felhasználó aktiválása";
            }
            else
            {
                user.Users_email = EmailTextBox.Text;
                user.Users_nev = NameTextBox.Text;
                user.Aktiv = ActiveCheckBox.Checked;
                user.Koncertre_jar = ConcertCheckBox.Checked;
                user.Hangszerek.Clear();
                foreach (ListItem i in ListBox1.Items)
                {
                    foreach (var j in user.getInstruments())
                    {
                        if (i.Selected && j.Key.ToString() == i.Value)
                        {
                            KeyValuePair<int, string> temp = new KeyValuePair<int, string>(j.Key, j.Value.Key);
                            user.Hangszerek.Add(temp);
                        }
                    }
                }
            }
            user.profileModify();
        }

        protected void InitList()
        {
            User usr = new User();
            foreach (var i in usr.getInstruments())
            {
                ListItem it = new ListItem(i.Value.Key,i.Key.ToString());
                it.Selected = false;
                ListBox1.Items.Add(it);
            }
        }

        protected void PassChangeButton_Click(object sender, EventArgs e)
        {
            if (user.getHash(CurrPassTextBox.Text) == user.Users_password)
            {
                if (NewPassConfirmTextBox.Text == NewPassTextBox.Text)
                {
                    user.Users_password = user.getHash(NewPassTextBox.Text);
                    user.profileModify();
                    PassReturnLabel.Text = "A jelszó sikeresen megváltoztatva";
                }
                else
                {
                    PassReturnLabel.Text = "A jelszó ismétlése nem egyezik a jelszóval";
                }
            }
            else
            {
                PassReturnLabel.Text = "A régi jelszó helytelen";
            }
        }

        protected void Activate(object sender, EventArgs e)
        {
        }

    }
}