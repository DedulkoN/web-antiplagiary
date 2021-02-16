using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Net;

namespace web_antiplagiary.Account
{
    public partial class PdfWrite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                Label1.Text = "";
                string userfolder;
                userfolder = Server.MapPath("TempFiles");
                string pdfPath = Path.Combine(userfolder, $"Rez_{User.Identity.GetUserId()}.pdf");
               
                WebClient UserClient = new WebClient();

                Byte[] FileBuffer = UserClient.DownloadData(pdfPath);
                if (FileBuffer != null)
                {
                    
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
            }
            catch(Exception ex) { Label1.Text = ex.Message; }
        }

        
    }
}