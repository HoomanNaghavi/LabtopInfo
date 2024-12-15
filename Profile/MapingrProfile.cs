
using System.Runtime.CompilerServices;

namespace LabtopInfo.Profile

{
    public class MapingrProfile : AutoMapper.Profile
    {
        public MapingrProfile()
        {
            CreateMap<Entitis.Labtops,Model.LabtopDto>();
            CreateMap<Entitis.LabtopCategoris,Model.LabtopCategoryDto>();
            CreateMap<Entitis.LabtopCategoris, Model.LabtopCategorisForCration>();
            CreateMap<Model.LabtopCategorisForCration, Entitis.LabtopCategoris>();
            CreateMap<Entitis.LabtopCategoris, Model.LabtopCategorisForUpdate>();
            CreateMap<Model.LabtopCategorisForUpdate, Entitis.LabtopCategoris>();
        }
        
    }
}
