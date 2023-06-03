using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [ApiController]
    [Route("data")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public JsonDbContext GetAllData()
        {
            using (StreamReader reader = new("data/jsonDbContext.json"))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<JsonDbContext>(json);
            }
        }

    }
}
