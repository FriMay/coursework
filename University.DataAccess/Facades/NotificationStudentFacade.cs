﻿using System.Collections.Generic;
 using System.Linq;
 using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class NotificationStudentFacade: AbstractFacade<NotificationStudent> {

        public NotificationStudentFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<NotificationStudent> GetAll() {
            return GetContext.NotificationStudents;
        }

        public override NotificationStudent Edit(int id, NotificationStudent value) {
            NotificationStudent notificationStudent = GetById(id);
            notificationStudent.Notification = value.Notification ?? notificationStudent.Notification;
            notificationStudent.Student = value.Student ?? notificationStudent.Student;
            
            return Update(notificationStudent);
        }

        public IEnumerable<NotificationStudent> GetByNotificationId(int sourceId) {
            return GetContext.NotificationStudents.Where(x => x.Notification.Id==(sourceId));
        }

        public IEnumerable<NotificationStudent> GetByUserId(int sourceId) {
            return GetContext.NotificationStudents.Where(x => x.Student.Id==(sourceId));
        }

        public NotificationStudent GetById(int? id) {
            return GetContext.NotificationStudents.Find(id);
        }

        public void DeleteByNotification(Notification notification) {
            DeleteRange(GetContext.NotificationStudents.Where(x=> x.NotificationId==notification.Id));
        }

    }

}