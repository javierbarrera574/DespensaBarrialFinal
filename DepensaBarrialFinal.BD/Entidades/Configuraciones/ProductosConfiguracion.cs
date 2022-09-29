using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespensaBarrialFinal.BD.Entidades.Configuraciones
{
    internal class ProductosConfiguracion : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.
            Property(prop => prop.PrecioProducto).
            HasPrecision(precision: 14, scale: 2);

            builder.Property(o => o.PrecioProducto).HasPrecision(18, 4); 


            builder.
                Property(prop => prop.DescripcionProducto).
                IsRequired();


            builder.HasQueryFilter(prop => !prop.EstaBorrado);

            builder.
                HasIndex(prop => prop.NombreProducto).
                IsUnique().
                HasFilter("EstaBorrado= 'false'");



        }
    }
}