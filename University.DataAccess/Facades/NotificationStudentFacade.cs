using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class NotificationStudentFacade: AbstractFacade<NotificationStudent> {

        public NotificationStudentFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<NotificationStudent> GetAll() {
            return GetContext.NotificationStudents;
        }

    }

}