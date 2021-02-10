using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using web_antiplagiary.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Data.SqlClient;
using System.Data;

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
                    LabelInfo.Text = $"Пользователь с логином {user.UserName}, паролем {TextBoxPass.Text} и ролью {DropDownListRole.SelectedItem.Text} успешно создан и готов к работе.";
                    TextBoxName.Text = "";
                    TextBoxPass.Text = "";
                    
                }
                else {
                    LabelInfo.Text = "";
                    foreach (var s in result.Errors)
                        LabelInfo.Text += $"{s} "; 
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder SqlBuilderConnect = new SqlConnectionStringBuilder();
            SqlBuilderConnect.DataSource = "127.0.0.1";
            SqlBuilderConnect.InitialCatalog = "UnderControl";
            SqlBuilderConnect.Password = "T6hjm*UI";
            SqlBuilderConnect.UserID = "User";
            DataTable ResultTable = new DataTable();
            SqlConnection testConnection = new SqlConnection(SqlBuilderConnect.ToString());
            SqlCommand testCommand = testConnection.CreateCommand();

            try
            {
                testConnection.Open();
                testCommand.CommandText = string.Format("set language \'русский\'");
                testCommand.ExecuteNonQuery();
                testCommand.CommandText = "select * FROM [UnderControl].[dbo].[AppUsers]";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(testCommand);
                dataAdapter.Fill(ResultTable);
                testConnection.Close();
                //if (flag) Logger.InUserLog(UserID, query);               
            }
            catch { }

            foreach(DataRow row in ResultTable.Rows)
            {
                try
                {
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var user = new ApplicationUser() { UserName = row["Username"].ToString() };
                    IdentityResult result = manager.Create(user, row["Password"].ToString());
                    ApplicationDbContext applicationDbContext = new ApplicationDbContext();
                    if (result.Succeeded)
                    {
                        manager.AddToRoles(user.Id, "Teacher");
                        var u = applicationDbContext.Users.Where(x => x.Id == user.Id).First();
                        u.DateCreate = DateTime.Now;
                        u.SecurityInfo = TextBoxPass.Text;
                        u.LockoutEnabled = false;
                        applicationDbContext.SaveChanges();
                        LabelInfo.Text += $"Пользователь с логином {user.UserName}, паролем {TextBoxPass.Text} и ролью {DropDownListRole.SelectedItem.Text} успешно создан и готов к работе.";
                       

                    }
                    else
                    {
                        LabelInfo.Text = "";
                        foreach (var s in result.Errors)
                            LabelInfo.Text += $"{s} ";
                    }
                }
                catch (Exception ex)
                {
                    LabelInfo.Text = ex.Message;
                }
            }

        }
    }
}