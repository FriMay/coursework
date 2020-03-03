﻿﻿using System.Collections.Generic;

  namespace University.Database.Models {

    public class Group {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GroupSubject> GroupSubjects { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }

    }

}