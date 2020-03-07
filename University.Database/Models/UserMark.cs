﻿﻿using System;

namespace University.Database.Models {

    public class UserMark {

        public int Id { get; set; }

        public DateTime IssueData { get; set; }
        
        public int? MarkId { get; set; }

        public int? StudentId { get; set; }

        public int? GroupSubjectId { get; set; }


        public Mark Mark { get; set; }

        public User Student { get; set; }

        public GroupSubject GroupSubject { get; set; }

    }

}