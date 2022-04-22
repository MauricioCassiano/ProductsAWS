using ProductsAWS.Domain;
using ProductsAWS.Infra.Data.Interfaces;

namespace ProductsAWS.Infra.IoC.Interfaces
{
    public interface IPlayerPersistence : IDynamoDBAbstract<Player>
    { }
}
