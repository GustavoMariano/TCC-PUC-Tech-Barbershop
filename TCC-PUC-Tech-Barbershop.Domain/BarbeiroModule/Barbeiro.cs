using TCC_PUC_Tech_Barbershop.Domain.AgendaModule;
using TCC_PUC_Tech_Barbershop.Domain.AtendimentoModule;
using TCC_PUC_Tech_Barbershop.Domain.ContatoModule;
using TCC_PUC_Tech_Barbershop.Domain.EnderecoModule;
using TCC_PUC_Tech_Barbershop.Domain.FormasPagamentoModule;
using TCC_PUC_Tech_Barbershop.Domain.InformacoesModule;
using TCC_PUC_Tech_Barbershop.Domain.PessoaModule;

namespace TCC_PUC_Tech_Barbershop.Domain.BarbeiroModule;

public class Barbeiro : Usuario
{
    public string Login { get; set; }
    public string Senha { get; set; }
    public Contato Contato { get; set; }
    public Informacoes Informacoes { get; set; }
    public Endereco Endereco { get; set; }
    public Agenda Agenda { get; set; }
    public FormasPagamento FormasAceitas { get; set; }
    public List<Atendimento> Atendimentos { get; set; }
}
