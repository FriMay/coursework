using System;
using System.Collections.Generic;

namespace University.Database.Models {

    public class Mark {

        public int Id { get; set; }

        public String MarkValue { get; set; }

        public ICollection<UserMark> UserMarks { get; set; }

    }

}