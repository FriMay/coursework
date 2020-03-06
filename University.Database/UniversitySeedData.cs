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
                    new UserRole() {
                        RoleName = "Teacher"
                    },
                    new UserRole() {
                        RoleName = "Student"
                    },
                    new UserRole() {
                        RoleName = "Curator"
                    }
                };
                var groups = new List<Group> {
                    new Group {Name = "18VP1"}
                };
                var subjects = new List<Subject> {
                    new Subject() {
                        SubjectName = "Geometry"
                    },
                    new Subject() {
                        SubjectName = "Programming"
                    },
                    new Subject() {
                        SubjectName = "English language"
                    }
                };
                db.Marks.AddRange(marks);
                db.UserRoles.AddRange(userRoles);
                db.Groups.AddRange(groups);
                db.Subjects.AddRange(subjects);
                db.SaveChanges();
            }
        }
        
        

    }

}