using LabtopInfo.Entitis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabtopInfo.Model
{
    public class LabtopDto
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<LabtopCategoris> labtopCategoris { get; set; } =
            new List<LabtopCategoris>();
    }
}
