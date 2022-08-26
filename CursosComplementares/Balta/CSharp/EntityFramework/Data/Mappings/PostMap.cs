using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            // Chave primária -> Se o banco já existir isso aqui basta
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // PRIMARY KEY IDENTITY(1, 1)

            builder.Property(x => x.LastUpdateDate)
                .IsRequired() // NOT NULL
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()"); // DATETIME NOT NULL DEFAULT(GETDATE())
                                                  // .HasDefaultValue(DateTime.Now.ToUniversalTime());

            // Indices
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique();

            // Relacionamentos
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post => post.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag.HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}