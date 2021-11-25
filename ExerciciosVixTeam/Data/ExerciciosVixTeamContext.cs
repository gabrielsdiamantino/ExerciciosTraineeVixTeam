using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExerciciosVixTeam.Models;

namespace ExerciciosVixTeam.Data
{
    public class ExerciciosVixTeamContext : DbContext
    {
        public ExerciciosVixTeamContext (DbContextOptions<ExerciciosVixTeamContext> options)
            : base(options)
        {
        }

        public DbSet<ExerciciosVixTeam.Models.PessoaModel> PessoaModel { get; set; }
    }
}
