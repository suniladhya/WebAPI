using CountingKs.Data;
using CountingKs.Models;
using System.Collections.Generic;
using System.Linq;
namespace CountingKs.Controllers
{
    public class MeasuresController : BaseApiController
    {
        private ModelFactory _modelFactory;
        private ICountingKsRepository _repo { get; set; }

        public MeasuresController(ICountingKsRepository repo) : base(repo)
        {
            _repo = repo;
            _modelFactory = new ModelFactory();
        }

        public IEnumerable<MeasureModel> Get(int foodId)
        {
            var results = _repo.GetMeasuresForFood(foodId)
                .ToList()
                .Select(m => _modelFactory.Create(m));
            return results;
        }
        public MeasureModel Get(int foodId, int id)
        {
            var MeasureResult = _repo.GetMeasure(id);

            var appropriateMeasureResult = _repo.GetMeasuresForFood(foodId)
                .ToList()
                .Where(m=>m.Food.Id == foodId)
                .Select(m => _modelFactory.Create(m));

            MeasureModel result = null;
            if (MeasureResult.Food.Id == foodId)
            {
                result = _modelFactory.Create(MeasureResult);
            }

            return result;
            //return appropriateMeasureResult;


        }
    }
}
