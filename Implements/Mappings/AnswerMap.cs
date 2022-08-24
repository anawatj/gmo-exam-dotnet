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
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.QuestionID);
            builder.Property(t => t.AnswerDesc).HasMaxLength(200);
            builder.Property(t => t.AnswerScore);

        }
    }
}
