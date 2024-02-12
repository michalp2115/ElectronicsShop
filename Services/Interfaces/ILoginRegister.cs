using ElectronicsShop.Models;

namespace ElectronicsShop.Services.Interfaces
{
    public interface ILoginRegister
    {
        Task<string> Register(RegisterRequest request);
        Task<string> Login(LoginRequest request);
    }
}
