using Domain.Entities.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping.Tokens
{
    public class TokensUsageMapping : IEntityTypeConfiguration<TokensUsage>
    {
        public void Configure(EntityTypeBuilder<TokensUsage> builder)
        {
            builder.ToTable("TokensUsage");

            builder.HasKey(t => t.Id);

            // Definições de colunas
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.ModelUsage)
                .IsRequired();

            builder.Property(t => t.TokenUsage); // pode ser null

            builder.Property(t => t.Date)
                .IsRequired()
                .HasColumnType("date")
                .HasDefaultValueSql("getdate()");


            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.TokenInput);
            builder.Property(t => t.TokenOutput);

            // Mapeamento do FK para a tabela de usuários (Identity)
            // Note que "User" aqui é do namespace Infrastructure.Identity.Entities
            builder.HasOne<User>()
                .WithMany()                 // não temos um ICollection<TokensUsage> na classe User, então WithMany() vazio
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(u => u.Id) // PK do IdentityUser é a string Id herdada
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}