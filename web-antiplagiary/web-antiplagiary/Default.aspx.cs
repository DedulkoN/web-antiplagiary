using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace web_antiplagiary
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     /*   protected void Button1_Click(object sender, EventArgs e)
        {

            //чтение вордовсткого файла, без загрузки на сервер
            foreach (HttpPostedFile file in FileUpload1.PostedFiles)
            {
                if (file.ContentLength > 0)             
                {
                    
                    try
                    {

                        //string fn = System.IO.Path.GetFileName(file.FileName);
                        //string SaveLocation = Server.MapPath("TempFiles") + "\\" + fn;
                        //file.SaveAs(SaveLocation);

                        //Stream stream = File.Open(SaveLocation, FileMode.Open);                       
                        Stream stream = file.InputStream;
                        WordprocessingDocument wordprocessingDocument =
                             WordprocessingDocument.Open(stream, false);



                        Label1.Text = "";
                        //Label1.Text = wordprocessingDocument.MainDocumentPart.Document.Body.InnerText;
                        foreach (var a in wordprocessingDocument.MainDocumentPart.Document.Body.ChildElements)
                        {
                            char[] tochka = { '.', '?', '!', '\n', '\r' };
                            string[] words;
                            words = a.InnerText.Split(tochka);

                           

                            foreach (string s in words)
                            {
                                Label1.Text += s;
                            }
                           
                        }
                        wordprocessingDocument.Close();

                        stream.Close();
                        //File.Delete(SaveLocation);
                    }
                    catch (Exception ex)
                    {
                        
                        Response.Write("Ошибка: " + ex.Message + Environment.NewLine + ex.StackTrace);
                    }
                    

                }
                else { }
            }
        }*/
    }
}