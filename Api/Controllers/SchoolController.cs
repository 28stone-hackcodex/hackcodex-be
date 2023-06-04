using Api.Models;
using Api.Services.Store;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/schools")]
    [ResponseCache(Duration = 64000)]
    public class SchoolController
    {
        private readonly SchoolStore _schoolStore;

        public SchoolController(SchoolStore schoolStore)
        {
            _schoolStore = schoolStore;
        }

        [HttpGet]
        public List<SingleSchoolView> GetSchools()
        {
            return _schoolStore.GetSchools();
        }

        [HttpGet]
        [Route("/schools/{id:int}")]
        public SingleSchoolView GetSchool(int id)
        {
            return _schoolStore.GetSchools()[id];
        }
    }
}