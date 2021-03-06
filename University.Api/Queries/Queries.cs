﻿using System;
using System.Collections.Generic;
using GraphQL.Types;
using University.DataAccess.Facades;
using University.Database.Models;
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

        private void AddUserQueries(UserFacade userFacade, UserRoleFacade userRoleFacade) {
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

            Field<ListGraphType<UserType>>("teachers",
                resolve: context => userFacade.GetByUserRoleId(userRoleFacade.GetByName("Преподаватель").Id));


            Field<ListGraphType<UserType>>("studentsByGroupId",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupId"}),
                resolve: context => {
                    var groupId = context.GetArgument<int>("groupId");

                    return userFacade.GetStudentsByGroupId(groupId);
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

        private void AddGroupSubjectQueries(GroupSubjectFacade groupSubjectFacade, SubjectFacade subjectFacade,
            UserFacade userFacade) {
            Field<ListGraphType<GroupSubjectType>>(
                "allGroupSubjects",
                resolve: context => groupSubjectFacade.GetAll()
            );

            Field<ListGraphType<GroupSubjectType>>("subjectListOnWeek",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupId"}),
                resolve: context => {
                    var groupId = context.GetArgument<int>("groupId");

                    IEnumerable<GroupSubject> groupSubjects = groupSubjectFacade.GetByGroupId(groupId);

                    foreach (var groupSubject in groupSubjects) {
                        groupSubject.Subject = subjectFacade.GetById(groupSubject.SubjectId);
                        groupSubject.Teacher = userFacade.GetById(groupSubject.TeacherId);
                    }

                    return groupSubjects;
                }
            );
            
            Field<ListGraphType<GroupSubjectType>>("subjectsForTeacher",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "teacherId"}),
                resolve: context => {
                    var teacherId = context.GetArgument<int>("teacherId");

                    IEnumerable<GroupSubject> groupSubjects = groupSubjectFacade.GetScheduleByTeacherId(teacherId);

                    foreach (var groupSubject in groupSubjects) {
                        groupSubject.Subject = subjectFacade.GetById(groupSubject.SubjectId);
                        groupSubject.Teacher = userFacade.GetById(groupSubject.TeacherId);
                    }

                    return groupSubjects;
                }
            );

            Field<ListGraphType<GroupSubjectType>>("teachersDisabled",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "dayOfWeek"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "orderNumber"},
                    new QueryArgument<ListGraphType<IntGraphType>> {Name = "teachers"}),
                resolve: context => {
                    var teachers = context.GetArgument<List<int>>("teachers");
                    var dayOfWeek = context.GetArgument<int>("dayOfWeek");
                    var orderNumber = context.GetArgument<int>("orderNumber");

                    List<GroupSubject> groupSubjects = new List<GroupSubject>();

                    foreach (var teacher in teachers) {
                        GroupSubject groupSubject =
                            groupSubjectFacade.GetByDayAndOrderAndTeacher(dayOfWeek, orderNumber, teacher);
                        if (groupSubject != null) {
                            groupSubjects.Add(groupSubject);
                        }
                    }

                    return groupSubjects;
                }
            );

            Field<ListGraphType<GroupSubjectType>>("subjectsOnDay",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "dayOfWeek"}),
                resolve: context => {
                    var groupId = context.GetArgument<int>("groupId");
                    var dayOfWeek = context.GetArgument<int>("dayOfWeek");

                    return groupSubjectFacade.GetByDayAndGroup(groupId, dayOfWeek);
                }
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


            Field<ListGraphType<NotificationType>>("notificationsByGroupId",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupId"}),
                resolve: context => {
                    var groupId = context.GetArgument<int>("groupId");

                    return notificationFacade.GetByGroupId(groupId);
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
            
            Field<ListGraphType<UserMarkType>>("attendance",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupSubjectId"},
                    new QueryArgument<NonNullGraphType<DateTimeGraphType>> {Name = "date"}),
                resolve: context => {
                    var groupSubjectId = context.GetArgument<int>("groupSubjectId");
                    var date = context.GetArgument<DateTime>("date");
                    var leftDate = date.AddMinutes(-1);
                    var rightDate = date.AddMinutes(1);
                    return userMarkFacade.GetByGroupSubjectAndIssueDate(groupSubjectId, leftDate, rightDate);
                }
            );
            
            Field<ListGraphType<UserMarkType>>("studentAttendance",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupSubjectId"},
                            new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "studentId"}
                    ),
                resolve: context => {
                    var groupSubjectId = context.GetArgument<int>("groupSubjectId");
                    var studentId = context.GetArgument<int>("studentId");
                    
                    return userMarkFacade.GetByGroupSubjectAndStudentId(groupSubjectId, studentId);
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

            AddUserQueries(userFacade, userRoleFacade);

            AddGroupQueries(groupFacade);

            AddGroupSubjectQueries(groupSubjectFacade, subjectFacade, userFacade);

            AddNotificationQueries(notificationFacade);

            AddNotificationStudentQueries(notificationStudentFacade);

            AddSubjectQueries(subjectFacade);

            AddUserGroupQueries(userGroupFacade);

            AddUserMarkQueries(userMarkFacade);

            AddUserRoleQueries(userRoleFacade);

            AddAuthorizeQueries(userFacade, userRoleFacade);
        }

        private void AddAuthorizeQueries(UserFacade userFacade, UserRoleFacade userRoleFacade) {
            Field<UserType>("login",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "login"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "password"}),
                resolve: context => {
                    var login = context.GetArgument<String>("login");
                    var password = context.GetArgument<String>("password");
                    return userFacade.Login(login, password);
                }
            );
            
            Field<UserType>("studentLogin",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "login"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "password"}),
                resolve: context => {
                    var login = context.GetArgument<String>("login");
                    var password = context.GetArgument<String>("password");
                    return userFacade.Login(login, password, false);
                }
            );
        }

    }

}