using FormGenerator.Repository.Migrations;
using Microsoft.EntityFrameworkCore;

namespace FormGenerator.Repository
{
    public class FormGeneratorDbContext : DbContext
    {
        public FormGeneratorDbContext(DbContextOptions<FormGeneratorDbContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new CreateFormGeneratorSchema().BuildModel(builder);
            base.OnModelCreating(builder);
        }
    }
}