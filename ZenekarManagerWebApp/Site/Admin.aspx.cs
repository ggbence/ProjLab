using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Site
{
    public struct UserOut
    {
        public string name { get; set; }
        public string email { get; set; }
        public string jogkör { get; set; }
        public string hangszerek { get; set; }
    }

    public struct ConcertOut
    {
        public string ID { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string helyszin { get; set; }
        public string megjegyzes { get; set; }
    }
    public struct PieceOut
    {
        public string ID { get; set; }
        public string Composer { get; set; }
        public string Title { get; set; }
        public bool Inrepertoar { get; set; }
        public string Link { get; set; }
        
    }
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.SetActiveView(UserView);
                DropDownList1.SelectedIndex = 0;
                ConcertListView.DataSource = getConcerts();
                ConcertListView.DataBind();
            }
            var ctx = Request.GetOwinContext();
            var currUser = ctx.Authentication.User;
            IEnumerable<Claim> claims2 = currUser.Claims;
            int role = 0;
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
                Response.Redirect("~/Site/Index");
            }
        }

        public List<PieceOut> getPieces()
        {
            List<PieceOut> ret = new List<PieceOut>();
            Manager me = new Manager();
            foreach (var piece in me.getPieces()){
                PieceOut temp = new PieceOut();
                temp.ID = piece.Darab_id.ToString();
                temp.Composer = piece.Darab_szerzo;
                temp.Title = piece.Darab_cim;
                switch (piece.Darab_id)
                {
                    case 1:
                        temp.Inrepertoar = true;
                        break;
                    case 2:
                        temp.Inrepertoar = true;
                        break;
                    case 3:
                        temp.Inrepertoar = false;
                        break;
                }
                temp.Inrepertoar = true;
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
                ret.Add(temp);
            }
            return ret;
        }
        

        public List<UserOut> getUsers()
        {
            List<UserOut> ret = new List<UserOut>();
            Manager me = new Manager();
            foreach (var user in me.getUserList())
            {
                UserOut usr = new UserOut();
                usr.name = user.Users_nev;
                usr.email = user.Users_email;
                switch (user.Jogkor_id)
                {
                    case Guest.REGISZTRALT:
                        usr.jogkör = "regisztrált";
                        break;
                    case Guest.ZENÉSZ:
                        usr.jogkör = "zenész";
                        break;
                    case Guest.MANAGER:
                        usr.jogkör = "manager";
                        break;
                    default:
                        break;
                }
                usr.hangszerek = "";
                user.readProfile(user.Users_email);
                if (user.Hangszerek != null)
                foreach (var hangszer in user.Hangszerek)
                {
                    usr.hangszerek += hangszer.Value + ", ";
                }
                if (usr.hangszerek != "")
                {
                    usr.hangszerek = usr.hangszerek.Remove(usr.hangszerek.Length - 2);
                }
                ret.Add(usr);
            }
            return ret;
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

        protected void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/Profile?email=" + ListView2.SelectedDataKey.Value.ToString());
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(DropDownList1.SelectedValue))
            {
                case 0:
                    MultiView1.SetActiveView(UserView);
                    break;
                case 1:
                    MultiView1.SetActiveView(SheetView);
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

        protected void AddConcert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/Concert");
        }

        protected void ConcertListView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void SheetListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}