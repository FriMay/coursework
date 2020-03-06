using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.GroupSubject;
using University.Types.Mark;
using University.Types.User;

namespace University.Types.UserMark {

    public class UserMarkType: ObjectGraphType<Database.Models.UserMark> {

        public UserMarkType() {
            Field(x => x.Id);
            Field(x => x.IssueData);

            Field<GroupSubjectType>("groupSubject",
                resolve: context => context.Source.GroupSubject
            );
            
            Field<UserType>("user",
                resolve: context => context.Source.Student
            );
            
            Field<MarkType>("mark",
                resolve: context => context.Source.Mark
            );
        }

    }

}