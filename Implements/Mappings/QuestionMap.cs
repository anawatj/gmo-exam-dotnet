using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Implements.Mappings
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.QuestionDesc);
            builder.HasMany<Answer>(t => t.Answers).WithOne(t => t.Question).HasForeignKey(t => t.QuestionID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
