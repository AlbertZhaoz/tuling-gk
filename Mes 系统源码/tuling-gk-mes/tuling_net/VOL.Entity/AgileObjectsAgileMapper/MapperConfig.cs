using AgileObjects.AgileMapper;
using VOL.Entity.DomainModels;

namespace VOL.Entity.AgileObjectsAgileMapper
{
    public static class MapperConfig
    {
        static MapperConfig()
        {
            Mapper.WhenMapping
            .From<Albert_DataFirst>()
            .To<Albert_DataFirstRework>();
        }
    }
}
