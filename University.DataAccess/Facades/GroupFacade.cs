using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class GroupFacade: AbstractFacade<Group> {

        public GroupFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<Group> GetAll() {
            return GetContext.Groups;
        }

    }

}