using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc.Razor;
using University.DataAccess.Facades;
using University.Database.Models;
using University.Types.GroupSubject;
using University.Types.Notification;
using University.Types.User;
using University.Types.UserMark;

namespace University.Mutations {
    public class Mutations : ObjectGraphType {
        private void AddMarkMutations(MarkFacade markFacade) {
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
                    var user = ParseUser(context.GetArgument<User>("user"));
                    var groupId = context.GetArgument<int>("groupId");
                    if (user.FirstName == null || user.LastName == null || user.Login == null ||
                        user.Password == null) {
                        throw new ArgumentException();
                    }

                    if (userFacade.GetByLogin(user.Login) != null) {
                        return null;
                    }

                    user.UserRoleId = userRoleFacade.GetByName("Студент").Id;

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
                    var deleteUser = userFacade.GetById(context.GetArgument<int>("deleteId"));
                    userGroupFacade.Delete(userGroupFacade.GetUserGroupByUserId(deleteUser.Id));
                    return userFacade.Delete(deleteUser);
                }
            );

            Field<UserType>("editUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "userId"},
                    new QueryArgument<NonNullGraphType<UserInputType>> {Name = "user"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "editId"}),
                resolve: context => {
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

        private void AddNotificationMutations(NotificationFacade notificationFacade, GroupFacade groupFacade, NotificationStudentFacade notificationStudentFacade) {
            Field<NotificationType>("addNotification",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<NotificationInputType>> {Name = "notification"}),
                resolve: context => {
                    var notification = context.GetArgument<Notification>("notification");
                    notification.Group = groupFacade.GetById(notification.GroupId);
                    return notificationFacade.Add(notification);;
                }
            );
            
            Field<NotificationType>("deleteNotification",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "notificationId"}),
                resolve: context => {
                    var notificationId = context.GetArgument<int>("notificationId");
                    Notification notification = notificationFacade.GetById(notificationId);
                    notificationStudentFacade.DeleteByNotification(notification);
                    return notificationFacade.Delete(notification);
                }
            );

            Field<ListGraphType<NotificationType>>("notificationsForStudent",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "studentId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "groupId"}
                ),
                resolve: context => {
                    
                    var groupId = context.GetArgument<int>("groupId");
                    var studentId = context.GetArgument<int>("studentId");

                    IEnumerable<Notification> notifications = notificationFacade.GetByGroupId(groupId);
                    
                    List<Notification> notificationList = new List<Notification>();

                    foreach (var notification in notifications) {
                        if (!notificationStudentFacade.getByUserIdAndNotificationId(studentId, notification.Id)) {
                            notificationList.Add(notification);
                            notificationStudentFacade.Add(new NotificationStudent {
                                NotificationId = notification.Id, StudentId = studentId
                            });
                        }
                    }
                    
                    return notificationList;
                }
            );
        }

        private void AddNotificationStudentMutations(NotificationStudentFacade notificationStudentFacade) { }

        private void AddSubjectMutations(SubjectFacade subjectFacade) { }

        private void AddUserGroupMutations(UserGroupFacade userGroupFacade) { }

        private void AddUserMarkMutations(UserMarkFacade userMarkFacade) {
            Field<UserMarkType>("editUserMarkByUserList",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ListGraphType<UserMarkInputType>>> {Name = "userMarks"}),
                resolve: context => {

                    List<UserMark> marks = context.GetArgument<List<UserMark>>("userMarks");

                    foreach (UserMark mark in marks) {
                        if (mark.IssueData != null) {
                            DateTime leftDate = mark.IssueData.Value.AddMinutes(-1);
                            DateTime rightDate = mark.IssueData.Value.AddMinutes(1);
                        
                            UserMark old = userMarkFacade.GetByUserMarkInputType(mark,leftDate,rightDate);
                            if (old == null) {
                                userMarkFacade.Add(mark);
                            }
                            else {
                                if (old.MarkId != mark.MarkId) {
                                    old.MarkId = mark.MarkId;
                                    userMarkFacade.Update(old);
                                }
                            }
                        }
                    }

                    return null;
                }
            );
            
        }

        private void AddUserRoleMutations(UserRoleFacade userRoleFacade) { }

        public Mutations(MarkFacade markFacade, UserFacade userFacade, GroupFacade groupFacade,
            GroupSubjectFacade groupSubjectFacade, NotificationFacade notificationFacade,
            NotificationStudentFacade notificationStudentFacade, SubjectFacade subjectFacade,
            UserGroupFacade userGroupFacade, UserMarkFacade userMarkFacade, UserRoleFacade userRoleFacade) {
            AddMarkMutations(markFacade);

            AddUserMutations(userFacade, userRoleFacade, userGroupFacade, groupFacade);

            AddGroupMutations(groupFacade);

            AddGroupSubjectMutations(groupSubjectFacade, userFacade);

            AddNotificationMutations(notificationFacade, groupFacade, notificationStudentFacade);

            AddNotificationStudentMutations(notificationStudentFacade);

            AddSubjectMutations(subjectFacade);

            AddUserGroupMutations(userGroupFacade);

            AddUserMarkMutations(userMarkFacade);

            AddUserRoleMutations(userRoleFacade);
        }
    }
}