using CountingKs.Data;
using CountingKs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class FoodsController : ApiController
    {
        private ModelFactory _modelFactory;

        private ICountingKsRepository _repo { get; set; }
        public FoodsController(ICountingKsRepository repo)
        {
            _repo = repo;
            _modelFactory = new ModelFactory();
        }
        public IEnumerable<FoodModel> Get()
        {
            var result = _repo.GetAllFoods()
                              .OrderByDescending(f => f.Description)
                              .Take(25)
                              .ToList();

            var resultWithMeasures = _repo.GetAllFoodsWithMeasures()
                .OrderByDescending(x => x.Description)
                .Take(25)
                .ToList()
                .Select(x=> new {
                    Description = x.Description,
                    Measures = x.Measures.Select(y=> new { Description = y.Description, Calories = y.Calories})
                });
            var resultMFWithMeasures = _repo.GetAllFoodsWithMeasures()
                .OrderByDescending(f => f.Description)
                .Take(25)
                .ToList()
                .Select(f => _modelFactory.Create(f));

            return resultMFWithMeasures;
        }
        public FoodModel Get(int id)
        {
            return _modelFactory.Create(_repo.GetFood(id));
        }
    }
}
