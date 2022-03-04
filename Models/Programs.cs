using System.ComponentModel.DataAnnotations;

namespace webbsida.Models{
    public class Programs{
        public int programsId { get; set; }

        [Required]
        public string? programsTitle { get; set; }

        [Required]
        public string? programsSchool { get; set; }

        public string? programsDegree { get; set; }

        [Required]
        public DateTime programsStartdate { get; set; }

        [Required]
        public DateTime programsEnddate { get; set; }
        
    }
    
}