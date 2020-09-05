using System.Threading.Tasks;

namespace LetsGo.Services {
    public interface IAuth {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<bool> CreateUserWithEmailPassword(string email, string password);

    }
}
