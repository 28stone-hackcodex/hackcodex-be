using Api.Models;
using Api.Services.Helpers;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/schools")]
    public class SchoolController
    {
        private readonly ILogger<SchoolController> _logger;
        private readonly IDataProvider _dataProvider;

        public SchoolController(IDataProvider dataProvider, ILogger<SchoolController> logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }

        [HttpGet]
        public List<SingleSchoolView> GetSchools()
        {
            var singleSchoolViews = new List<SingleSchoolView>();
            var list = _dataProvider.GetHighSchools();
            for (var index = 0; index < list.Count; index++)
            {
                var item = list[index];
                singleSchoolViews.Add(MapperHelper.Map(index, item));
            }

            return singleSchoolViews;
        }

        [HttpGet]
        [Route("/schools/{id:int}")]
        public SingleSchoolView GetSchool(int id)
        {
            var list = _dataProvider.GetHighSchools();
            return MapperHelper.Map(id, list[id]);
        }
    }
}