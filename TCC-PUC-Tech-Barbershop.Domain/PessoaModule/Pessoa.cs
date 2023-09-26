using TCC_PUC_Tech_Barbershop.Domain.Enums;

namespace TCC_PUC_Tech_Barbershop.Domain.PessoaModule;

public class Pessoa
{
    public int Id { get; set; }
    public ETipoPessoa tipoPessoa { get; set; }
}
