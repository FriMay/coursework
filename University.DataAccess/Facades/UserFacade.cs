using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class UserFacade: AbstractFacade<User> {

        public UserFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<User> GetAll() {
            return GetContext.Users;
        }

    }

}