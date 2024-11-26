using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.ModelPet.Species;
using PetFamily.Domain.Models.ModelPet.Species.ValueObject;

namespace PetFamily.Infrastructure.Configurations;

public class SpecieConfiguration : IEntityTypeConfiguration<Specie>
{
    public void Configure(EntityTypeBuilder<Specie> builder)
    {
        builder.ToTable("species");
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasColumnOrder(1)
            .HasConversion(
                id => id.Id,
                id => new SpecieId(id))
            .IsRequired();

        builder.ComplexProperty(s => s.Name, sn =>
        {
            sn.Property(n => n.Name)
                .HasColumnName("name")
                .HasMaxLength(30)
                .IsRequired();
        });

        builder.HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey(s => s.SpecieId)
            .IsRequired();
    }
}