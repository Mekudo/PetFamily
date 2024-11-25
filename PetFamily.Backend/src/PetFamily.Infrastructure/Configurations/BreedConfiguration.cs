using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.ModelPet.ModelBreed;
using PetFamily.Domain.Models.ModelPet.ModelBreed.ValueObject;

namespace PetFamily.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breeds");
        
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Id)
            .HasColumnOrder(1)
            .HasConversion(
                id => id.Id,
                id => BreedId.Create(id))
            .IsRequired();
        
        builder.ComplexProperty(s => s.Name, sn =>
        {
            sn.Property(n => n.Name)
                .HasColumnName("name")
                .HasMaxLength(30)
                .IsRequired();
        });
        
        builder.ComplexProperty(s => s.Description, sd =>
        {
            sd.Property(d => d.Description)
                .HasColumnName("description")
                .HasMaxLength(200)
                .IsRequired();
        });
        
        builder.Property(b => b.SpecieId)
            .IsRequired();
        
        builder.HasOne(b => b.Specie)
            .WithMany()
            .HasForeignKey(b => b.SpecieId)
            .IsRequired();
    }
}