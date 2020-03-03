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
                
                db.Marks.AddRange(marks);
                db.SaveChanges();
            }
        }
        
        

    }

}