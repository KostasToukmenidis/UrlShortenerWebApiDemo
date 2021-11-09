using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class Url
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(2000)]
        public string LongUrl { get; set; }

        [Required]
        [StringLength(50)]
        public string ShortUrl { get; set; }

        [Required]
        [StringLength(9)]
        public string Token { get; set; }
    }
}
