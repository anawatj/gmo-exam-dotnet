using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Dtos;
using System.Data.Common;

namespace Implements.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public User Create(User entity)
        {
             db.Users.Add(entity);
             return entity;
        }

        public void Delete(int id)
        {
            var user =  db.Users.Where(t => t.Id == id).First<User>();
            db.Users.Remove(user);
        }

        public IList<User> GetAll()
        {
            return db.Users.ToList<User>();
        }

        public User GetByID(int id)
        {
            return db.Users
                .Include("UserGroup")
                .Where(t => t.Id == id).First<User>();
        }

        public User? GetByUserName(string userName)
        {
            return db.Users
                .Where(t => t.UserName.Equals(userName))
                .FirstOrDefault<User>();
        }

        public IList<SummaryDto> SummaryQuestion(string username)
        {
            var sql = @"
                    
                    SELECT 
                        u.UserName,
                        0 as Rank,
                        SUM(a.AnswerScore) as Score 
                    FROM Users u 
                    JOIN UserQuestions uq ON u.Id=uq.UserID
                    JOIN UserQuestionAnswers uqa ON uq.Id = uqa.UserQuestionID
					JOIN Answers a ON uqa.AnswerID = a.Id
                    WHERE u.UserName = @UserName
                    GROUP BY u.UserName
               ";
            var conn = db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            var cmd = conn.CreateCommand();
            var param = cmd.CreateParameter();
            param.ParameterName = "@UserName";
            param.DbType = System.Data.DbType.String;
            param.Direction = System.Data.ParameterDirection.Input;
            param.Value = username;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add(param);
            var reader = cmd.ExecuteReader();

            List<SummaryDto> dtos = new List<SummaryDto>();
            while (reader.Read())
            {
                SummaryDto dto = new SummaryDto();
                dto.UserName = reader.GetString(0);
                dto.Rank = reader.GetInt32(1);
                dto.Score = reader.GetInt32(2);
                dtos.Add(dto);

            }
            reader.Close();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            return dtos;



        }

    

        public User Update(User entity, int id)
        {
            var user = db.Users.Where(t => t.Id == id).First<User>();
            user.UserName = entity.UserName;
            user.UserGroupID = entity.UserGroupID;
            db.Users.Update(user);
            return user;
        }
    }
}
