using System;
using System.Collections.Generic;

namespace University.Database.Models {

    public class User {

        public int Id { get; set; }

        public String FirstName { get; set; }

        public String SecondName { get; set; }

        public String LastName { get; set; }

        public UserRole UserRole { get; set; }

        public int? UserRoleId { get; set; }

        public String Login { get; set; }

        public String Password { get; set; }

        public ICollection<NotificationStudent> NotificationStudents { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }

        public ICollection<GroupSubject> GroupSubjects { get; set; }

        public ICollection<UserMark> UserMarks { get; set; }

    }

}