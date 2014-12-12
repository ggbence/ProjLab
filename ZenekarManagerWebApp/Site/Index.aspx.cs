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
    public struct Piece
    {
        public string ID { get; set; }
        public string Composer { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

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
                }
            }
            if (!IsPostBack)
            {
                MultiView1.SetActiveView(MultiMessageView);
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

        public List<Piece> getPieces()
        {
            List<Piece> ret = new List<Piece>();
            Manager me = new Manager();
            foreach (var piece in me.getPieces())
            {
                Piece temp = new Piece();
                temp.ID = piece.Darab_id.ToString();
                temp.Composer = piece.Darab_szerzo;
                temp.Title = piece.Darab_cim;
                switch (piece.Darab_id)
                {
                    case 1:
                        temp.Link = "https://dl.dropboxusercontent.com/u/31971493/kottak/IMSLP28868-PMLP01607-beethoven-sym-9-ccarh.pdf";
                        break;
                    case 2:
                        temp.Link = "https://dl.dropboxusercontent.com/u/31971493/kottak/IMSLP47656-PMLP20137-Mozart-Zauberflote-Overture_Full_Score.pdf";
                        break;
                    case 3:
                        temp.Link = "https://dl.dropboxusercontent.com/u/31971493/kottak/IMSLP05238-Spring-score-a4.pdf";
                        break;
                }
                switch (piece.Darab_id)
                {
                    case 1:
                        ret.Add(temp);
                        break;
                    case 2:
                        ret.Add(temp);
                        break;
                    case 3:
                        break;
                }
            }
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
        public List<ConcertOut> getConcerts()
        {
            List<ConcertOut> ret = new List<ConcertOut>();
            User usr = new User();
            foreach (var conc in usr.getAllConcert())
            {
                ConcertOut temp = new ConcertOut();
                temp.ID = conc.Koncert_id.ToString();
                DateTime concerttime = new DateTime();
                IFormatProvider culture = new System.Globalization.CultureInfo("hu-HU", true);
                concerttime = DateTime.Parse(conc.Idopont, culture);
                if (concerttime > DateTime.Now)
                {
                    temp.starttime = conc.Idopont;
                    temp.endtime = conc.Vege;
                    temp.helyszin = conc.Helyszin;
                    temp.megjegyzes = conc.Megjegyzes;
                    ret.Add(temp);
                }
            }
            return ret;
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(DropDownList2.SelectedValue))
            {
                case 0:
                    MultiView1.SetActiveView(MultiMessageView);
                    break;
                case 1:
                    MultiView1.SetActiveView(SheetsView);
                    break;
                case 2:
                    MultiView1.SetActiveView(ConcertView);
                    break;
            }
        }

        protected void ConcertListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/Concert?ID=" + ConcertListView.SelectedDataKey.Value.ToString());
        }

        protected void ConcertListView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }
    }

}