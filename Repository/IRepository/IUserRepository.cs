using LoginAPI.Project.Models;
using LoginAPI.Project.Models.DTO;

namespace LoginAPI.Project.Repository.IRepository
{
    public interface IUserRepository
    {
        public Task<RegisterData> Register(RegisterationRequestDTO registerationRequestDTO);
        public bool IsUniqueUser(string email);
        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    }
}
