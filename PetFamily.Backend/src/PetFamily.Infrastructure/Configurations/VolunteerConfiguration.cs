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
                id => new VolunteerId(id))
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
        
        builder.ComplexProperty(v => v.Email, vd =>
        {
            vd.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();
        });
        
        builder.ComplexProperty(v => v.Description, vd =>
        {
            vd.Property(d => d.Description)
                .HasColumnName("description")
                .HasMaxLength(250)
                .IsRequired();
        });
        
        builder.ComplexProperty(v => v.WorkExperience, vd =>
        {
            vd.Property(w => w.WorkExperience)
                .HasColumnName("work_experience")
                .HasMaxLength(250)
                .IsRequired();
        });
        
        builder.ComplexProperty(v => v.PhoneNumber, vd =>
        {
            vd.Property(p => p.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(250)
                .IsRequired();
        });
        
        builder.OwnsOne(p => p.SocialNetwork, psn =>
        {
            psn.ToJson("social_network");
            psn.OwnsMany(p => p.SocialNetworks, pb =>
            {
                pb.Property(r => r.Title)
                    .IsRequired();
                
                pb.Property(r => r.Link)
                    .IsRequired();
            });
        });
        
        builder.OwnsOne(p => p.BankRequisites, pbr =>
        {
            pbr.ToJson("bank_requisites");
            pbr.OwnsMany(p => p.BankRequisites, pb =>
            {
                pb.Property(r => r.NameOfBank)
                    .IsRequired();
                
                pb.Property(r => r.CorrespondentAccount)
                    .IsRequired();
                
                pb.Property(r => r.BankIdentificationCode)
                    .IsRequired();
            });
        });
        
        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}