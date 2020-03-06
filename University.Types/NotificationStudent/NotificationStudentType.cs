using GraphQL.Types;
using University.Types.Notification;
using University.Types.User;

namespace University.Types.NotificationStudent {

    public class NotificationStudentType: ObjectGraphType<Database.Models.NotificationStudent> {

        public NotificationStudentType() {
            Field(x => x.Id);
            Field<NotificationType>("notification",
                resolve: context => context.Source.Notification
            );
            Field<UserType>("student",
                resolve: context => context.Source.Student
            );


        }
        

    }

}