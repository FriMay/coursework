using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class UserGroupFacade: AbstractFacade<UserGroup> {

        public UserGroupFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<UserGroup> GetAll() {
            return GetContext.UserGroups;
        }

    }

}