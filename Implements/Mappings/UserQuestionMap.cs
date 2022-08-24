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
    public class UserQuestionMap : IEntityTypeConfiguration<UserQuestion>
    {
        public void Configure(EntityTypeBuilder<UserQuestion> builder)
        {
            builder.ToTable("UserQuestions");
            builder.HasKey(t => t.Id);
            builder.HasOne<User>(t => t.User).WithMany(t => t.UserQuestions).HasForeignKey(t => t.UserID);
            builder.HasOne<Question>(t => t.Question).WithMany(t => t.UserQuestions).HasForeignKey(t => t.QuestionID);
            builder.HasMany<UserQuestionAnswer>(t => t.UserQuestionAnswers).WithOne(t => t.UserQuestion).HasForeignKey(t => t.UserQuestionID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
