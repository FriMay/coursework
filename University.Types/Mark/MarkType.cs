using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.UserMark;

namespace University.Types.Mark {

    public class MarkType: ObjectGraphType<Database.Models.Mark> {

        public MarkType(UserMarkFacade userMarkFacade) {
            Field(x => x.Id);
            Field<StringGraphType>("markValue"
                ,
                resolve:context=> context.Source.MarkValue);
            Field<ListGraphType<UserMarkType>>(
                "userMarks",
                resolve: context => userMarkFacade.GetByMarkId(context.Source.Id));
            
        }

    }

}