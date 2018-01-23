using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Drawing;
using System.Web.Mvc;

namespace httpDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
        public ActionResult upload(string files)
        {
            if (files != null) 
            {
                return RedirectToAction("getImg", "Home", new { fil = files });
               

                //sFile.SaveAs(Server.MapPath("/Files/" + files));
               
            }
            return View();
        }

       

        public void fileUp()
        {
         
            Response.AddHeader("Content-type", "txt");
              Response.AddHeader("Content-Disposition","attachment;filename="+"aaa.txt");
            string filePath = Server.MapPath("/Files/aaa.txt");//路径
          
            FileInfo fileInfo = new FileInfo(filePath);
          
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
          
        }

        public void getImg()
        {
          string str=  Request.QueryString["fil"];
          Response.AddHeader("Content-type", "image/png");

            FileStream sFile = new FileStream(@"C:\Users\Public\Pictures\Sample Pictures\" + str, FileMode.Open);
            long length = sFile.Length;
            byte[] bys = new byte[length];
            sFile.Read(bys, 0, (int)length);
            sFile.Close();
            //File file = new File();
            //Image img = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\" + files);
            Response.BinaryWrite(bys);
        
        }


    }
}