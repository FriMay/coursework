﻿using System;
using GraphQL;
using GraphQL.Types;
using University.Queries;

namespace University.Schema {

    public class UniversitySchema : GraphQL.Types.Schema {

        public UniversitySchema(IDependencyResolver resolver)
            : base(resolver) {
            Query = resolver.Resolve<MarkQuery>();
        }

    }

}