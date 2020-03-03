using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types;
using University.Types.Mark;

namespace University.Queries {

    public class MarkQuery : ObjectGraphType {

        public MarkQuery(MarkFacade markFacade) {
            Field<ListGraphType<MarkType>>(
                "allMarks",
                resolve: context => markFacade.GetAll()
            );

            Field<MarkType>("mark",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => {
                    var id = context.GetArgument<int?>("id");

                    return id != null ? (markFacade.GetById((int) id)) : null;
                }
            );
        }

    }

}