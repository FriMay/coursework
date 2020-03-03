﻿using System.IO;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace University.Database {

    public class UniversityContextFactory: IDesignTimeDbContextFactory<UniversityContext> {

        public UniversityContext CreateDbContext(string[] args) {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<UniversityContext>();
            var connectionString = configuration.GetConnectionString("UniversityDb");
            builder.UseNpgsql(connectionString);

            return new UniversityContext(builder.Options);
        }

    }

}