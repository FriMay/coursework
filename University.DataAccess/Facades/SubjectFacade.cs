using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class SubjectFacade : AbstractFacade<Subject> {

        public SubjectFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<Subject> GetAll() {
            return GetContext.Subjects;
        }

        public override Subject Edit(int id, Subject value) {
            Subject subject = GetById(id);
            subject.SubjectName = value.SubjectName ?? subject.SubjectName;

            return Update(subject);
        }

        public Subject GetById(int? id) {
            return GetContext.Subjects.Find(id);
        }

    }

}