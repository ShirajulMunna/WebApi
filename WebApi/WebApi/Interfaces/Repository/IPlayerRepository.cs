using EF.Core.Repository.Interface.Repository;
using WebApi.Model;

namespace WebApi.Interfaces.Repository
{
    public interface IPlayerRepository:ICommonRepository<Player>
    {
    }
}
