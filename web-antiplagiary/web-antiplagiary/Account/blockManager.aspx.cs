using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_antiplagiary.Models;

namespace web_antiplagiary.Account
{
    public partial class blockManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplicationDbContext applicationDbContext = new ApplicationDbContext();
                DropDownListStudent.Items.Clear();
                if (Context.User.IsInRole("Odmin"))
                {
                    var users = applicationDbContext.Users;                    
                    foreach(var u in users)
                    {
                        DropDownListStudent.Items.Add(new ListItem(u.UserName, u.Id));
                    }

                }
                else
                {

                    string roleId = applicationDbContext.Roles.Where(ex => ex.Name == "Student").First().Id;
                    foreach (ApplicationUser user in applicationDbContext.Users.OrderBy(x => x.DateCreate))
                        if (user.Roles.Where(ex => ex.RoleId == roleId).Count() > 0)                           
                        {
                            DropDownListStudent.Items.Add(new ListItem(user.UserName, user.Id));
                        }
                    
                }
            }
        }

        protected void ButtonBlock_Click(object sender, EventArgs e)
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            var user = applicationDbContext.Users.Where(ex => ex.Id == DropDownListStudent.SelectedValue).First();
            user.LockoutEnabled = true;
            user.LockoutEndDateUtc = DateTime.UtcNow.AddYears(20);
            applicationDbContext.SaveChanges();
            DropDownListStudent_SelectedIndexChanged(sender, e);
        }

        protected void ButtonUnBlock_Click(object sender, EventArgs e)
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            var user = applicationDbContext.Users.Where(ex => ex.Id == DropDownListStudent.SelectedValue).First();
            user.LockoutEndDateUtc = null;
            user.LockoutEnabled = false;            
            applicationDbContext.SaveChanges();
            DropDownListStudent_SelectedIndexChanged(sender, e);
        }

        protected void DropDownListStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            var user = applicationDbContext.Users.Where(ex => ex.Id == DropDownListStudent.SelectedValue).First();
            if(user.LockoutEnabled)
            {
                ButtonBlock.Enabled = true;
                ButtonUnBlock.Enabled = false;
            }
            else
            {
                ButtonBlock.Enabled = false;
                ButtonUnBlock.Enabled = true;
            }
        }
    }
}