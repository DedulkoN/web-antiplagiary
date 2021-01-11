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

namespace web_antiplagiary.Account
{
    public partial class AddWorks : System.Web.UI.Page
    {
        public StringBuilder htmlResult;
        protected void Page_Load(object sender, EventArgs e)
        {
            htmlResult = new StringBuilder();
        }

        protected void ButtonStart_Click(object sender, EventArgs e)
        {
            foreach (HttpPostedFile file in FileUpload1.PostedFiles)
            {
                if (file.ContentLength > 0)
                {
                    Models.ModelAntiPL modelAntiPL = new Models.ModelAntiPL();
                    string[] words;
                    try
                    {
                        Stream stream = file.InputStream;
                        WordprocessingDocument wordprocessingDocument =
                             WordprocessingDocument.Open(stream, false);

                        words = ClassProcessing.ReadAllTextFromDocx(stream);

                        switch (DropDownListTypeWork.SelectedValue)
                        {
                            case "0":
                                htmlResult.Append($"Добавлено {ClassProcessing.AddTextToBD(words, ClassProcessing.TypeValidateWork.Курсовая)} строк из файла '{file.FileName}'.<br />");
                                break;
                            case "1":
                                htmlResult.Append($"Добавлено {ClassProcessing.AddTextToBD(words, ClassProcessing.TypeValidateWork.Дипломная)} строк из файла '{file.FileName}'.<br />");
                                break;
                            case "2":
                                htmlResult.Append($"Добавлено {ClassProcessing.AddTextToBD(words, ClassProcessing.TypeValidateWork.Магистерская)} строк из файла '{file.FileName}'.<br />");
                                break;
                            case "3":
                                htmlResult.Append($"Добавлено {ClassProcessing.AddTextToBD(words, ClassProcessing.TypeValidateWork.Научная)} строк из файла '{file.FileName}'.<br />");
                                break;
                        }
                    }
                    catch(Exception ex) 
                    {
                        // Response.Write("Ошибка: " + ex.Message + Environment.NewLine + ex.StackTrace);
                        htmlResult.Append($"<span style='color:red'>Обработка файла {file.FileName} вызвало исключение {ex.Message}.</span><br />");
                    }

                }
            }
        }
    }
}