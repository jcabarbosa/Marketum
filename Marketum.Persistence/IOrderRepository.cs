using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        List<Order> GetAll();
        Order? GetById(int id);
        void Update(Order order);
    }
}
