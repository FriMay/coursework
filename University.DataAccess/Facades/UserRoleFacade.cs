using System.Collections.Generic;
using System.Linq;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class UserRoleFacade : AbstractFacade<UserRole> {

        public UserRoleFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<UserRole> GetAll() {
            return GetContext.UserRoles;
        }

        public override UserRole Edit(int id, UserRole value) {
            UserRole userRole = GetById(id);
            userRole.RoleName = value.RoleName ?? userRole.RoleName;
            return Update(userRole);
        }

        public UserRole GetById(int? id) {
            return GetContext.UserRoles.Find(id);
        }

        public UserRole GetByName(string roleName) {
            return GetContext.UserRoles.SingleOrDefault(x => x.RoleName == roleName);
        }

    }

}