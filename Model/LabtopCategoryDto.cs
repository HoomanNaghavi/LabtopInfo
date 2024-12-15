using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabtopInfo.Entitis;

namespace LabtopInfo.Model
{
    public class LabtopCategoryDto
    {
       
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
       
        public string Description { get; set; }

    }
}
