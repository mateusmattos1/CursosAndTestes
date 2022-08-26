using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            // Tabela
            builder.ToTable("User");

            // Chave primária -> Se o banco já existir isso aqui basta
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // PRIMARY KEY IDENTITY(1, 1)

            builder.Property(x => x.Name)
                .IsRequired() // NOT NULL
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Bio);
            builder.Property(x => x.Email);
            builder.Property(x => x.Image);
            builder.Property(x => x.PasswordHash);
            builder.Property(x => x.GitHub);

            // Indices
            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();

            builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    role => role.HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRole_RoleId")
                        .OnDelete(DeleteBehavior.Cascade),
                    user => user.HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRole_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}