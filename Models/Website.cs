using System.ComponentModel.DataAnnotations;

namespace webbsida.Models{
    public class Website{
        public int websiteId { get; set; }

        [Required]
        public string? websiteTitle { get; set; }

        [Required]
        public string? websiteDescription { get; set; }

        [Required]
        public string? websiteUrl { get; set; }

        public string? websitePicture { get; set; }

        public IList<WebsiteLanguage>? websiteLanguages { get; set; }
        public IList<WebsiteFramework>? websiteFrameworks { get; set; }
        
    }
}