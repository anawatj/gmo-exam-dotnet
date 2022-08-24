using Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Mappings
{
    public class UserQuestionAnswerMap : IEntityTypeConfiguration<UserQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<UserQuestionAnswer> builder)
        {
            builder.ToTable("UserQuestionAnswers");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.UserQuestionID);
            builder.HasOne<Answer>(t => t.Answer).WithMany(t => t.UserQuestionAnswers).HasForeignKey(t => t.AnswerID);
        }
    }
}
