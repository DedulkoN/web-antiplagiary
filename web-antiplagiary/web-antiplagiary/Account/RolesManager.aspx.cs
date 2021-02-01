using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_antiplagiary.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace web_antiplagiary.Account
{
    public partial class RolesManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ApplicationDbContext applicationDbContext = new ApplicationDbContext();
                DropDownListRole.Items.Clear();
                DropDownListUser.Items.Clear();

                foreach(var user in applicationDbContext.Users)
                {
                    DropDownListUser.Items.Add(new ListItem(user.UserName, user.Id));
                }

                foreach(var role in applicationDbContext.Roles)
                {
                    DropDownListRole.Items.Add(new ListItem(role.Name, role.Name));
                }

            }
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var Roles= manager.GetRolesAsync(DropDownListUser.SelectedValue).Result.ToArray();
             manager.RemoveFromRolesAsync(DropDownListUser.SelectedValue, Roles).Wait();
            
            
            var rez=  manager.AddToRoleAsync(DropDownListUser.SelectedValue, DropDownListRole.SelectedItem.Text).Result;
            if (rez.Succeeded) LabelRez.Text = $"Пользователю {DropDownListUser.SelectedItem.Text} назначена роль {DropDownListRole.SelectedItem.Text}";
            else LabelRez.Text = $"Не удалось назначить пользователю {DropDownListUser.SelectedItem.Text} роль {DropDownListRole.SelectedItem.Text}";

        }
    }
}