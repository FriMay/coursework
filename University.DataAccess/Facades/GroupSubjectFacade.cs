﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class GroupSubjectFacade : AbstractFacade<GroupSubject> {

        public GroupSubjectFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<GroupSubject> GetAll() {
            return GetContext.GroupSubjects;
        }

        public override GroupSubject Edit(int id, GroupSubject value) {
            GroupSubject groupSubject = GetById(id);
            groupSubject.Subject = value.Subject ?? groupSubject.Subject;
            groupSubject.Teacher = value.Teacher ?? groupSubject.Teacher;
            groupSubject.Group = value.Group ?? groupSubject.Group;
            groupSubject.OrderNumber = value.OrderNumber ?? groupSubject.OrderNumber;
            groupSubject.DayOfWeek = value.DayOfWeek ?? groupSubject.DayOfWeek;

            return Update(groupSubject);
        }

        public IEnumerable<GroupSubject> GetByGroupId(int sourceId) {
            return GetContext.GroupSubjects.Where(x => x.Group.Id == (sourceId));
        }

        public IEnumerable<GroupSubject> GetBySubjectId(int sourceId) {
            return GetContext.GroupSubjects.Where(x => x.Subject.Id == (sourceId));
        }


        public GroupSubject GetById(int? id) {
            return GetContext.GroupSubjects.Find(id);
        }

        public IQueryable<GroupSubject> GetByDayAndGroup(int groupId, int dayOfWeek) {
            return GetContext.GroupSubjects.Where(x => x.GroupId == groupId && x.DayOfWeek == dayOfWeek);
        }

        public GroupSubject GetByDayAndOrderAndTeacher(int dayOfWeek, int orderNumber, int teacher) {
            return GetContext.GroupSubjects.SingleOrDefault(x =>
                x.DayOfWeek == dayOfWeek && x.OrderNumber == orderNumber && x.TeacherId == teacher);
        }

        public IEnumerable<Group> GetByTeacherId(int teacherId, GroupFacade groupFacade) {
            List<Group> groups = new List<Group>();


            foreach
            (GroupSubject gGroup
                in GetContext.GroupSubjects
                    .Where(x => x.TeacherId == teacherId)
                    .AsEnumerable()
                    .Distinct((a, b) => a.GroupId == b.GroupId))
                groups.Add(groupFacade.GetById(gGroup.GroupId));


            return groups;
        }

        public IEnumerable<GroupSubject> GetScheduleByTeacherId(int teacherId) {
            return GetContext.GroupSubjects.Where(x => x.TeacherId == teacherId);
        }

    }

}