using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.Notification;
using University.Types.User;

namespace University.Types.NotificationStudent {

    public class NotificationStudentType: ObjectGraphType<Database.Models.NotificationStudent> {

        public NotificationStudentType(NotificationFacade notificationFacade, UserFacade userFacade) {
            Field(x => x.Id);
            Field<NotificationType>("notification",
                resolve: context => notificationFacade.GetById(context.Source.NotificationId) 
            );
            Field<UserType>("student",
                resolve: context => userFacade.GetById(context.Source.StudentId) 
            );


        }
        

    }

}