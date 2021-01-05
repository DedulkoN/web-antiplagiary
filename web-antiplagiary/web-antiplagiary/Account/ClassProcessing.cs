using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using System.Text;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml;
using web_antiplagiary.Models;



namespace web_antiplagiary.Account
{
    /// <summary>
    /// Класс исполняемых функций
    /// </summary>
    public static class ClassProcessing
    {
        /// <summary>
        /// Минимальная длинная обрабатываемой строки
        /// </summary>
        private const int MinimumLenght = 20;
       
        /// <summary>
        /// Тип проверяемой работы
        /// </summary>
        public enum TypeValidateWork 
        {Курсовая, Дипломная, Магистерская, Научная};


        /// <summary>
        /// переводик файловый поток с файлом DOCX в массив предложений. 
        /// </summary>
        /// <param name="fileInfo">Файловый поток DOCX</param>
        /// <returns>Массив предложений</returns>
        public static string[] ReadAllTextFromDocx(Stream fileInfo)
        {
            char[] tochka = { '.', '?', '!', '\n', '\r' };
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
            
            return stringBuilder.ToString().Split(tochka);
        }

        /// <summary>
        /// Проверка работы на уникальность
        /// </summary>
        /// <param name="STRArray">Массив предложений</param>
        /// <param name="typeWork">Тип проверяемой работы</param>
        /// <returns>Процент уникальности работы</returns>
        public static Double ValidateWorks(string[] STRArray, TypeValidateWork typeWork)
        {
            ModelAntiPL modelAntiPL = new ModelAntiPL();
            int CountPar = 0;
            int CountInBase = 0;
            switch (typeWork)
            {
                case TypeValidateWork.Курсовая:
                    foreach (string s in STRArray)
                    {

                        string tempString = s;

                        if (tempString.Length > MinimumLenght)
                        {

                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                            CountPar++;
                            if (modelAntiPL.TextWorks.Where(m => m.TextWorks1 == tempString).Count() > 0)
                            {

                                CountInBase++;
                            }
                        }
                    }
                break;
                case TypeValidateWork.Дипломная:
                    foreach (string s in STRArray)
                    {

                        string tempString = s;

                        if (tempString.Length > MinimumLenght)
                        {

                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                            CountPar++;
                            if (modelAntiPL.TextWorksDiploms.Where(m => m.TextWorks == tempString).Count() > 0)
                            {

                                CountInBase++;
                            }
                        }
                    }
                    break;
                case TypeValidateWork.Магистерская:
                    foreach (string s in STRArray)
                    {

                        string tempString = s;

                        if (tempString.Length > MinimumLenght)
                        {

                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                            CountPar++;
                            if (modelAntiPL.TextWorksMagisters.Where(m => m.TextWorks == tempString).Count() > 0)
                            {

                                CountInBase++;
                            }
                        }
                    }
                    break;
                case TypeValidateWork.Научная:
                    foreach (string s in STRArray)
                    {

                        string tempString = s;

                        if (tempString.Length > MinimumLenght)
                        {

                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                            CountPar++;
                            if (modelAntiPL.TextWorksScience.Where(m => m.TextWorks == tempString).Count() > 0)
                            {

                                CountInBase++;
                            }
                        }
                    }
                    break;
            }

            return Convert.ToDouble(CountPar - CountInBase) * 100.0 / CountPar;
        }

        /// <summary>
        /// Добавление строк в БД Антиплагиата
        /// </summary>
        /// <param name="STRArray">Массив предложений</param>
        /// <param name="typeWork">Тип работы</param>
        public static int AddTextToBD(string[] STRArray, TypeValidateWork typeWork)
        {
            ModelAntiPL modelAntiPL = new ModelAntiPL();
            switch (typeWork)
            {
                case TypeValidateWork.Курсовая:
                    foreach (string s in STRArray)
                    {
                        string tempString = s;
                        if (tempString.Length > MinimumLenght)
                        {

                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                            modelAntiPL.TextWorks.Add(new TextWorks { TextWorks1 = tempString });
                        }
                    }
                    break;
                case TypeValidateWork.Дипломная:
                    foreach (string s in STRArray)
                    {
                        string tempString = s;
                        if (tempString.Length > MinimumLenght)
                        {

                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                            modelAntiPL.TextWorksDiploms.Add(new TextWorksDiploms() { TextWorks = tempString });
                        }
                    }
                    break;
                case TypeValidateWork.Магистерская:
                    foreach (string s in STRArray)
                    {
                        string tempString = s;
                        if (tempString.Length > MinimumLenght)
                        {

                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                            modelAntiPL.TextWorksMagisters.Add(new TextWorksMagisters() { TextWorks = tempString });
                        }
                    }
                    break;
                case TypeValidateWork.Научная:
                    foreach (string s in STRArray)
                    {
                        string tempString = s;
                        if (tempString.Length > MinimumLenght)
                        {

                            if (tempString.Length > 430) tempString = tempString.Substring(0, 430);
                            modelAntiPL.TextWorksScience.Add(new TextWorksScience() { TextWorks = s });
                        }
                       
                    }
                    break;
            }
            return modelAntiPL.SaveChanges();

        }



    }
}