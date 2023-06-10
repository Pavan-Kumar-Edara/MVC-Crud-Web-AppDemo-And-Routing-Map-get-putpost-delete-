using MVCFoodDelivery.Models;

namespace MVCFoodDelivery.Repository
{
    public interface IToLoginRepository
    {
        ToLogin Add(ToLogin tologin);

        ToLogin update(ToLogin tologin);

        ToLogin delete(int id);

        ToLogin GetLoginById(int id);
        IEnumerable<ToLogin> GetAll();
    }
}
