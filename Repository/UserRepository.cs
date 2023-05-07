using LoginAPI.Project.Models;
using LoginAPI.Project.Models.DTO;
using LoginAPI.Project.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginAPI.Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
       // private string secretKey;
        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            //secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsUniqueUser(string email)
        {
            var user = _db.RegisterData.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
        }
       public async Task<RegisterData> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            RegisterData register = new()
            {
                Email = registerationRequestDTO.Email,
                PanNumber = registerationRequestDTO.PanNumber,
                Password = registerationRequestDTO.Password,
                ConfirmPassword = registerationRequestDTO.ConfirmPassword,
            };
            _db.RegisterData.Add(register);
            await _db.SaveChangesAsync();
            //register.Password = "";
            return register;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.RegisterData.FirstOrDefault(u => u.Email.ToLower() == loginRequestDTO.Email.ToLower() && u.Password == loginRequestDTO.Password);
            if (user == null)
            {
                return new LoginResponseDTO()
               {
                    // Token = "",
                    registerData = user
               };
          }

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
               // Token = tokenHandler.WriteToken(token),
                registerData = user
            };

            return loginResponseDTO;
        }
    }
}
