using GraphQL.Types;

namespace University.Types.NotificationStudent {

    public class NotificationStudentInputType: InputObjectGraphType {

        public NotificationStudentInputType() {
            Field<IntGraphType>("studentId");
            Field<IntGraphType>("notificationId");
            
        }

    }

}