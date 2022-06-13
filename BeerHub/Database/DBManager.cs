using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BeerHub.Database
{
  public class DBManager : DbContext
  {
    public DBManager(DbContextOptions<DBManager> options) : base(options)
    {
    }
  }
}
