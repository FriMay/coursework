using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.Group;
using University.Types.NotificationStudent;

namespace University.Types.Notification {

    public class NotificationType: ObjectGraphType<Database.Models.Notification> {

        public NotificationType(NotificationStudentFacade notificationStudentFacade, GroupFacade groupFacade) {
            Field(x => x.Id);
            Field<StringGraphType>("message",
                resolve:context=> context.Source.Message);
            Field<GroupType>("group",
                resolve: context => groupFacade.GetById(context.Source.GroupId) 
            );
            
            Field<ListGraphType<NotificationStudentType>>(
                "notificationStudents",
                resolve: context => notificationStudentFacade.GetByNotificationId(context.Source.Id));
            
            Field<NotificationStudentType>("notificationStudent",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => notificationStudentFacade.GetById(context.GetArgument<int>("id")));

        }
        

    }

}