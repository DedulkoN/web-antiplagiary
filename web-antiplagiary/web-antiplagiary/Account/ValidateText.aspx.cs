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
using Spire.Doc;
using System.Text.RegularExpressions;
using System.Net;

namespace web_antiplagiary.Account
{
    public partial class ValidateText : System.Web.UI.Page
    {
        public string htmlResult;      
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager= Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (manager.GetLockoutEnabled(User.Identity.GetUserId()))
                Response.Redirect("~/Account/Lockout");
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
                        if (CheckPrint.Checked)
                        {
                            string userfolder;
                            userfolder = Server.MapPath("TempFiles");
                            string templatePath = Server.MapPath("Templates") + "\\TemplateValidate.docx";
                            string newPath = userfolder + $"\\Rez_{User.Identity.GetUserId()}.docx";
                            if (!File.Exists(newPath))
                            {
                                File.Copy(templatePath, newPath);
                            }

                            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(newPath, true))
                            {
                                string docText = null;
                                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                                {
                                    docText = sr.ReadToEnd();
                                }

                                Regex regexFaculty = new Regex("date");
                                docText = regexFaculty.Replace(docText, DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString());
                                Regex regexFIO = new Regex("file");
                                docText = regexFIO.Replace(docText, file.FileName);

                                Regex regexTicket = new Regex("result");
                                docText = regexTicket.Replace(docText, $"{proc:00.##}%");

                                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                                {
                                    sw.Write(docText);
                                }
                            }

                            string pdfPath = Path.Combine(userfolder, $"Rez_{User.Identity.GetUserId()}.pdf");
                            Spire.Doc.Document document = new Spire.Doc.Document();
                            document.LoadFromFile(newPath);
                            document.SaveToFile(pdfPath, FileFormat.PDF);

                            //File.Delete(newPath);
                            WebClient UserClient = new WebClient();
                           
                            Byte[] FileBuffer = UserClient.DownloadData(pdfPath);
                            if (FileBuffer != null)
                            {
                                Response.ContentType = "application/pdf";
                                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                                Response.BinaryWrite(FileBuffer);
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("Ошибка: " + ex.Message + Environment.NewLine + ex.StackTrace);
                    }
                   
                    htmlResult += $"<span style='font-size:larger'>Проверяемый файл: </span> <span style='font-size:larger'>{file.FileName}</span><br/><span style='font-size:larger'>Результат: </span><span style='color:red;font-size:larger'>{proc:00.##}%</span>";
                    
                    
                   
                }
                else { Response.Write("Ошибка: файл не выбран" ); }
            }

            
        }

       


       

    }
}