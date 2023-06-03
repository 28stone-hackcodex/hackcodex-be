using Api.Models;

namespace Api.Services.Interfaces
{
    public interface IDataProvider
    {
        List<HighSchool> GetHighSchools();
        JsonDbContext GetData();
    }
}
