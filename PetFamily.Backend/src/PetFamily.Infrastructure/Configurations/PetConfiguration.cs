using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.ModelPet;
using PetFamily.Domain.Models.ModelPet.ValueObjects;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasConversion(
                id => id.Id,
                id => new PetId(id))
            .IsRequired();
        
        builder.ComplexProperty(p => p.NameShare, pn =>
            {
                pn.Property(n => n.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsRequired();
            });
        
        builder.Property(p => p.Species)
            .HasColumnName("species")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.ComplexProperty(p => p.Description, pd =>
        {
            pd.Property(d => d.Description)
                .HasColumnName("description")
                .HasMaxLength(250)
                .IsRequired();
        });
        
        builder.Property(p => p.Breed)
            .HasColumnName("breed")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.ComplexProperty(p => p.Color, pc =>
        {
            pc.Property(c => c.Color)
                .HasColumnName("color")
                .HasMaxLength(50)
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.HealthInfo, ph =>
        {
            ph.Property(h => h.HealthInfo)
                .HasColumnName("health_info")
                .HasMaxLength(100)
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Address, pa =>
        {
            pa.Property(c => c.City)
                .HasColumnName("city")
                .HasMaxLength(50)
                .IsRequired();
            
            pa.Property(s => s.Street)
                .HasColumnName("street")
                .HasMaxLength(150)
                .IsRequired();
            
            pa.Property(h => h.HouseNumber)
                .HasColumnName("house_number")
                .HasMaxLength(3)
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Weight, pw =>
        {
            pw.Property(w => w.Weight)
                .HasColumnName("weight")
                .HasMaxLength(3)
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Height, ph =>
        {
            ph.Property(h => h.Height)
                .HasColumnName("height")
                .HasMaxLength(3)
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.PhoneNumberNumber, pp =>
        {
            pp.Property(h => h.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(100)
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.IsCastrated, pc =>
        {
            pc.Property(c => c.IsCastrated)
                .HasColumnName("is_castrated")
                .HasMaxLength(15)
                .IsRequired();
        });
        
        builder.Property(p => p.DateOfBirth)
            .HasColumnName("date_of_birth")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.ComplexProperty(p => p.IsVaccinated, pv =>
        {
            pv.Property(v => v.IsVaccinated)
                .HasColumnName("is_vaccinated")
                .HasMaxLength(15)
                .IsRequired();
        }); ;
        
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