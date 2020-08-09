using XMLEditor.Models;

namespace XMLEditor.Repository
{
    public interface IUserRepository
    {
        User GetUserByLoginName(string login);
    }
}