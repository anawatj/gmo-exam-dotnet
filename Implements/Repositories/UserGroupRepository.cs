using Core.Domains;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private ApplicationDbContext db;
        public UserGroupRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public UserGroup Create(UserGroup entity)
        {
            db.UserGroups.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var userGroup = db.UserGroups.Where(t => t.Id == id).First<UserGroup>();
            db.UserGroups.Remove(userGroup);
        }

        public IList<UserGroup> GetAll()
        {
            return db.UserGroups.ToList<UserGroup>();
        }

        public UserGroup GetByID(int id)
        {
            return db.UserGroups.Where(t => t.Id == id).First<UserGroup>();
        }

        public UserGroup Update(UserGroup entity, int id)
        {
            var userGroup = db.UserGroups.Where(t => t.Id == id).First<UserGroup>();
            userGroup.UserGroupName = entity.UserGroupName;
            db.UserGroups.Update(userGroup);
            return userGroup;
        }
    }
}
