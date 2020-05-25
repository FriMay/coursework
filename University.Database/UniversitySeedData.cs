using System.Collections.Generic;
using System.Linq;
using University.Database.Models;

namespace University.Database {

    public static class UniversitySeedData {

        public static void EnsureSeedData(this UniversityContext db) {
            if (!db.Marks.Any()) {
                var marks = new List<Mark> {
                    new Mark {
                        MarkValue = "Отсутствовал"
                    },
                    new Mark {
                        MarkValue = "Присутствовал"
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
                        RoleName = "Студент"
                    },
                    new UserRole {
                        RoleName = "Преподаватель"
                    },
                    new UserRole {
                        RoleName = "Куратор"
                    }
                };
                var firstGroup = new Group {
                    Name = "18ВП1"
                };
                var secondGroup = new Group {
                    Name = "18ВП2"
                };
                
                var subjects = new List<Subject> {
                    new Subject {
                        SubjectName = "Объектно-ориентированное программирование"
                    },
                    new Subject {
                        SubjectName = "Дискретная математика"
                    },
                    new Subject {
                        SubjectName = "Английский язык"
                    }
                };
                var users = new List<User> {
                    new User {
                        FirstName = "Владислав",
                        SecondName = "Евгеньвич",
                        LastName = "Бирюков",
                        Login = "biryukov",
                        Password = "vladislav",
                        UserRole = userRoles[0]
                    },
                    new User {
                        FirstName = "Александр",
                        SecondName = "Юрьевич",
                        LastName = "Афонин",
                        Login = "afonin",
                        Password = "alexandr",
                        UserRole = userRoles[1]
                    },
                    new User {
                        FirstName = "Антон",
                        SecondName = "Геннадьевич",
                        LastName = "Иванчуков",
                        Login = "ivanchukov",
                        Password = "anton",
                        UserRole = userRoles[1]
                    },
                    new User {
                        FirstName = "Елена",
                        SecondName = "Николаевна",
                        LastName = "Прошкина",
                        Login = "proshkina",
                        Password = "elena",
                        UserRole = userRoles[2]
                    }
                };
                var userGroups = new List<UserGroup> {
                    new UserGroup {
                        User = users[0],
                        Group = firstGroup
                    },
                    new UserGroup {
                        User = users[1],
                        Group = firstGroup
                    },
                    new UserGroup {
                        User = users[1],
                        Group = secondGroup
                    },
                    new UserGroup {
                        User = users[2],
                        Group = secondGroup
                    },
                    new UserGroup {
                        User = users[2],
                        Group = firstGroup
                    },
                    new UserGroup {
                        User = users[3],
                        Group = firstGroup
                    },
                    new UserGroup {
                        User = users[3],
                        Group = secondGroup
                    }
                };

                db.Subjects.AddRange(subjects);
                db.Groups.Add(firstGroup);
                db.Groups.Add(secondGroup);
                db.Users.AddRange(users);
                db.UserGroups.AddRange(userGroups);
                db.Marks.AddRange(marks);
                db.UserRoles.AddRange(userRoles);

                db.SaveChanges();
            }
        }

    }

}