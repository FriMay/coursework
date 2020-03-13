using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class UserRoleFacade: AbstractFacade<UserRole> {

        public UserRoleFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<UserRole> GetAll() {
            return GetContext.UserRoles;
        }

        public UserRole GetById(int? id) {
            return GetContext.UserRoles.Find(id);
        }

    }

}