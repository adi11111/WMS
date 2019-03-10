using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GwDealerPortal.Service.Common;
using GwDealerPortal.DataAccess.Entities;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GwDealerPortal.Service.Controllers
{
    public class BaseController : Controller
    {
        private IHostingEnvironment _env;
        public BaseController(IHostingEnvironment env)
        {
            _env = env;
        }
        public async Task<bool> CreateFilesAsync(string path, Microsoft.AspNetCore.Http.IFormFileCollection files, int id)
        {
            var _path = _env.ContentRootPath;
            _path += @"\wwwroot\Content\PolicyForms\";
            DirectoryInfo directoryInfo = new DirectoryInfo(_path);
            //foreach (FileInfo file in directoryInfo.GetFiles())
            //{
            //    file.Delete();
            //}
            //foreach (DirectoryInfo dir in di.GetDirectories())
            //{
            //    dir.Delete(true);
            //}
            // long size = files.Sum(f => f);
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].Length > 0)
                {
                    FileInfo[] filesInDir = directoryInfo.GetFiles(id + "-*.*");
                    var _ext = Path.GetExtension(_path + files[i].FileName);
                    var _fileName = Path.GetFileNameWithoutExtension(_path + files[i].FileName);
                    using (var stream = new FileStream(_path + id + "-" + _fileName + "-" + (filesInDir.Count() + i + 1) + _ext, FileMode.Create))
                    {
                        await files[i].CopyToAsync(stream);
                    }
                }
            }
            return true;
        }
    }
}