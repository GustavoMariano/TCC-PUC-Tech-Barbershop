using TCC_PUC_Tech_Barbershop.Domain.ContatoModule;
using TCC_PUC_Tech_Barbershop.Domain.EnderecoModule;
using TCC_PUC_Tech_Barbershop.Domain.InformacoesModule;
using TCC_PUC_Tech_Barbershop.Domain.PessoaModule;

namespace TCC_PUC_Tech_Barbershop.Domain.ClienteModule;

public class Cliente : Usuario
{
    public string Login { get; set; }
    public string Senha { get; set; }
    public Contato Contato { get; set; }
    public Informacoes Informacoes { get; set;}
    public Endereco Endereco { get; set; }
}
