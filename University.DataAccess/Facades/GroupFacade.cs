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

        public override Group Edit(int id, Group value) {
            Group group = GetById(id);
            group.Name = value.Name ?? group.Name;
            return Update(group);
        }

        public Group GetById(int? id) {
            return GetContext.Groups.Find(id);
        }

    }

}