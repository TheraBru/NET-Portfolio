namespace webbsida.Models{
    public class WebsiteFramework{
        public int frameworkId { get; set; }
        public Framework? framework { get; set; }

        public int websiteId { get; set; }
        public Website? website { get; set; }
        
    }
    
}