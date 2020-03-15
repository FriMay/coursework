using System;
using System.Collections.Generic;

namespace University.Database.Models {

    public class Subject {

        public int Id { get; set; }

        public String SubjectName { get; set; }

        public ICollection<GroupSubject> GroupSubjects { get; set; }

    }

}