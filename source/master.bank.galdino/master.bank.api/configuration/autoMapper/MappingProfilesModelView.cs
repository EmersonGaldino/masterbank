using AutoMapper;
using master.bank.api.models.modelViews.user;
using master.bank.domain.core.model.user;

namespace master.bank.api.configuration.autoMapper;

public class MappingProfilesModelView : Profile
{
    public MappingProfilesModelView() =>  CreateMap<UserModel, UserModelView>().ReverseMap();
}