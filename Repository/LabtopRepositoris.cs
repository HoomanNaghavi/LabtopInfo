using LabtopInfo.DbContexts;
using LabtopInfo.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LabtopInfo.Repository
{
    public class LabtopRepositoris : ILabtopRepositoris
    {
        private LabtopsInfoDbContexts _contexts;

        public LabtopRepositoris(LabtopsInfoDbContexts contexts )
        {
            _contexts = contexts;   
        }

       

        public async Task<List<Labtops>> GetLabtopsAsync()
        {
            return await _contexts.labtops.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<bool> ExistlabtopsAysync(int labtopId)
        {
            return await _contexts.labtops.AnyAsync(c => c.Id == labtopId);
        }

        public async Task<Labtops?> GetLabtopsAsync(int labtopId, bool labtopCategory)
        {
            if (labtopCategory)
            {
                return await _contexts.labtops.Include(C => C.labtopCategoris).Where(C => C.Id == labtopId)
                    .FirstOrDefaultAsync();
            }

            return await _contexts.labtops.Where(c => c.Id == labtopId).FirstOrDefaultAsync();
        }

        public async Task<LabtopCategoris> GetLabtopCategoryForlabtopsAsync(int labtopId, int labtopsCategoryId)
        {
            return await _contexts.labtopCategoris.Where(c => c.laptopId == labtopId && c.Id == labtopsCategoryId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LabtopCategoris>> GetLabtopCategorisForlabtopsAsync(int labtopId)
        {
            return await _contexts.labtopCategoris.Where(C => C.laptopId == labtopId).ToListAsync();
        }

        public async Task AddlabtopCategoriforlabtosAsync(int labtopId, LabtopCategoris labtopCategoris)
        {
            var labtops = await GetLabtopsAsync(labtopId,  false);
            if (labtops!=null)
            {
                labtops.labtopCategoris.Add(labtopCategoris);
            }
        }

        public void DeletelabtopCategoriforlabtosAsync(LabtopCategoris labtopCategoris)
        {
            _contexts.labtopCategoris.Remove(labtopCategoris);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _contexts.SaveChangesAsync() > 0);
        }

       
    }
}
