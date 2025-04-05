using ProgramacaoIV.Venda.Api.Entidades;

public class Vendedores : AbstractEntity
{
    public new bool IsAtivo { get; set; }
    public string Nome { get; set; }
    public int Id { get; set; }
    public string Email { get; set; }
    public DateTime DtCriacao { get; set; }
    public DateTime? DtAtualizacao { get; set; }
    public ICollection<Transacao> Transacoes { get; set; }

    private Vendedores() : base() { }

    public Vendedores(string nome, string email, bool isAtivo = true)
    {
        Nome = nome;
        Email = email;
        IsAtivo = isAtivo;
        DtCriacao = DateTime.UtcNow;
    }

    public void Atualizar(string nome, string email)
    {
        Nome = nome;
        Email = email;
        DtAtualizacao = DateTime.UtcNow;
    }
}
