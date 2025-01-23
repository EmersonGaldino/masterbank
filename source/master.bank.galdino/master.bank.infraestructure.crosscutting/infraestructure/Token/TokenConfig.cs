namespace master.bank.infraestructure.crosscutting.infraestructure.Token;

public class TokenConfig
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public int ExpireIn { get; set; }
    public string SigningKey { get; set; }
}