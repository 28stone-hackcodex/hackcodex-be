using Api.Models;
using Api.Services.Helpers;
using Api.Services.Interfaces;

namespace Api.Services.Store;

public class SchoolStore
{
    private readonly List<SingleSchoolView> _singleSchoolViews = new();

    public SchoolStore(IDataProvider dataProvider)
    {
        var list = dataProvider.GetHighSchools();
        for (var index = 0; index < list.Count; index++)
        {
            var item = list[index];
            _singleSchoolViews.Add(MapperHelper.Map(index, item));
        }
    }

    public List<SingleSchoolView> GetSchools()
    {
        return _singleSchoolViews;
    }
}