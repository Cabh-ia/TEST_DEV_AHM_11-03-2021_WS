using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebServiceCRUDTokaMVC.Models;
using WebServiceCRUDTokaMVC.Models.Request;
using WebServiceCRUDTokaMVC.Models.Response;
using WebServiceCRUDTokaMVC.Tools;

namespace WebServiceCRUDTokaMVC.Services
{
    public class UserService : IUserServices
    {

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();
            using (var db = new PersonasFisicasContext())
            {
                string sPassword = Encrypt.GetSHA256(model.password);

                var usuario = db.TbUsuarios.Where(d => d.Email == model.email &&
                                                  d.Password == sPassword).FirstOrDefault();
                if (usuario == null) return null;
                userResponse.email = usuario.Email;
                userResponse.token = GetToken(usuario);

            }
            return userResponse;

        }

        private string GetToken(TbUsuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secreto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.UserId.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Email),
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
