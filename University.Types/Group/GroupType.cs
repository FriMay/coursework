using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.GroupSubject;
using University.Types.Notification;
using University.Types.UserGroup;

namespace University.Types.Group {

    public class GroupType: ObjectGraphType<Database.Models.Group> {

        public GroupType(NotificationFacade notificationFacade, UserGroupFacade userGroupFacade, GroupSubjectFacade groupSubjectFacade) {
            Field(x => x.Id);
            Field<StringGraphType>("name"
                ,
                resolve:context=> context.Source.Name);
            Field<ListGraphType<NotificationType>>(
                "notifications",
                resolve: context => notificationFacade.GetByGroupId(context.Source.Id));
            Field<ListGraphType<UserGroupType>>(
                "userGroups",
                resolve: context => userGroupFacade.GetByGroupId(context.Source.Id));
            Field<ListGraphType<GroupSubjectType>>(
                "groupSubjects",
                resolve: context => groupSubjectFacade.GetByGroupId(context.Source.Id));
        }

    }

}