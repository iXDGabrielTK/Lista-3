using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramacaoIV.Venda.Api.Entidades;

namespace ProgramacaoIV.Venda.Api.Map
{
    public sealed class VendedorMap : IEntityTypeConfiguration<Vendedores>
    {
        public void Configure(EntityTypeBuilder<Vendedores> builder)
        {
            builder.ToTable("vendedores");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(v => v.IsAtivo)
                .HasColumnName("is_ativo")
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(v => v.DtCriacao)
                .HasColumnName("dt_criacao")
                .IsRequired();

            builder.Property(v => v.DtAtualizacao)
                .HasColumnName("dt_atualizacao");

            // Relacionamento 1:N com Transacao
            builder.HasMany(v => v.Transacoes)
                .WithOne(t => t.Vendedores)
                .HasForeignKey(t => t.VendedoresId)
                .OnDelete(DeleteBehavior.Restrict); // evita deletar transações junto com vendedor
        }
    }
}
