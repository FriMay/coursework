using System;
using GraphQL.Types;
using University.DataAccess.Facades;
using University.Database.Models;
using University.Types;
using University.Types.Group;
using University.Types.GroupSubject;
using University.Types.Mark;
using University.Types.Notification;
using University.Types.NotificationStudent;
using University.Types.Subject;
using University.Types.User;
using University.Types.UserGroup;
using University.Types.UserMark;
using University.Types.UserRole;

namespace University.Queries {

    public class Queries : ObjectGraphType {

        private void AddMarkQueries(MarkFacade markFacade) {
            Field<MarkType>("mark",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (markFacade.GetById((int) id)) : null;
                }
            );

            Field<ListGraphType<MarkType>>(
                "allMarks",
                resolve: context => markFacade.GetAll()
            );
        }

        private void AddUserQueries(UserFacade userFacade) {
            Field<ListGraphType<UserType>>(
                "allUsers",
                resolve: context => userFacade.GetAll()
            );

            Field<UserType>("user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (userFacade.GetById((int) id)) : null;
                }
            );
        }

        private void AddGroupQueries(GroupFacade groupFacade) {
            Field<ListGraphType<GroupType>>(
                "allGroups",
                resolve: context => groupFacade.GetAll()
            );

            Field<GroupType>("group",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (groupFacade.GetById((int) id)) : null;
                }
            );
        }

        private void AddGroupSubjectQueries(GroupSubjectFacade groupSubjectFacade) {
            Field<ListGraphType<GroupSubjectType>>(
                "allGroupSubjects",
                resolve: context => groupSubjectFacade.GetAll()
            );

            Field<GroupSubjectType>("groupSubject",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (groupSubjectFacade.GetById((int) id)) : null;
                }
            );
        }

        private void AddNotificationQueries(NotificationFacade notificationFacade) {
            Field<ListGraphType<NotificationType>>(
                "allNotifications",
                resolve: context => notificationFacade.GetAll()
            );

            Field<NotificationType>("notification",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (notificationFacade.GetById((int) id)) : null;
                }
            );
        }

        private void AddNotificationStudentQueries(NotificationStudentFacade notificationStudentFacade) {
            Field<ListGraphType<NotificationStudentType>>(
                "allNotificationStudents",
                resolve: context => notificationStudentFacade.GetAll()
            );

            Field<NotificationStudentType>("notificationStudent",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (notificationStudentFacade.GetById((int) id)) : null;
                }
            );
        }

        private void AddSubjectQueries(SubjectFacade subjectFacade) {
            Field<ListGraphType<SubjectType>>(
                "allSubjects",
                resolve: context => subjectFacade.GetAll()
            );

            Field<SubjectType>("subject",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (subjectFacade.GetById((int) id)) : null;
                }
            );
        }

        private void AddUserGroupQueries(UserGroupFacade userGroupFacade) {
            Field<ListGraphType<UserGroupType>>(
                "allUserGroups",
                resolve: context => userGroupFacade.GetAll()
            );

            Field<UserGroupType>("userGroup",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (userGroupFacade.GetById((int) id)) : null;
                }
            );
        }

        private void AddUserMarkQueries(UserMarkFacade userMarkFacade) {
            Field<ListGraphType<UserMarkType>>(
                "allUserMarks",
                resolve: context => userMarkFacade.GetAll()
            );

            Field<UserMarkType>("userMark",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (userMarkFacade.GetById((int) id)) : null;
                }
            );
        }

        private void AddUserRoleQueries(UserRoleFacade userRoleFacade) {
            Field<ListGraphType<UserRoleType>>(
                "allUserRoles",
                resolve: context => userRoleFacade.GetAll()
            );

            Field<UserRoleType>("userRole",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (userRoleFacade.GetById((int) id)) : null;
                }
            );
        }

        public Queries(MarkFacade markFacade, UserFacade userFacade, GroupFacade groupFacade,
            GroupSubjectFacade groupSubjectFacade, NotificationFacade notificationFacade,
            NotificationStudentFacade notificationStudentFacade, SubjectFacade subjectFacade,
            UserGroupFacade userGroupFacade, UserMarkFacade userMarkFacade, UserRoleFacade userRoleFacade) {
            AddMarkQueries(markFacade);

            AddUserQueries(userFacade);

            AddGroupQueries(groupFacade);

            AddGroupSubjectQueries(groupSubjectFacade);

            AddNotificationQueries(notificationFacade);

            AddNotificationStudentQueries(notificationStudentFacade);

            AddSubjectQueries(subjectFacade);

            AddUserGroupQueries(userGroupFacade);

            AddUserMarkQueries(userMarkFacade);

            AddUserRoleQueries(userRoleFacade);

            AddAuthorizeQueries(userFacade);
        }

        private void AddAuthorizeQueries(UserFacade userFacade) {
            Field<UserType>("login",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "login"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "password"}),
                resolve: context => {
                    var login = context.GetArgument<String>("login");
                    var password = context.GetArgument<String>("password");
                    return userFacade.Login(login, password);
                }
            );
        }

    }

}