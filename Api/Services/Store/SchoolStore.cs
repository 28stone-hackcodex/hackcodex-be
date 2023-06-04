using Api.Models;
using Api.Services.Helpers;
using Api.Services.Interfaces;

namespace Api.Services.Store;

public class SchoolStore
{
    private readonly List<SingleSchoolView> _singleSchoolViews = new();

    public SchoolStore(IDataProvider dataProvider)
    {
        _singleSchoolViews = dataProvider.GetHighSchools()
            .Select((highSchool, i) => MapperHelper.Map(i, highSchool))
            .ToList();
    }

    public List<SingleSchoolView> GetSchools()
    {
        return _singleSchoolViews;
    }
}