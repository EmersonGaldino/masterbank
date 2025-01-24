namespace master.bank.api.models.viewsModel.routes;

public class RouteViewModel(string origin, string destiny, double value)
{
    public string Origin { get; set; } = origin;
    public string Destiny { get; set; } = destiny;
    public double Value { get; set; } = value;
}