using master.bank.api.models.modelViews.baseModelView;

namespace master.bank.api.models.modelViews.user;

public class UserModelView : baseModelViews
{
    public string Name { get; set; }
    public string Email { get; set; }
}