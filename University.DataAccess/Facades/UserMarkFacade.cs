using System;
using System.Collections.Generic;
using System.Linq;
using University.Database;
using University.Database.Models;

namespace University.DataAccess.Facades {

    public class UserMarkFacade : AbstractFacade<UserMark> {

        public UserMarkFacade(UniversityContext context)
            : base(context) { }

        public override IEnumerable<UserMark> GetAll() {
            return GetContext.UserMarks;
        }

        public override UserMark Edit(int id, UserMark value) {
            UserMark userMark = GetById(id);
            userMark.Mark = value.Mark ?? userMark.Mark;
            userMark.IssueData = value.IssueData ?? userMark.IssueData;
            userMark.Student = value.Student ?? userMark.Student;
            return Update(userMark);
        }

        public IEnumerable<UserMark> GetByMarkId(int sourceId) {
            return GetContext.UserMarks.Where(x => x.Mark.Id == sourceId);
        }

        public IEnumerable<UserMark> GetByGroupSubjectId(int sourceId) {
            return GetContext.UserMarks.Where(x => x.GroupSubject.Id == sourceId);
        }

        public IEnumerable<UserMark> GetByUserId(int sourceId) {
            return GetContext.UserMarks.Where(x => x.Student.Id == sourceId);
        }

        public UserMark GetById(int? id) {
            return GetContext.UserMarks.Find(id);
        }

        public IEnumerable<UserMark> GetByGroupSubjectAndIssueDate(int groupSubjectId, DateTime leftDate,
            DateTime rightDate) {
            return GetContext.UserMarks.Where(x =>
                x.GroupSubjectId == groupSubjectId && x.IssueData > leftDate && x.IssueData < rightDate);
        }

        public IEnumerable<UserMark> GetByGroupSubjectAndStudentId(int groupSubjectId, int studentId) {
            return GetContext.UserMarks.Where(x => x.GroupSubjectId == groupSubjectId && x.StudentId == studentId)
                .OrderBy(x => x.IssueData);
        }

        public UserMark GetByUserMarkInputType(UserMark mark, DateTime leftDate, DateTime rightDate) {
            return GetContext.UserMarks.SingleOrDefault(x =>
                x.StudentId == mark.StudentId && x.GroupSubjectId == mark.GroupSubjectId &&
                x.IssueData > leftDate && x.IssueData < rightDate);
        }

    }

}