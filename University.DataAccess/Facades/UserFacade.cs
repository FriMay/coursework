using System.Collections.Generic;
using System.Linq;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class UserFacade: AbstractFacade<User> {

        public UserFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<User> GetAll() {
            return GetContext.Users;
        }

        public IEnumerable<User> GetByUserRoleId(int sourceId) {
            return GetContext.Users.Where(x=> x.UserRole.Id==sourceId);
        }

        public User GetById(int? id) {
            if (id == null) {
                return null;
            }
            return GetContext.Users.Find(id);
        }

    }

}