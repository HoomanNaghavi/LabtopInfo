using System.ComponentModel.DataAnnotations;

namespace LabtopInfo.Model
{
    public class LabtopCategorisForUpdate
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
