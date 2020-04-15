using System;
using System.Linq;
using GraphQL.Types;
using University.DataAccess.Facades;
using University.Database.Models;
using University.Types.GroupSubject;
using University.Types.Mark;
using University.Types.User;

namespace University.Mutations {
    public class Mutations : ObjectGraphType {
        private void AddMarkMutations(MarkFacade markFacade) {
            // Field<MarkType>("addMark",
            //     arguments: new QueryArguments(
            //         new QueryArgument<NonNullGraphType<MarkInputType>> {Name = "mark"}),
            //     resolve: context => {
            //         var mark = context.GetArgument<Mark>("mark");    
            //         return markFacade.Add(mark);
            //     }
            // );
            //
            // Field<MarkType>("deleteMark",
            //     arguments: new QueryArguments(
            //         new QueryArgument<IntGraphType> {Name = "id"}),
            //     resolve: context => {
            //         var mark = markFacade.GetById(context.GetArgument<int>("id"));
            //         return markFacade.Delete(mark);
            //     }
            // );
            //
            // Field<MarkType>("editMark",
            //     arguments: new QueryArguments(
            //         new QueryArgument<MarkInputType> {Name = "mark"},
            //         new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id"}),
            //     resolve: context => {
            //         var id = context.GetArgument<int>("id");
            //         var mark = context.GetArgument<Mark>("mark");
            //         return markFacade.Edit(id, mark);
            //     }
            // );
        }

        private void AddUserMutations(UserFacade userFacade, UserRoleFacade userRoleFacade,
            UserGroupFacade userGroupFacade, GroupFacade groupFacade) {
            User ParseUser(User user) {
                user.UserRole = userRoleFacade.GetAll().SingleOrDefault(x => x.RoleName == "Student");
                return user;
            }

            Field<UserType>("addUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "userId"},
                    new QueryArgument<NonNullGraphType<UserInputType>> {Name = "user"}),
                resolve: context => {
                    userFacade.Validate(context.GetArgument<int>("userId"));
                    var user = ParseUser(context.GetArgument<User>("user"));
                    var groupId = context.GetArgument<int>("groupId");
                    if (user.FirstName == null || user.LastName == null || user.Login == null ||
                        user.Password == null) {
                        throw new ArgumentException();
                    }

                    if (userFacade.GetByLogin(user.Login) != null) {
                        return null;
                    }

                    user = userFacade.Add(user);

                    UserGroup userGroup = new UserGroup {User = user, Group = groupFacade.GetById(groupId)};

                    userGroupFacade.Add(userGroup);

                    return user;
                }
            );

            Field<UserType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "userId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "deleteId"}),
                resolve: context => {
                    userFacade.Validate(context.GetArgument<int>("userId"));
                    var deleteId = userFacade.GetById(context.GetArgument<int>("deleteId"));
                    return userFacade.Delete(deleteId);
                }
            );

            Field<UserType>("editUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "userId"},
                    new QueryArgument<NonNullGraphType<UserInputType>> {Name = "user"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "editId"}),
                resolve: context => {
                    userFacade.Validate(context.GetArgument<int>("userId"));
                    var editId = context.GetArgument<int>("editId");
                    var user = ParseUser(context.GetArgument<User>("user"));
                    return userFacade.Edit(editId, user);
                }
            );
        }

        private void AddGroupMutations(GroupFacade groupFacade) { }

        private void AddGroupSubjectMutations(GroupSubjectFacade groupSubjectFacade, UserFacade userFacade) {
            Field<GroupSubjectType>("addGroupSubject",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "userId"},
                    new QueryArgument<NonNullGraphType<GroupSubjectInputType>> {Name = "groupSubject"}),
                resolve: context => {
                    userFacade.Validate(context.GetArgument<int>("userId"));
                    var group = context.GetArgument<GroupSubject>("groupSubject");
                    return  groupSubjectFacade.Add(group);
                }
            );
            
            Field<GroupSubjectType>("deleteGroupSubject",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupSubjectId"}),
                resolve: context => {
                    var groupSubjectId = context.GetArgument<int>("groupSubjectId");
                    return   groupSubjectFacade.Delete(groupSubjectFacade.GetById(groupSubjectId));
                }
            );
        }

        private void AddNotificationMutations(NotificationFacade notificationFacade) { }

        private void AddNotificationStudentMutations(NotificationStudentFacade notificationStudentFacade) { }

        private void AddSubjectMutations(SubjectFacade subjectFacade) { }

        private void AddUserGroupMutations(UserGroupFacade userGroupFacade) { }

        private void AddUserMarkMutations(UserMarkFacade userMarkFacade) { }

        private void AddUserRoleMutations(UserRoleFacade userRoleFacade) { }

        public Mutations(MarkFacade markFacade, UserFacade userFacade, GroupFacade groupFacade,
            GroupSubjectFacade groupSubjectFacade, NotificationFacade notificationFacade,
            NotificationStudentFacade notificationStudentFacade, SubjectFacade subjectFacade,
            UserGroupFacade userGroupFacade, UserMarkFacade userMarkFacade, UserRoleFacade userRoleFacade) {
            AddMarkMutations(markFacade);

            AddUserMutations(userFacade, userRoleFacade, userGroupFacade, groupFacade);

            AddGroupMutations(groupFacade);

            AddGroupSubjectMutations(groupSubjectFacade, userFacade);

            AddNotificationMutations(notificationFacade);

            AddNotificationStudentMutations(notificationStudentFacade);

            AddSubjectMutations(subjectFacade);

            AddUserGroupMutations(userGroupFacade);

            AddUserMarkMutations(userMarkFacade);

            AddUserRoleMutations(userRoleFacade);
        }
    }
}