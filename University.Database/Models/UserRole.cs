﻿using System;
using System.Collections.Generic;

namespace University.Database.Models {

    public class UserRole {

        public int Id { get; set; }

        public String RoleName { get; set; }

        public ICollection<User> Users { get; set; }

    }

}