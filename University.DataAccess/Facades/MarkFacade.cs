using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class MarkFacade: AbstractFacade<Mark> {

        public MarkFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<Mark> GetAll() {
            return GetContext.Marks;
        }

        public Mark GetById(int? id) {
            return GetContext.Marks.Find(id);
        }

        public Mark Edit(int editMark, Mark editValues) {
            Mark mark = GetById(editMark);
            mark.MarkValue = editValues.MarkValue;
            Update(mark);
            return mark;
        }

    }

}