using System.ComponentModel.DataAnnotations;

namespace webbsida.Models{
    public class Framework{
        public int frameworkId { get; set; }

        [Required]
        public string? frameworkTitle { get; set; }

        public int languageId { get; set; }
        public Language? language { get; set; }

        public IList<WebsiteFramework>? websiteFrameworks { get; set; }
        
    }
}