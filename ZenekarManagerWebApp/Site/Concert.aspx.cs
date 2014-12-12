using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Site
{
    public partial class Concert : System.Web.UI.Page
    {
        global::Concert concert;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Site/Login");
            }
            var ctx = Request.GetOwinContext();
            var currUser = ctx.Authentication.User;
            IEnumerable<Claim> claims2 = currUser.Claims;
            string ID = "";
            ID = Request.QueryString["ID"];
            IFormatProvider culture = new System.Globalization.CultureInfo("hu-HU", true);
            int role = 0;
            if (!IsPostBack)
            {
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
                    User usr = new User();
                    concert = usr.getConcert(Convert.ToInt32(ID));
                    HelyszinLabel.Text = concert.Helyszin;
                    StartTimeLabel.Text = concert.Idopont;
                    EndTimeLabel.Text = concert.Vege;
                    MegjegyzesLabel.Text = concert.Megjegyzes;
                    TimeTextBox.Visible = false;
                    TimeTextBox1.Visible = false;
                    HelyszinTextBox.Visible = false;
                    ConcertButton.Visible = false;
                    DropDownList1.Visible = false;
                    AddPieceButton.Visible = false;
                    MegjegyzesTextBox.Visible = false;
                    AttendCheckBox.Visible = true;
                    AttendCheckBox.Checked = true;
                    AttendTextBox.Visible = false;
                    AttendLabel.Visible = true;
                    AttendMessageButton.Visible = false;
                }
                else if (role == Guest.MANAGER)
                {
                    StartTimeLabel.Text = "";
                    EndTimeLabel.Text = "";
                    HelyszinLabel.Text = "";
                    MegjegyzesLabel.Text = "";
                    AttendCheckBox.Visible = false;
                    AttendTextBox.Visible = false;
                    AttendLabel.Visible = false;
                    AttendMessageButton.Visible = false;
                    if (ID == null)
                    {
                        HelyszinTextBox.Text = "";
                        TimeTextBox.Text = DateTime.Now.ToString(culture);
                        TimeTextBox1.Text = DateTime.Now.ToString(culture);
                        ConcertButton.Text = "Koncert létrehozása";
                        concert = new global::Concert();
                    }
                    else
                    {
                        User usr = new User();
                        concert = usr.getConcert(Convert.ToInt32(ID));
                        HelyszinTextBox.Text = concert.Helyszin;
                        TimeTextBox.Text = concert.Idopont;
                        TimeTextBox1.Text = concert.Vege;
                        MegjegyzesTextBox.Text = concert.Megjegyzes;
                    }
                    InitList();
                }
            }
        }


        public void InitList()
        {
            User usr = new global::User();
            foreach (var sheet in usr.getPieces())
            {
                ListItem temp = new ListItem();
                temp.Text = sheet.Darab_szerzo + ": " + sheet.Darab_cim;
                temp.Value = sheet.Darab_id.ToString();
                DropDownList1.Items.Add(temp);
            }
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] == "1")
            {
                foreach (var sheet in usr.getPieces())
                {
                    if (sheet.Darab_id.ToString() == "1")
                    {
                        ListItem temp = new ListItem();
                        temp.Text = sheet.Darab_szerzo + ": " + sheet.Darab_cim;
                        BulletedList1.Items.Add(temp);
                    }
                    if (sheet.Darab_id.ToString() == "3")
                    {
                        ListItem temp = new ListItem();
                        temp.Text = sheet.Darab_szerzo + ": " + sheet.Darab_cim;
                        BulletedList1.Items.Add(temp);
                    }
                }
            }
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] == "2")
            {
                foreach (var sheet in usr.getPieces())
                {
                    if (sheet.Darab_id.ToString() == "2")
                    {
                        ListItem temp = new ListItem();
                        temp.Text = sheet.Darab_szerzo + ": " + sheet.Darab_cim;
                        BulletedList1.Items.Add(temp);
                    }
                }
            }
        }

        protected void AddPieceButton_Click(object sender, EventArgs e)
        {
            ListItem temp = new ListItem();
            User usr = new global::User();
            foreach (var sheet in usr.getPieces())
            {
                if (sheet.Darab_id.ToString() == DropDownList1.SelectedValue)
                {
                    temp.Text = sheet.Darab_szerzo + ": " + sheet.Darab_cim;
                }
            }
            BulletedList1.Items.Add(temp);
        }

        protected void ConcertButton_Click(object sender, EventArgs e)
        {
            concert.Helyszin = HelyszinTextBox.Text;
            concert.Idopont = TimeTextBox.Text;
            concert.Vege = TimeTextBox1.Text;
            concert.Megjegyzes = MegjegyzesTextBox.Text;
            if (concert.Koncert_id != -1)
            {
                concert.modify();
            }
            else
            {
                concert.create();
            }

        }

        protected void AttendCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AttendTextBox.Visible = !AttendCheckBox.Checked;
            AttendMessageButton.Visible = !AttendCheckBox.Checked;
        }

    }
}