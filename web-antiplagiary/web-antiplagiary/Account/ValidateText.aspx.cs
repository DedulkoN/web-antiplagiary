using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace web_antiplagiary.Account
{
    public partial class ValidateText : System.Web.UI.Page
    {
        public string htmlResult;      
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager= Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (manager.GetLockoutEnabled(User.Identity.GetUserId()))
                Response.Redirect("/Account/Lockout");
        }

        protected void ButtonStart_Click(object sender, EventArgs e)
        {
            
            foreach (HttpPostedFile file in FileUpload1.PostedFiles)
            {
                htmlResult = "";

                if (file.ContentLength > 0)
                {
                    Models.ModelAntiPL modelAntiPL = new Models.ModelAntiPL();   
                    string[] words;
                    Double proc = 0;
                    try
                    {                    
                        Stream stream = file.InputStream;
                        WordprocessingDocument wordprocessingDocument =
                             WordprocessingDocument.Open(stream, false);
                       
                        words = ClassProcessing.ReadAllTextFromDocx(stream);     

                            switch(DropDownListTypeWork.SelectedValue)
                            {
                                case "0":
                                    proc = ClassProcessing.ValidateWorks(words, ClassProcessing.TypeValidateWork.Курсовая);
                                break;
                                case "1":
                                    proc = ClassProcessing.ValidateWorks(words, ClassProcessing.TypeValidateWork.Дипломная);
                                break;
                                case "2":
                                    proc = ClassProcessing.ValidateWorks(words, ClassProcessing.TypeValidateWork.Магистерская);
                                break;
                                case "3":
                                    proc = ClassProcessing.ValidateWorks(words, ClassProcessing.TypeValidateWork.Научная);
                                break;
                            }
                            
                      

                        stream.Close();
                        //File.Delete(SaveLocation);
                    }
                    catch (Exception ex)
                    {

                        Response.Write("Ошибка: " + ex.Message + Environment.NewLine + ex.StackTrace);
                    }
                   
                    htmlResult += $"<span>Проверяемый файл: </span> <span>{file.FileName}</span><br/><span>Результат: </span><span style='color:red'>{proc:00.##}%</span>";
                    
                   
                }
                else { Response.Write("Ошибка: файл не выбран" ); }
            }

            
        }

       


       

    }
}