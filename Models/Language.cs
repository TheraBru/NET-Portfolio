using System.ComponentModel.DataAnnotations;

namespace webbsida.Models{
    public class Language{
        public int languageId { get; set; }

        [Required]
        public string? languageTitle { get; set; }

        public IList<WebsiteLanguage>? websiteLanguages { get; set; }
        
    }
    
}