using AutoMapper;
using VOL.Entity.DomainModels;

namespace VOL.WebApi.AutoMapperConfigs
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            // Add your AutoMapper configuration here for the Web project.
            CreateMap<Albert_DataFirst, Albert_DataFirstRework>();
            CreateMap<Albert_DataSecond, Albert_DataSecondRework>();
        }
    }
}
