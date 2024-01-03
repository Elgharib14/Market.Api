using Backery.Migrations;
using Backery.Modell;

namespace Backery.Interface
{
    public interface IAuthentication
    {
        Task<AuthModell> Registration(RegisterVM register);
        Task<AuthModell> Login(LoginVM login);
        Task<string> AddRole(RoleVM model);
    }
}
