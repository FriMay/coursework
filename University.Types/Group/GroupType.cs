using GraphQL.Types;

namespace University.Types.Group {

    public class GroupType: ObjectGraphType<Database.Models.Group> {

        public GroupType() {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Notifications);
            Field(x => x.GroupSubjects);
            Field(x => x.UserGroups);
        }

    }

}