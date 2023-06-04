using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("data")]
    [ResponseCache(Duration = 64000)]
    public class DataController : ControllerBase
    {
        private readonly IDataProvider _dataProvider;

        public DataController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        [Route("all")]
        public JsonDbContext GetAllData()
        {
            return _dataProvider.GetData();
        }
    }
}
