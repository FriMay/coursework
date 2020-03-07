﻿﻿using System.Collections.Generic;

  namespace University.Database.Models {

    public class GroupSubject {

        public int Id { get; set; }

        public int? DayOfWeek { get; set; }

        public int? OrderNumber { get; set; }

        public int? SubjectId { get; set; }

        public int? TeacherId { get; set; }
        
        public int? GroupId { get; set; }
        
        public Subject Subject { get; set; }

        public User Teacher { get; set; }

        public Group Group { get; set; }

        public ICollection<UserMark> UserMarks { get; set; }

    }

}