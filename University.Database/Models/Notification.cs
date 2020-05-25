using System;
using System.Collections.Generic;

namespace University.Database.Models {

    public class Notification {

        public int Id { get; set; }

        public String Message { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }

        public ICollection<NotificationStudent> NotificationStudents { get; set; }

    }

}