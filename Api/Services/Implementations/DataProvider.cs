using Api.Models;
using Api.Services.Interfaces;
using Newtonsoft.Json;

namespace Api.Services.Implementations
{
    public class DataProvider : IDataProvider
    {
        public JsonDbContext GetData()
        {
            JsonDbContext data = null;
            using (StreamReader reader = new("data/jsonDbContext.json"))
            {
                var json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<JsonDbContext>(json);
            }

            data.HighSchools = GetHighSchools();
            foreach(var item in data.HighSchools)
            {
                var municipality = data.Municipalities.FirstOrDefault(x => string.Equals(x.Name, item.Municipality, StringComparison.InvariantCultureIgnoreCase));
                item.LocationId = data.Locations.FirstOrDefault(x => x.MunicipalityId == municipality.Id).Id;
            }

            return data;

        }
        public List<HighSchool> GetHighSchools()
        {
            using (StreamReader reader = new("data/schools.json"))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<HighSchool>>(json, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore});
            }
        }
    }
}
