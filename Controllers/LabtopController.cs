using AutoMapper;
using LabtopInfo.Entitis;
using LabtopInfo.Migrations;
using LabtopInfo.Model;
using LabtopInfo.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LabtopInfo.Controllers
{
    [ApiController]
    [Route("api/labtops")]
    public class LabtopController : Controller
    {
        private readonly ILabtopRepositoris _labtopRepositoris;
        private readonly IMapper _mapper;   
        public LabtopController(ILabtopRepositoris labtopRepositoris, IMapper mapper)
        {
            _labtopRepositoris= labtopRepositoris;
            _mapper=mapper;
        }


        [HttpGet]
        
        public async Task <ActionResult<IEnumerable<LabtopDto>> > GetAllLabtops()
        {
            var labtops =  await _labtopRepositoris.GetLabtopsAsync();
             
            return Ok(
                _mapper.Map<IEnumerable<LabtopDto>>(labtops)

                );
        }

        [HttpGet("{labtopId}/categories")]
        public async Task<ActionResult<IEnumerable<LabtopCategoryDto>>> GetLabtopCategorisForlabtop(int labtopId)
        {
            if (!await _labtopRepositoris.ExistlabtopsAysync(labtopId))
            {
                return NotFound();
            }

            var labtopsCategoris = await _labtopRepositoris.
                GetLabtopCategorisForlabtopsAsync(labtopId);
            return Ok(_mapper.Map <IEnumerable<LabtopCategoryDto>>(labtopsCategoris));

        }

        [HttpGet("{labtopId}/categories/{labtopCategoryId}")]
        public async Task<ActionResult<LabtopCategoryDto>> GetlabtoCategoryForLabtop(int labtopId,int labtopCategoryId)
        {
            if (!await _labtopRepositoris.ExistlabtopsAysync(labtopId))
            {
                return NotFound();
            }

            var labtopCategory = await _labtopRepositoris.
                GetLabtopCategoryForlabtopsAsync(labtopId, labtopCategoryId);
            if (labtopCategory == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<LabtopCategoryDto>(labtopCategory));
        }

        [HttpPost]
        [Route("categorispost")]
        public async Task<ActionResult<LabtopCategoryDto>> CrationLabtopcategoris
            (int labtopId,LabtopCategorisForCration labtopCategoris)
        {
            if (!await _labtopRepositoris.ExistlabtopsAysync(labtopId))
            {
                return NotFound();
            }

            var finalpoint = _mapper.Map<Entitis.LabtopCategoris>(labtopCategoris);
            await _labtopRepositoris.AddlabtopCategoriforlabtosAsync(labtopId, finalpoint);
            await _labtopRepositoris.SaveChangesAsync();
            var crationpoint = _mapper.Map<Model.LabtopCategoryDto>(finalpoint);
            return CreatedAtAction( nameof(GetLabtopCategorisForlabtop), new
            {
                labtopId=labtopId
            }, crationpoint);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateLabtiopCatgoris(
            int labtopId,
            int labtopCategoryId,
            JsonPatchDocument<LabtopCategorisForUpdate> patchDocument
                )
        {
            if (!await _labtopRepositoris.ExistlabtopsAysync(labtopId))
            {
                return NotFound();
            }

            var categorisEntry = await _labtopRepositoris.GetLabtopCategoryForlabtopsAsync(labtopId, labtopCategoryId);
            if (categorisEntry == null)
            {
                return NotFound();
            }

            var categoritopatch = _mapper.Map<LabtopCategorisForUpdate>(categorisEntry);
            patchDocument.ApplyTo(categoritopatch,ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(categoritopatch))
            {
                return BadRequest();
            }

            _mapper.Map(categoritopatch, categorisEntry);
             await _labtopRepositoris.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLabtopCAtegor(int labtopId,int labtopCategoryId)
        {
            if (!await _labtopRepositoris.ExistlabtopsAysync(labtopId))
            {
                return NotFound();
            }
            var category = await _labtopRepositoris.GetLabtopCategoryForlabtopsAsync(labtopId, labtopCategoryId);
            if (category == null)
            {
                return NotFound();
            }
            _labtopRepositoris.DeletelabtopCategoriforlabtosAsync(category);
             await _labtopRepositoris.SaveChangesAsync();
             return NoContent();
        }
    }
}
