using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using web_antiplagiary.Models;
using Microsoft.AspNet.Identity.Owin;

namespace web_antiplagiary.Account
{
    public partial class AddNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListRole.Items.Clear();
                ApplicationDbContext applicationDbContext = new ApplicationDbContext();
                if (Context.User.IsInRole("Odmin"))
                {
                    DropDownListRole.Enabled = true;
                    foreach (var ROLE in applicationDbContext.Roles)
                        DropDownListRole.Items.Add(new ListItem(ROLE.Name, ROLE.Id));

                }
                else
                {
                    DropDownListRole.Enabled = false;
                    var role = applicationDbContext.Roles.Where(ex => ex.Name == "Student").First();
                    DropDownListRole.Items.Add(new ListItem(role.Name, role.Id));
                }
            }
        }

        protected void ButtonReg_Click(object sender, EventArgs e)
        {
            try
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();                
                var user = new ApplicationUser() { UserName = TextBoxName.Text };
                IdentityResult result = manager.Create(user, TextBoxPass.Text);
                ApplicationDbContext applicationDbContext = new ApplicationDbContext();
                if (result.Succeeded)
                {
                    manager.AddToRoles(user.Id, DropDownListRole.SelectedItem.Text);                    
                    var u = applicationDbContext.Users.Where(x => x.Id == user.Id).First();
                    u.DateCreate = DateTime.Now;
                    u.SecurityInfo = TextBoxPass.Text;
                    u.LockoutEnabled = false;
                    applicationDbContext.SaveChanges();
                    LabelInfo.Text = $"Пользователь с логином {user.UserName}, паролем {user.SecurityInfo} и ролью {DropDownListRole.SelectedItem.Text} успешно создан и готов к работе.";
                    TextBoxName.Text = "";
                    TextBoxPass.Text = "";
                    
                }
            }
            catch(Exception ex)
            { 
                LabelInfo.Text = ex.Message; 
            }

        }

        protected void ButtonPassGenerate_Click(object sender, EventArgs e)
        {
            TextBoxPass.Text = ClassProcessing.PasswordGenerator();
        }

        protected void ButtonNameGenerate_Click(object sender, EventArgs e)
        {
            TextBoxName.Text = ClassProcessing.UserNameGenerator();
        }
    }
}