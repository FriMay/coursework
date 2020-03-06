﻿using System.Collections.Generic;
 using System.Linq;
 using University.Database.Models;

 namespace University.Database {

    public static class UniversitySeedData {

        public static void EnsureSeedData(this UniversityContext db) {
            if (!db.Marks.Any()) {
                var marks = new List<Mark> {
                    new Mark {
                        MarkValue = "Absented"
                    },
                    new Mark {
                        MarkValue = "0"
                    },
                    new Mark {
                        MarkValue = "1"
                    },
                    new Mark {
                        MarkValue = "2"
                    },
                    new Mark {
                        MarkValue = "3"
                    },
                    new Mark {
                        MarkValue = "4"
                    },
                    new Mark {
                        MarkValue = "5"
                    }
                };
                var userRoles = new List<UserRole> {
                    new UserRole {
                        RoleName = "Teacher"
                    },
                    new UserRole {
                        RoleName = "Student"
                    },
                    new UserRole {
                        RoleName = "Curator"
                    }
                };
                var group = new Group {
                    Name = "18VP1"
                };
                var subjects = new List<Subject> {
                    new Subject {
                        SubjectName = "Geometry"
                    },
                    new Subject {
                        SubjectName = "Programming"
                    },
                    new Subject {
                        SubjectName = "English language"
                    }
                };
                var users = new List<User> {
                    new User {
                        FirstName = "Oleg",
                        Login = "Lala",
                        Password = "Lala",
                        UserRole = userRoles[0]
                    },
                    new User {
                        FirstName = "Vasya",
                        Login = "Lal",
                        Password = "Lal",
                        UserRole = userRoles[1]
                    },
                    new User {
                        FirstName = "Petya",
                        Login = "La",
                        Password = "La",
                        UserRole = userRoles[2]
                    }
                };
                var userGroups = new List<UserGroup> {
                    new UserGroup {
                        User = users[0],
                        Group = group
                    },
                    new UserGroup {
                        User = users[1],
                        Group = group
                    },
                    new UserGroup {
                        User = users[2],
                        Group = group
                    }
                };
                var groupSubjects = new List<GroupSubject> {
                    new GroupSubject {
                        DayOfWeek = 1,
                        Group = group,
                        OrderNumber = 1,
                        Subject = subjects[0],
                        Teacher = users[0]
                    },
                    new GroupSubject {
                        DayOfWeek = 2,
                        Group = group,
                        OrderNumber = 1,
                        Subject = subjects[1],
                        Teacher = users[0]
                    },
                    new GroupSubject {
                        DayOfWeek = 3,
                        Group = group,
                        OrderNumber = 1,
                        Subject = subjects[2],
                        Teacher = users[0]
                    }
                };
                
                db.Subjects.AddRange(subjects);
                db.Groups.Add(group);
                db.Users.AddRange(users);
                db.UserGroups.AddRange(userGroups);
                db.GroupSubjects.AddRange(groupSubjects);
                db.Marks.AddRange(marks);
                db.UserRoles.AddRange(userRoles);
                
                db.SaveChanges();
            }
        }
        
        

    }

}