using System.Collections.Generic;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class NotificationFacade: AbstractFacade<Notification> {

        public NotificationFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<Notification> GetAll() {
            return GetContext.Notifications;
        }

    }

}