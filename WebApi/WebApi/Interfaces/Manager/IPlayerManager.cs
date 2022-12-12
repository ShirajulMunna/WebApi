using EF.Core.Repository.Interface.Manager;
using WebApi.Model;

namespace WebApi.Interfaces.Manager
{
    public interface IPlayerManager:ICommonManager<Player>
    {
        Player GetPlayerById(int id);
        ICollection<Player> GetPlayerByAbility(string ability);

        ICollection<Player> GetPlayerByStringMatch(string text);

        ICollection<Player> GetPlayerDataInPage(int page, int pageSize);

    }
}
