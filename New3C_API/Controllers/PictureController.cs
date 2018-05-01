using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using New3C_API.Common;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http;
using System.Net;

namespace New3C_API.Controllers
{
    
    //[Produces("application/json")]
    [Route("api/Picture")]
    [EnableCors("AllownSpecificOrigin")]
    public class PictureController : Controller
    {
        private IHostingEnvironment hostingEnv;
        //private IContentTypeProvider contentTypeProvider;

        string[] pictureFormatArray = { "png", "jpg", "jpeg", "bmp", "gif", "ico", "PNG", "JPG", "JPEG", "BMP" };

        public PictureController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
            //this.contentTypeProvider = ctProvider;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            if (size > 104857600)
            {
                return Json(FileHelper.Error_Msg_Ecode_Elevel_HttpCode("Files total size > 100MB"));
            }

            List<string> filePathResultList = new List<string>();

            foreach (var file in files)
            {
                //TODO:判断真实文件类型
                //System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
                //string bx = " ";
                //byte buffer;
                //try
                //{
                //    buffer = r.ReadByte();
                //    bx = buffer.ToString();
                //    buffer = r.ReadByte();
                //    bx += buffer.ToString();
                //}
                //catch (Exception exc)
                //{
                //    Console.WriteLine(exc.Message);
                //}
                //r.Close();
                //fs.Close();
                //真实的文件类型
                //Console.WriteLine(bx);
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string filePath = hostingEnv.WebRootPath + $@"\Files\Pictures\";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string suffix = fileName.Split('.')[1];

                if (!pictureFormatArray.Contains(suffix))
                {
                    return Json(FileHelper.Error_Msg_Ecode_Elevel_HttpCode("the picture not support this format"));
                }

                fileName = DateTime.Now.ToString("yyyyMMddHHmmsfff")+ file.Name; 

                string fileFullName = filePath + fileName;

                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                filePathResultList.Add($"/src/pictures/{fileName}");

            }
            string message = $"{files.Count} file(s) /{size} bytes uploaded successfully!";
            return Json(FileHelper.Success_Msg_Data_DCount_HttpCode(message, filePathResultList, filePathResultList.Count));
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var imgPath = hostingEnv.WebRootPath + $@"\Files\Pictures\ll0a20180223111947537.jpg";
            //从图片中读取byte  
            var imgByte = System.IO.File.ReadAllBytes(imgPath);
            //从图片中读取流  
            var imgStream = new MemoryStream(System.IO.File.ReadAllBytes(imgPath));
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(imgByte)
                //或者  
                //Content = new StreamContent(stream)  
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return resp;
        }
    }
}