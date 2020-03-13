using System.Collections.Generic;
using System.Linq;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class GroupFacade: AbstractFacade<Group> {

        public GroupFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<Group> GetAll() {
            return GetContext.Groups;
        }

        public Group GetById(int? id) {
            return GetContext.Groups.Find(id);
        }

    }

}