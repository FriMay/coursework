using GraphQL.Types;
using University.DataAccess.Facades;
using University.Types.Group;
using University.Types.GroupSubject;
using University.Types.NotificationStudent;
using University.Types.UserGroup;
using University.Types.UserMark;
using University.Types.UserRole;

namespace University.Types.User {

    public class UserType : ObjectGraphType<Database.Models.User> {

        public UserType(UserGroupFacade userGroupFacade, UserMarkFacade userMarkFacade, UserRoleFacade userRoleFacade,
            GroupFacade groupFacade) {
            Field(x => x.Id);
            Field<StringGraphType>("login",
                resolve: context => context.Source.Login);
            Field<StringGraphType>("password",
                resolve: context => context.Source.Password);
            Field<StringGraphType>("firstName",
                resolve: context => context.Source.FirstName);
            Field<StringGraphType>("lastName",
                resolve: context => context.Source.LastName);
            Field<StringGraphType>("secondName",
                resolve: context => context.Source.SecondName);
            Field<ListGraphType<GroupType>>("group",
                resolve: context => userGroupFacade.GetByUserId(context.Source.Id, groupFacade)
            );
            Field<ListGraphType<UserMarkType>>("userMarks",
                resolve: context => userMarkFacade.GetByUserId(context.Source.Id)
            );
            Field<UserMarkType>("userMark",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => userMarkFacade.GetById(context.GetArgument<int>("id")));
            Field<UserRoleType>(
                "userRole",
                resolve: context => userRoleFacade.GetById(context.Source.UserRoleId)
            );
        }

    }

}