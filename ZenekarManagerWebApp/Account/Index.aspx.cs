﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZenekarManagerWebApp.Account
{
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
            foreach (var claim in claims2){
                if (claim.Type == ClaimTypes.Email){
                    email = claim.Value;
                }
            }
            if (email != "")
            {
                user.readProfile(email);
                List<Message> msgs = user.getMessages();
                DataList1.DataSource = msgs;
                DataList1.DataBind();
                DropDownList1.DataSource = msgs;
                DropDownList1.DataBind();
            }
        }

        protected void SendMessageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/SendMessage");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            user.deleteMessage(Convert.ToInt32(DropDownList1.SelectedValue));
        }

    }

}