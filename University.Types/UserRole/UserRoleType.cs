using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.User;

namespace University.Types.UserRole {

    public class UserRoleType: ObjectGraphType<Database.Models.UserRole> {

        public UserRoleType(UserFacade userFacade) {
            Field(x => x.Id);
            Field<StringGraphType>("roleName"
                ,
                resolve:context=> context.Source.RoleName);
            Field<ListGraphType<UserType>>("users",
                resolve: context => userFacade.GetByUserRoleId(context.Source.Id));
        }

    }

}