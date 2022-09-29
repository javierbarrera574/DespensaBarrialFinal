using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespensaBarrialFinal.BD.Entidades.Configuraciones
{
    internal class DepositoConfiguracion : IEntityTypeConfiguration<Deposito>
    {
        public void Configure(EntityTypeBuilder<Deposito> builder)
        {

            builder.
             Property(prop => prop.UnidadMinima).
             HasPrecision(precision: 14, scale: 2);

            builder.
                Property(prop => prop.ProductosEnDeposito).
                IsRequired();

        }
    }
}
