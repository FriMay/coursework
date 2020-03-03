using System.Collections.Generic;

namespace University.Database.Models {

    public class User {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public UserRole UserRole { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public ICollection<NotificationStudent> NotificationStudents { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }

        public ICollection<GroupSubject> GroupSubjects { get; set; }

        public ICollection<UserMark> UserMarks { get; set; }

    }

}