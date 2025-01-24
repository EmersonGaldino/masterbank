using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace master.bank.domain.core.Entity.route;

[Table("tb_routes")]
public class RouteEntity
{
    [Key]
    public int Id { get; set; }
    [Column("origin")]
    public string Origin { get; set; }
    [Column("destiny")]
    public string Destiny { get; set; }
    [Column("value")]
    public decimal Value { get; set; }
}