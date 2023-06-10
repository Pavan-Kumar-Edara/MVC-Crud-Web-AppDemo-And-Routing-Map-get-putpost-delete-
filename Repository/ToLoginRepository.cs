using MVCFoodDelivery.Context;
using MVCFoodDelivery.Models;

namespace MVCFoodDelivery.Repository
{
    public class ToLoginRepository : IToLoginRepository
    {
        private List<ToLogin> toLoginList;
        public readonly ToLoginDbContext context;
        public ToLoginRepository(ToLoginDbContext tologinDbContext) {

            context = tologinDbContext;

        //    toLoginList = new List<ToLogin>
        //    {
        //        new ToLogin {Id=1,Email="pavan@gmail.com",Password="12345678"},
        //        new ToLogin {Id=2,Email="rohit@gmail.com",Password="87654321"},
        //    };

        }
        public ToLogin Add(ToLogin tologin)
        {
            context.loginDetails.Add(tologin);
            context.SaveChanges();
            return tologin;
        }

        public ToLogin delete(int id)
        {
            ToLogin toDelete = context.loginDetails.Find(id);
            if(toDelete != null)
            {
                context.loginDetails.Remove(toDelete);
                context.SaveChanges();
            }
            return toDelete;
        }

        public IEnumerable<ToLogin> GetAll()
        {
            return context.loginDetails;
        }

        public ToLogin GetLoginById(int id) {
            return context.loginDetails.Find(id);
        }
        public ToLogin update(ToLogin modifyDetails)
        {
            context.Update(modifyDetails);
            context.SaveChanges();
            return modifyDetails;
        }
    }
}
