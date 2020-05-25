using GraphQL;

namespace University.Schema {

    public class UniversitySchema : GraphQL.Types.Schema {

        public UniversitySchema(IDependencyResolver resolver)
            : base(resolver) {
            Query = resolver.Resolve<Queries.Queries>();
            Mutation = resolver.Resolve<Mutations.Mutations>();
        }

    }

}