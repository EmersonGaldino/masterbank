using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using master.bank.domain.core.Entity.route;
using master.bank.domain.core.repository.Interface.route;
using master.bank.infraestructure.persistence.repository.Base;
using master.bank.utils.shared;

namespace master.bank.infraestructure.persistence.repository.route;

public class RouteRepository(IConnectionPostgres uow) : RepositoryBase<RouteEntity>(uow), IRouteRepository
{
    #region .::Constructor
    private IConnectionPostgres Uow { get; set; } = uow;

    #endregion

    #region .::Methods
    
    public async Task<RouteEntity> AddAsync(RouteEntity routeEntity) =>
        await SaveReturnObjectAsync(routeEntity);

    public async Task<List<RouteEntity>> GetAll()
    {
        
        var data =
            await Uow.GetConnection().QueryAsync<RouteEntity>($"SELECT {GetFields()} FROM {GetTableName()}", 
                Uow.GetTransaction());
        return data.AsList();
    }
    #endregion

}