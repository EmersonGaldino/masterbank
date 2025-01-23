using AutoMapper;
using master.bank.domain.core.Entity.User;
using master.bank.domain.core.model.user;

namespace master.bank.utils.autoMapper;

public class MappingProfile : Profile
{
    public MappingProfile() => CreateMap<UserEntity, UserModel>().ReverseMap();
}