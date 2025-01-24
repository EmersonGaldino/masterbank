using master.bank.domain.core.Entity.route;
using master.bank.domain.core.repository.Interface.route;
using master.bank.domain.core.service.Base;
using master.bank.domain.core.service.Interface.route;

namespace master.bank.domain.core.service.route;

public class RouteService(IRouteRepository repository)
    : ServiceBase<RouteEntity, IRouteRepository>(repository), IRouteService
{
    public async Task<RouteEntity> AddAsync(RouteEntity routeEntity) =>
         await GetRepository().AddAsync(routeEntity);

    public async Task<List<RouteEntity>> GetAll() => await GetRepository().GetAll();
    public async Task<string> GetRote(string origin, string destiny)
    {
        var route = FindCheapestRoute( await GetRepository().GetAll(), origin, destiny);
        return route.Route != null ? $"Melhor rota: {string.Join(" - ", route.Route)} ao custo de ${route.Cost:F2}" : "Nenhuma rota disponível.";;
    }
    private static RouteResult FindCheapestRoute(List<RouteEntity> routes, string origin, string destination)
    {
        var lowestCost = decimal.MaxValue;
        List<string> bestRoute = null;

        SearchRoute(routes, origin, destination, 0, 
            new List<string>(), new HashSet<string>(), ref lowestCost, ref bestRoute);

        return new RouteResult { Route = bestRoute, Cost = lowestCost };
    }

    static void SearchRoute(
        List<RouteEntity> routes,
        string current,
        string destination,
        decimal currentCost,
        List<string> currentRoute,
        HashSet<string> visited,
        ref decimal lowestCost,
        ref List<string> bestRoute)
    {
        if (current == destination)
        {
            if (currentCost >= lowestCost) return;
            lowestCost = currentCost;
            bestRoute = new List<string>(currentRoute) { current };
            return;
        }

        visited.Add(current);

        var nextRoutes = routes.Where(r => r.Origin == current);

        foreach (var route in nextRoutes)
        {
            if (visited.Contains(route.Destiny)) continue;

            currentRoute.Add(current);
            SearchRoute(routes, route.Destiny, destination, currentCost + route.Value, currentRoute, visited, ref lowestCost, ref bestRoute);
            currentRoute.RemoveAt(currentRoute.Count - 1); 
        }

        visited.Remove(current); 
    }

}