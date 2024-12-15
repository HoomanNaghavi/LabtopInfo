using LabtopInfo.Entitis;

namespace LabtopInfo.Repository
{
    public interface ILabtopRepositoris
    {
         Task<Task<List<Labtops>>> GetLabtopsAsync();
         Task<bool> ExistlabtopsAysync(int labtopId);
         Task<Labtops?> GetLabtopsAsync(int labtopId, bool labtopCategory);
         Task<LabtopCategoris> GetLabtopCategoryForlabtopsAsync(int labtopId, int labtopsCategoryId);
         Task<IEnumerable<LabtopCategoris>> GetLabtopCategorisForlabtopsAsync(int labtopId);
         Task AddlabtopCategoriforlabtosAsync(int labtopId,LabtopCategoris labtopCategoris);
         Task<bool> SaveChangesAsync();
         void DeletelabtopCategoriforlabtosAsync(LabtopCategoris labtopCategoris);

    }
}
