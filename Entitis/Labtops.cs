﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabtopInfo.Entitis
{
    public class Labtops
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }


        public Labtops(string name) 
        {
            this.Name = name; 
        }

        public ICollection<LabtopCategoris> labtopCategoris { get; set; } =
            new List<LabtopCategoris>(); 
    }
}
