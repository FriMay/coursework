using GraphQL.Types;
using University.Types.Mark;

namespace University.Types.UserMark {

    public class UserMarkType: ObjectGraphType<Database.Models.UserMark> {

        public UserMarkType() {
            Field(x => x.Id);
            Field(x => x.IssueData);
            Field<MarkType>("mark",
                resolve: context => context.Source.Mark
            );
        }

    }

}