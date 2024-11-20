using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.ModelPet;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration: IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.Species)
            .HasColumnName("species")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(p => p.Breed)
            .HasColumnName("breed")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.Color)
            .HasColumnName("color")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.HealthInfo)
            .HasColumnName("health_info")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.Address)
            .HasColumnName("address")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.Weight)
            .HasColumnName("weight")
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(p => p.Height)
            .HasColumnName("height")
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(p => p.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(p => p.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(p => p.IsCastrated)
            .HasColumnName("is_castrated")
            .HasMaxLength(15)
            .IsRequired();
        
        builder.Property(p => p.DateOfBirth)
            .HasColumnName("date_of_birth")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.IsVaccinated)
            .HasColumnName("is_vaccinated")
            .HasMaxLength(15)
            .IsRequired();
        
        builder.Property(p => p.SupportStatus)
            .HasColumnName("support_status")
            .HasMaxLength(15)
            .IsRequired();

        builder.OwnsMany(p => p.BankRequisites, br =>
        {
            br.ToJson();
            
            br.Property(b => b.NameOfBank)
                .IsRequired();
            br.Property(b => b.BankIdentificationCode)
                .IsRequired();
            br.Property(b => b.CorrespondentAccount)
                .IsRequired();
        });
        
        builder.Property(p => p.DateOfCreated)
            .HasColumnName("date_of_created")
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsMany(p => p.PetPhotos, pf =>
        {
            pf.ToJson();
            
            pf.Property(ph => ph.Path)
                .IsRequired();
            
            pf.Property(imp => imp.IsMainPhoto)
                .IsRequired();
        });
    }
}