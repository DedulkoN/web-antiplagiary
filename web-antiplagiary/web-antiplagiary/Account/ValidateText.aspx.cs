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
    public partial class ValidateText : System.Web.UI.Page
    {
        public string htmlResult;
        private const int MinimumLenght = 20;
        private char[] tochka = { '.', '?', '!', '\n', '\r' };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonStart_Click(object sender, EventArgs e)
        {
            
            foreach (HttpPostedFile file in FileUpload1.PostedFiles)
            {
                htmlResult = "";

                if (file.ContentLength > 0)
                {
                    Models.ModelAntiPL modelAntiPL = new Models.ModelAntiPL();
                    int CountPar = 0;
                    int CountInBase = 0;
                    List<string> inBD = new List<string>();
                    List<string> inAll = new List<string>();
                    string AllSTR="";

                    try
                    {                    
                        Stream stream = file.InputStream;
                        WordprocessingDocument wordprocessingDocument =
                             WordprocessingDocument.Open(stream, false);
                        AllSTR = ReadAllTextFromDocx(stream);
                                      
                                                  
                            string[] words;
                            words = AllSTR.Split(tochka);
                            switch(DropDownListTypeWork.SelectedValue)
                            {
                                case "0":
                                    foreach (string s in words)
                                    {
                                        string tempString=s;
                                       
                                        if (tempString.Length > MinimumLenght)
                                        {
                                           
                                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                                            CountPar++;
                                            if (modelAntiPL.TextWorks.Where(m => m.TextWorks1 == tempString).Count() > 0 )
                                            {
                                                //htmlResult += $"<p style='color:red'>{s}</p>";
                                                CountInBase++;                                                
                                            } //else { htmlResult += $"<p>{s}</p>"; }
                                        }
                                    }
                                break;
                                case "1":
                                    

                                break;
                                case "2":


                                break;
                                case "3":


                                break;
                        }
                            
                      

                        stream.Close();
                        //File.Delete(SaveLocation);
                    }
                    catch (Exception ex)
                    {

                        Response.Write("Ошибка: " + ex.Message + Environment.NewLine + ex.StackTrace);
                    }
                    Double proc = Convert.ToDouble(CountPar -  CountInBase)*100 / CountPar;
                    htmlResult += $"<span>Проверяемый файл: </span> <span>{file.FileName}</span><br/><span>Результат: </span><span style='color:red'>{proc.ToString("00.##")}%</span>";
                    
                   
                }
                else { Response.Write("Ошибка: файл не выбран" ); }
            }





            
        }

        public static string ReadAllTextFromDocx(Stream fileInfo)
        {
            StringBuilder stringBuilder;
            using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(fileInfo, false))
            {
                NameTable nameTable = new NameTable();
                XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
                xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");

                string wordprocessingDocumentText;
                using (StreamReader streamReader = new StreamReader(wordprocessingDocument.MainDocumentPart.GetStream()))
                {
                    wordprocessingDocumentText = streamReader.ReadToEnd();
                }

                stringBuilder = new StringBuilder(wordprocessingDocumentText.Length);

                XmlDocument xmlDocument = new XmlDocument(nameTable);
                xmlDocument.LoadXml(wordprocessingDocumentText);

                XmlNodeList paragraphNodes = xmlDocument.SelectNodes("//w:p", xmlNamespaceManager);
                foreach (XmlNode paragraphNode in paragraphNodes)
                {
                    XmlNodeList textNodes = paragraphNode.SelectNodes(".//w:t | .//w:tab | .//w:br", xmlNamespaceManager);
                    foreach (XmlNode textNode in textNodes)
                    {
                        switch (textNode.Name)
                        {
                            case "w:t":
                                stringBuilder.Append(textNode.InnerText);
                                break;

                            case "w:tab":
                                stringBuilder.Append("\t");
                                break;

                            case "w:br":
                                stringBuilder.Append("\v");
                                break;
                        }
                    }

                    stringBuilder.Append(Environment.NewLine);
                }
            }

            return stringBuilder.ToString();
        }


       

    }
}