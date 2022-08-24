using Core.Domains;
using Implements.Mappings;
using Microsoft.EntityFrameworkCore;
namespace Implements
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }


        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<UserQuestion> UserQuestions { get; set; }

        public DbSet<UserQuestionAnswer> UserQuestionAnswers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserGroupMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new AnswerMap());
            modelBuilder.ApplyConfiguration(new UserQuestionMap());
            modelBuilder.ApplyConfiguration(new UserQuestionAnswerMap());

            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup()
                {
                    Id = 1,
                    UserGroupName = "Student LV1"
                },
                new UserGroup()
                {
                    Id = 2,
                    UserGroupName = "Student LV2"
                }
             );
            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id=1,
                    QuestionDesc="Mbti"
                },
                new Question()
                {
                    Id=2,
                    QuestionDesc="Blood Group"
                }
              );

            modelBuilder.Entity<Answer>().HasData(
                new Answer()
                {
                    Id = 1,
                    QuestionID = 1,
                    AnswerDesc = "Infj",
                    AnswerScore = 5
                },
               new Answer()
               {
                   Id = 2,
                   QuestionID = 1,
                   AnswerDesc = "Enfj",
                   AnswerScore = 8
               },
               new Answer()
               {
                   Id = 3,
                   QuestionID = 1,
                   AnswerDesc = "Infp",
                   AnswerScore = 0
               },
               new Answer()
               {
                   Id = 4,
                   QuestionID = 1,
                   AnswerDesc = "Enfp",
                   AnswerScore = 1
               },
               new Answer()
               {
                   Id = 5,
                   QuestionID = 2,
                   AnswerDesc = "A",
                   AnswerScore = 5
               },
               new Answer()
               {
                   Id = 6,
                   QuestionID = 2,
                   AnswerDesc = "B",
                   AnswerScore = 8
               },
               new Answer()
               {
                   Id = 7,
                   QuestionID = 2,
                   AnswerDesc = "O",
                   AnswerScore = 0
               },
               new Answer()
               {
                   Id = 8,
                   QuestionID = 2,
                   AnswerDesc = "AB",
                   AnswerScore = 1
               }
             );

        }
    }
}
