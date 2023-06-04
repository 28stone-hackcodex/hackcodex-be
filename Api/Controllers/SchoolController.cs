using Api.Models;
using Api.Services.Helpers;
using Api.Services.Store;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/schools")]
    public class SchoolController
    {
        private readonly SchoolStore _schoolStore;

        public SchoolController(SchoolStore schoolStore)
        {
            _schoolStore = schoolStore;
        }

        [HttpGet]
        [ResponseCache(Duration = 64000)]
        public List<SingleSchoolView> GetSchools()
        {
            return _schoolStore.GetSchools();
        }

        [HttpGet]
        [Route("/schools/{id:int}")]
        [ResponseCache(Duration = 64000)]
        public SingleSchoolView GetSchool(int id)
        {
            return _schoolStore.GetSchools()[id];
        }
    }
}