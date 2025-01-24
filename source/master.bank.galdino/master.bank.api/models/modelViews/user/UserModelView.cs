using master.bank.api.models.modelViews.baseModelView;

namespace master.bank.api.models.modelViews.user;

public class UserModelView(string name, string email) : baseModelViews
{
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
}