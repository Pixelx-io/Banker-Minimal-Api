namespace Banker.DataAccess.Mapper;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<AccountModel, AccountDto>().ReverseMap();
    }
}