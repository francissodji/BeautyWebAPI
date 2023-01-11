using BeautyWebAPI.Services.FindConfiguration;
using ConnectivityLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace BeautyWebAPI.Services.ImagePaths
{
    public class ImagePaths
    {
        private readonly IConnectivityData _connectivityDataRepos;
        private readonly string _connectionString;
        private readonly string _imageGeneralPath;

        public ImagePaths(IConfiguration configuration, IConnectivityData connectivityDataRepos)
        {
            _connectivityDataRepos = connectivityDataRepos;
            ConfigurationSettings configInfo = new ConfigurationSettings(configuration);
            _connectionString = configInfo.GetConnectionString();
            _imageGeneralPath = configInfo.GetImageReposPath();
        }

        public async Task<string> GetFilesPaths(int companyId, string typeRepos, string returnPath)
        {
            string pathToReturn = @"";
            string sourcePath = _imageGeneralPath; //Get the general path from config

            var company =  await _connectivityDataRepos.GetCompanyById(_connectionString, companyId);
            string subdomain = company.SubDomaine;

            //Get the actual image repos from company - Thik about this after

            string subReposImage = @"";
            switch (typeRepos)
            {
                case "STYLE":
                    subReposImage = "StylePictures";
                    break;

                case "GALLERY":
                    subReposImage = "GalleryPictures";
                    break;

                default:
                    break;
            }

            string uploadsDir = Path.Combine(sourcePath, subdomain);
            string fullPath = Path.Combine(uploadsDir, subReposImage);

            if (!System.IO.Directory.Exists(uploadsDir)) //If the repos doesn't exist, create it
                System.IO.Directory.CreateDirectory(uploadsDir);

            if (!System.IO.Directory.Exists(fullPath)) //If the repos doesn't exist, create it
                System.IO.Directory.CreateDirectory(fullPath);


            switch (returnPath)
            {
                case "FULLPATH":
                    pathToReturn = fullPath;
                    break;

                case "DBPATH":
                    pathToReturn = subReposImage;
                    break;

                case "DIRECTORYPATH":
                    pathToReturn = uploadsDir;
                    break;
                default:
                    break;
            }

            return pathToReturn;
        }



        public string GetImageById(string idImage)
        {
            string imageUrl = string.Empty;
            string hostUrl = "";
            //string filePath = GetFilePath(sourcePath, subdomain, "STYLE", fileName);
            //string imagePath = filePath + @"\image.png";

            if (!System.IO.File.Exists(hostUrl))
            {

            }
            else
            {
                imageUrl = hostUrl + "";
            }

            return imageUrl;

        }
    }
}
