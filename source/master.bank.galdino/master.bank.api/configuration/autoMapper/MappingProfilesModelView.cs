using AutoMapper;
using master.bank.api.models.modelViews.route;
using master.bank.api.models.modelViews.user;
using master.bank.api.models.viewsModel.routes;
using master.bank.domain.core.Entity.route;
using master.bank.domain.core.model.user;

namespace master.bank.api.configuration.autoMapper;

public class MappingProfilesModelView : Profile
{
    public MappingProfilesModelView()
    {
        CreateMap<UserModel, UserModelView>().ReverseMap();
        CreateMap<RouteEntity, RouteModelView>().ReverseMap();
        CreateMap<RouteEntity, RouteViewModel>().ReverseMap();
    } 
}