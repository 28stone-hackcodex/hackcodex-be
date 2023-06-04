using Api.Models;
using Api.Services.Helpers;
using Api.Services.Interfaces;

namespace Api.Services.Store;

public class DataStore
{
    private readonly List<SingleSchoolView> _singleSchoolViews;
    private readonly JsonDbContext _dbContext;

    public DataStore(IDataProvider dataProvider)
    {
        _singleSchoolViews = dataProvider.GetHighSchools()
            .Select((highSchool, i) => MapperHelper.Map(i, highSchool))
            .ToList();

        _dbContext = dataProvider.GetData();
    }

    public JsonDbContext GetAllData()
    {
        return _dbContext;
    }

    public List<SingleSchoolView> GetSchools()
    {
        return _singleSchoolViews;
    }
}