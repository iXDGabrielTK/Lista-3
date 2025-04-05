namespace ProgramacaoIV.Venda.Api.DTO;

public sealed class TransacaoDTO
{
    public sealed class TransacaoCapaRequest
    {
        public Guid IdCliente { get; set; }
        public int VendedoresId { get; set; } 
    }

    public sealed class TransacaoItemRequest
    {
        public Guid IdProduto { get; set; } = Guid.Empty;
        public decimal Quantidade { get; set; } = decimal.Zero;
    }
}