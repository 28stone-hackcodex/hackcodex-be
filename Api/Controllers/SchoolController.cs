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
        
        private readonly IDataProvider _dataProvider;

        public SchoolController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
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
    }
}