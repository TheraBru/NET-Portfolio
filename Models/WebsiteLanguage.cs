namespace webbsida.Models{
    public class WebsiteLanguage{
        public int languageId { get; set; }
        public Language? language { get; set; }

        public int websiteId { get; set; }
        public Website? website { get; set; }
        
    }
    
}