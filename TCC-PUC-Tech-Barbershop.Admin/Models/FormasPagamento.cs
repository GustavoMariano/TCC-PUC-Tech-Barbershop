using System.ComponentModel.DataAnnotations.Schema;
using TCC_PUC_Tech_Barbershop.Admin.Models.Enums;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class FormasPagamento
{
    public int Id { get; set; }
    public FormaPagamentoEnum FormaPagamento { get; set; }
    [NotMapped]
    public List<FormaPagamentoEnum> FormasAceitas { get; set; }
}
