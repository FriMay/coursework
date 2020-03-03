﻿﻿using System.Collections.Generic;

  namespace University.Database.Models {

    public class Notification {

        public int Id { get; set; }

        public string Message { get; set; }

        public Group Group { get; set; }

        public ICollection<NotificationStudent> NotificationStudents { get; set; }

    }

}