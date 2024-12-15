using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LabtopInfo.Entitis
{
    public class LabtopCategoris
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey("laptopId")]
        public Labtops laptops { get; set; }

        public int laptopId { get; set; }

        public LabtopCategoris(string name)
        {
            this.Name = name;
        }

    }
}
