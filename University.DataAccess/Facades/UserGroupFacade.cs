﻿using System.Collections.Generic;
 using System.Linq;
 using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class UserGroupFacade: AbstractFacade<UserGroup> {

        public UserGroupFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<UserGroup> GetAll() {
            return GetContext.UserGroups;
        }

        public override UserGroup Edit(int id, UserGroup value) {
            UserGroup userGroup = GetById(id);
            userGroup.Group = value.Group ?? userGroup.Group;
            userGroup.User = value.User ?? userGroup.User;
            return Update(userGroup);
        }

        public IEnumerable<UserGroup> GetByGroupId(int sourceId) {
            return GetContext.UserGroups.Where(x=> x.Group.Id==sourceId);
        }

        public IEnumerable<Group> GetByUserId(int sourceId, GroupFacade groupFacade) {

            List<Group> groups = new List<Group>();
            
            foreach (var gGroup in GetContext.UserGroups.Where(x=> x.User.Id==sourceId)) 
                groups.Add(groupFacade.GetById(gGroup.GroupId));
            

            return groups;
        }

        public UserGroup GetById(int? id) {
            return GetContext.UserGroups.Find(id);
        }

    }

}