using GraphQL.Types;
using University.DataAccess.Facades;
using University.Database.Models;
using University.Types.Mark;

namespace University.Mutations {

    public class Mutations : ObjectGraphType {
        
        private void AddMarkMutations(MarkFacade markFacade) {
            Field<MarkType>("addMark",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MarkInputType>> {Name = "mark"}),
                resolve: context => {
                    var mark = context.GetArgument<Mark>("mark");    
                    return markFacade.Add(mark);
                }
            );
            
            Field<MarkType>("deleteMark",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var mark = markFacade.GetById(context.GetArgument<int>("id"));
                    return markFacade.Delete(mark);
                }
            );
            
            Field<MarkType>("editMark",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MarkInputType>> {Name = "mark"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int>("id");
                    var mark = context.GetArgument<Mark>("mark");
                    return markFacade.Edit(id, mark);
                }
            );
        }

        private void AddUserMutations(UserFacade userFacade) {
            
        }

        private void AddGroupMutations(GroupFacade groupFacade) {
            
        }

        private void AddGroupSubjectMutations(GroupSubjectFacade groupSubjectFacade) {
            
        }

        private void AddNotificationMutations(NotificationFacade notificationFacade) {
            
        }

        private void AddNotificationStudentMutations(NotificationStudentFacade notificationStudentFacade) {
            
        }

        private void AddSubjectMutations(SubjectFacade subjectFacade) {
            
        }

        private void AddUserGroupMutations(UserGroupFacade userGroupFacade) {
            
        }

        private void AddUserMarkMutations(UserMarkFacade userMarkFacade) {
            
        }

        private void AddUserRoleMutations(UserRoleFacade userRoleFacade) {
            
        }

        public Mutations(MarkFacade markFacade, UserFacade userFacade, GroupFacade groupFacade,
            GroupSubjectFacade groupSubjectFacade, NotificationFacade notificationFacade,
            NotificationStudentFacade notificationStudentFacade, SubjectFacade subjectFacade,
            UserGroupFacade userGroupFacade, UserMarkFacade userMarkFacade, UserRoleFacade userRoleFacade) {
            AddMarkMutations(markFacade);

            AddUserMutations(userFacade);

            AddGroupMutations(groupFacade);

            AddGroupSubjectMutations(groupSubjectFacade);

            AddNotificationMutations(notificationFacade);

            AddNotificationStudentMutations(notificationStudentFacade);

            AddSubjectMutations(subjectFacade);

            AddUserGroupMutations(userGroupFacade);

            AddUserMarkMutations(userMarkFacade);

            AddUserRoleMutations(userRoleFacade);
        }

    }

}