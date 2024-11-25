using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models.ModelVolunteer;
using PetFamily.Domain.Models.ModelVolunteer.ValueObjects;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasColumnOrder(1)
            .HasConversion(
                id => id.Id,
                id => VolunteerId.Create(id))
            .IsRequired();
        
        builder.OwnsOne(v => v.FIO, fo =>
        {
            fo.ToJson();

            fo.Property(fio => fio.Name)
                .HasMaxLength(50)
                .IsRequired();
            fo.Property(fio => fio.MiddleName)
                .HasMaxLength(50)
                .IsRequired();
            fo.Property(fio => fio.SurName)
                .HasMaxLength(50)
                .IsRequired();
        });
        
        builder.Property(v => v.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(v => v.Description)
            .HasColumnName("description")
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(v => v.WorkExperience)
            .HasColumnName("work_experience")
            .IsRequired();
        
        builder.Property(v => v.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsMany(v => v.SocialNetwork, sn =>
        {
            sn.ToJson();
            
            sn.Property(soc => soc.Title)
                .HasMaxLength(50)
                .IsRequired();
            sn.Property(soc => soc.Link)
                .HasMaxLength(50)
                .IsRequired();
        });
        
        builder.OwnsMany(v => v.BankRequisites, br =>
        {
            br.ToJson();
            
            br.Property(b => b.NameOfBank)
                .IsRequired();
            br.Property(b => b.BankIdentificationCode)
                .IsRequired();
            br.Property(b => b.CorrespondentAccount)
                .IsRequired();
        });
        
        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}