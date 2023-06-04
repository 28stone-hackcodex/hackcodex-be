using Api.Models;
using Api.Services.Store;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/schools")]
    public class SchoolController
    {
        private readonly DataStore _schoolStore;

        public SchoolController(DataStore schoolStore)
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