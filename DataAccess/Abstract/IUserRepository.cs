using Entity;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
      public User GetByUsername(string  username);
    }
}
