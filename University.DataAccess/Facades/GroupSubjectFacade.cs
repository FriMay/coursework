﻿using System.Collections.Generic;
 using System.Linq;
 using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class GroupSubjectFacade: AbstractFacade<GroupSubject> {

        public GroupSubjectFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<GroupSubject> GetAll() {
            return GetContext.GroupSubjects;
        }

        public IEnumerable<GroupSubject> GetByGroupId(int sourceId) {
            return GetContext.GroupSubjects.Where(x=> x.Group.Id==(sourceId));
        }

        public IEnumerable<GroupSubject> GetBySubjectId(int sourceId) {
            return GetContext.GroupSubjects.Where(x=> x.Subject.Id==(sourceId));
        }


        public GroupSubject GetById(int id) {
            return GetContext.GroupSubjects.Find(id);
        }

    }

}