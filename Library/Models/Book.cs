using DataAnnotationsExtensions;
using ServiceStack.DataAnnotations;
using System.ComponentModel;

namespace Library.Models {
    public class Book {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Títol")]
        public string Title { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Posició")]
        public string Position { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Editioral")]
        public string Publisher { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Any de publicació")]
        [Year]
        public int PublicationYear { get; set; }


        [Display(Name = "Arxiu")]
        public String? file { get; set; }

    }
}
