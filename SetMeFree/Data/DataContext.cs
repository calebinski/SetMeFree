using Microsoft.EntityFrameworkCore;
using SetMeFree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetMeFree.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<MythFact> MythFacts { get; set; }

        public DbSet<MythFactAnswer> MythFactAnswers { get; set; }

        public DbSet<GuessWho> GuessWho { get; set; }
        public DbSet<GuessWhoAnswer> GuessWhoAnswers { get; set; }
        public DbSet<GroomingSteps> GroomingSteps { get; set; }
        public DbSet<GroomingStepAnswer> GroomingStepAnswers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TrustworthyPerson> TrustworthyPerson { get; set; }
        public DbSet<TrustworthyPersonAnswer> TrustworthyPersonAnswers { get; set; }
    }
}
