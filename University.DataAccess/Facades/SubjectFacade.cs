using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class SubjectFacade: AbstractFacade<Subject> {

        public SubjectFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<Subject> GetAll() {
            return GetContext.Subjects;
        }

        public Subject GetById(int? id) {
            if (id == null) {
                return null;
            }
            return GetContext.Subjects.Find(id);
        }

    }

}