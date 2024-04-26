namespace Library.Models {
    public class User {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        public int Age { get; set; }
    }
}
