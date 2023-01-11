using Microsoft.Extensions.Configuration;

namespace BeautyWebAPI.Services.FindConfiguration
{
    public class ConfigurationSettings
    {

        private readonly IConfiguration _configuration;

        public ConfigurationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        { 
            return _configuration["ConnectionStrings:BeautyConnection"];
        }

        public string GetImageReposPath()
        {
            return _configuration["ImageRepos:DefaultImageRepos"]; ;
        }
    }
}
