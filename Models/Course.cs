using System.ComponentModel.DataAnnotations;

namespace webbsida.Models{
    public class Course{
        public int courseId { get; set; }

        [Required]
        public string? courseTitle { get; set; }

        public DateTime courseStartdate { get; set; }

        public DateTime courseEnddate { get; set; }

        public int programsId { get; set; }
        public Programs? programs { get; set; }
        
    }
    
}