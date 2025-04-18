﻿using Org.BouncyCastle.Asn1.Ocsp;

namespace ProgramacaoIV.Venda.Api.Entidades;

public sealed class Transacao : AbstractEntity
{
    public Cliente Cliente { get; private set; }
    public ICollection<ItemTransacao> Itens { get; private set; } = new List<ItemTransacao>();
    public decimal Total => Itens.Sum(x => x.Total);
    public Vendedores Vendedores { get; set; } 
    public int VendedoresId { get; set; } 

    /// <summary>
    /// To EF Core
    /// </summary>
    private Transacao() : base() { }

    public Transacao(Cliente cliente, Vendedores vendedor)
    {
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        Vendedores = vendedor ?? throw new ArgumentNullException(nameof(vendedor));
        VendedoresId = vendedor.Id;
    }

    public void AdicionarItem(ItemTransacao item)
    {        
        Itens.Add(item);
        AtualizarDataAtualizacao();
    }

    public void RemoverItem(ItemTransacao item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        Itens.Remove(item);
        AtualizarDataAtualizacao();
    }
}