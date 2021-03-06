﻿﻿using System.Collections.Generic;
 using System.Linq;
 using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class NotificationFacade: AbstractFacade<Notification> {

        public NotificationFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<Notification> GetAll() {
            return GetContext.Notifications;
        }

        public override Notification Edit(int id, Notification value) {
            Notification notification = GetById(id);
            notification.Group = value.Group ?? notification.Group;
            notification.Message = value.Message ?? notification.Message;
            
            return Update(notification);
        }

        public IEnumerable<Notification> GetByGroupId(int sourceId) {
            return GetContext.Notifications.Where(x=> x.Group.Id==sourceId);
        }

        public Notification GetById(int? id) {
            return GetContext.Notifications.Find(id);
        }

    }

}