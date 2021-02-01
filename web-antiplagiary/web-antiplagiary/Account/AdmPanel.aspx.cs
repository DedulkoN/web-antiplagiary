using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using web_antiplagiary.Models;

namespace web_antiplagiary.Account
{
    public partial class AdmPanel : System.Web.UI.Page
    {
        public StringBuilder TableText;
        protected void Page_Load(object sender, EventArgs e)
        {

            TableText = new StringBuilder();
           
            if( Context.User.IsInRole("Odmin") )
            {
                ApplicationDbContext applicationDbContext = new ApplicationDbContext();
                foreach(ApplicationUser user in applicationDbContext.Users.OrderBy(x => x.DateCreate))
                {
                    string role="";
                    foreach (var a in user.Roles)
                        role += applicationDbContext.Roles.Where(ex => ex.Id == a.RoleId).FirstOrDefault().Name;
                    var block = user.LockoutEnabled ? "Заблокирован" : "Нет";
                    TableText.Append($"<tr scope='row'><td>{user.UserName}</td><td>{user.SecurityInfo}</td><td>{role}</td><td>{block}</td></tr>");
                }
            }
            else
            {
                ApplicationDbContext applicationDbContext = new ApplicationDbContext();
                string roleId = applicationDbContext.Roles.Where(ex => ex.Name == "Student").First().Id;
                foreach (ApplicationUser user in applicationDbContext.Users.OrderBy(x=>x.DateCreate))
                   if(user.Roles.Where(ex=>ex.RoleId==roleId).Count()>0)
                    {
                       
                        var block = user.LockoutEnabled ?  "Заблокирован" : "Нет";
                        TableText.Append($"<tr><td>{user.UserName}</td><td>{user.SecurityInfo}</td><td>Student</td><td>{block}</td></tr>");
                    }
                    
            }
            
        }
    }
}