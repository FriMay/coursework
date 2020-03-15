using GraphQL.Types;

namespace University.Types.Notification {

    public class NotificationInputType: InputObjectGraphType {

        public NotificationInputType() {
            Field<StringGraphType>("message");
            Field<IntGraphType>("groupId");
        }

    }

}