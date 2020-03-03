using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class GroupSubjectFacade: AbstractFacade<GroupSubject> {

        public GroupSubjectFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<GroupSubject> GetAll() {
            return GetContext.GroupSubjects;
        }

    }

}