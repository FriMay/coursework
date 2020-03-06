using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.Group;
using University.Types.NotificationStudent;

namespace University.Types.Notification {

    public class NotificationType: ObjectGraphType<Database.Models.Notification> {

        public NotificationType(NotificationStudentFacade notificationStudentFacade) {
            Field(x => x.Id);
            Field(x => x.Message);
            Field<GroupType>("group",
                resolve: context => context.Source.Group
            );
            
            Field<ListGraphType<NotificationStudentType>>(
                "notificationStudents",
                resolve: context => notificationStudentFacade.GetByNotificationId(context.Source.Id));

        }
        

    }

}