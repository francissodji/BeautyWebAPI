using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Net.Http.Headers;
using System.Linq;
using BeautyWebAPI.Services.ImagePaths;
using ConnectivityLibrary.Data;
using BeautyWebAPI.Services.FindConfiguration;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace BeautyWebAPI.Controllers
{
    public class UploadController : BaseController
    {

        private readonly IConfiguration _configuration;
        private readonly IConnectivityData _connectivityDataRepos;


        public UploadController(IConfiguration configuration, IConnectivityData connectivityDataRepos)
        {
            _configuration = configuration;
            _connectivityDataRepos = connectivityDataRepos;
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadfilePerso/{companyId}/{typePath}")]
        public async Task<IActionResult> UploadPerso(int companyId, string typePath)
        {
            try
            {
                var file = Request.Form.Files[0];

                ImagePaths imagePaths = new ImagePaths(_configuration, _connectivityDataRepos);

                if (file.Length > 0)
                {
                    string locationDb = await imagePaths.GetFilesPaths(companyId, typePath, "DBPATH");
                    string locationFull = await imagePaths.GetFilesPaths(companyId, typePath, "FULLPATH");

                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    var fullPath = Path.Combine(locationFull, fileName);
                    var dbPath = Path.Combine(locationDb, fileName); //for data base

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath }); // return the database path
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadfile")]
        public ActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadmultiplefile")]
        public IActionResult UploadMultiple()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
