using Api.Models;
using Api.Services.Store;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("data")]
    public class DataController : ControllerBase
    {
        private readonly DataStore _dataStore;

        public DataController(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet]
        [Route("all")]
        public JsonDbContext GetAllData()
        {
            return _dataStore.GetAllData();
        }
    }
}
