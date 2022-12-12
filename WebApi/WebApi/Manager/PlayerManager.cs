using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using WebApi.Context;
using WebApi.Interfaces.Manager;
using WebApi.Model;
using WebApi.Repository;

namespace WebApi.Manager
{
    public class PlayerManager : CommonManager<Player>, IPlayerManager
    {
        public PlayerManager(ApplicationDbContext _dbContext) : base(new PlayerRepository(_dbContext))
        {

        }

        public ICollection<Player> GetPlayerByAbility(string ability)
        {
            return Get(x => x.Ability.ToLower() == ability.ToLower());
        }

        public Player GetPlayerById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }

        public ICollection<Player> GetPlayerByStringMatch(string text)
        {
            text= text.ToLower();
            return Get(x => x.Ability.ToLower().Contains(text)||x.Name.ToLower().Contains(text));
        }

        public ICollection<Player> GetPlayerDataInPage(int page, int pageSize)
        {
            if (page <= 1) 
            {
                page = 0; 
            }
            int totalNumber=page*pageSize;
            return GetAll().Skip(totalNumber).Take(pageSize).ToList();
        }
    }
}
