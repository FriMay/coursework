using System;
using System.Collections.Generic;
using System.Linq;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {
    public class UserFacade : AbstractFacade<User> {
        public UserFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<User> GetAll() {
            return GetContext.Users;
        }

        public override User Edit(int id, User value) {
            User user = GetById(id);
            user.Login = value.Login ?? user.Login;
            user.Password = value.Password ?? user.Password;
            user.FirstName = value.FirstName ?? user.FirstName;
            user.SecondName = value.SecondName ?? user.SecondName;
            user.LastName = value.LastName ?? user.LastName;
            user.UserRole = value.UserRole ?? user.UserRole;
            return Update(user);
        }

        public IEnumerable<User> GetByUserRoleId(int sourceId) {
            return GetContext.Users.Where(x => x.UserRole.Id == sourceId);
        }

        public User GetById(int? id) {
            return GetContext.Users.Find(id);
        }

        public void Validate(int userId) {
            User user = GetById(userId);
            if (!GetContext.UserRoles.Find(user.UserRoleId).RoleName.Equals("Curator")) {
                throw new MemberAccessException();
            }
        }

        public User Login(string login, string password, Boolean isThrow = true) {
            User user = GetContext.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user == null) {
                return null;
            }

            if (GetContext.UserRoles.Find(user.UserRoleId).RoleName.Equals("Студент") && isThrow) {
                throw new ArgumentException();
            }

            return user;
        }

        public IEnumerable<User> GetStudentsByGroupId(int groupId) {
            IQueryable<UserGroup> userGroups = GetContext.UserGroups.Where(x =>
                x.GroupId.Equals(groupId));
            
            List<User> users = new List<User>();

            foreach (var a in userGroups) {
                users.Add(GetContext.Users.Find(a.UserId));
            }

            return users.Where(x=> GetContext.UserRoles.Find(x.UserRoleId).RoleName == "Студент");
        }

        public User GetByLogin(string userLogin) {
            return GetContext.Users.SingleOrDefault(x => x.Login == userLogin);
        }
    }
}