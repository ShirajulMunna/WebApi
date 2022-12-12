using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Interfaces.Repository;
using WebApi.Model;

namespace WebApi.Repository
{
    public class PlayerRepository : CommonRepository<Player>, IPlayerRepository
    {
       
        public PlayerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
