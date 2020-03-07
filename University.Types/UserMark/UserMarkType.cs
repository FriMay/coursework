using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.GroupSubject;
using University.Types.Mark;
using University.Types.User;

namespace University.Types.UserMark {

    public class UserMarkType: ObjectGraphType<Database.Models.UserMark> {

        public UserMarkType(GroupSubjectFacade groupSubjectFacade, UserFacade userFacade, MarkFacade markFacade) {
            Field(x => x.Id);
            Field(x => x.IssueData);

            Field<GroupSubjectType>("groupSubject",
                resolve: context => groupSubjectFacade.GetById(context.Source.GroupSubjectId) 
            );
            
            Field<UserType>("user",
                resolve: context => userFacade.GetById(context.Source.StudentId) 
            );
            
            Field<MarkType>("mark",
                resolve: context => markFacade.GetById(context.Source.MarkId) 
            );
        }

    }

}