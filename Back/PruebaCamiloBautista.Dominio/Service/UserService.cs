using PruebaCamiloBautista.Dominio.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using PruebaCamiloBautista.Dominio.Modelos.Common;
using PruebaCamiloBautista.Dominio.Modelos.Reply;
using WSVenta.Models.Request;
using PruebaCamiloBautista.Datos;
using System.Security.Cryptography;
using PruebaCamiloBautista.Dominio.Tools;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;
using PruebaCamiloBautista.Dominio.Modelos.Request;

namespace PruebaCamiloBautista.Dominio.Service
{
    public class UserService:IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userresponse = new UserResponse();
            using (var db = new DigitalWareContext())
            {
                string spassword = Encrypt.GetSHA256(model.Password);
                var user = db.Usuarios.Where(d => d.Email == model.Email && d.Password == spassword).FirstOrDefault();
                if (user == null) return null;
                userresponse.Email = user.Email;
                userresponse.Token = GetToken(user);
                var idRoll= db.Usuarios.Where(d => d.Email == model.Email && d.Password == spassword).FirstOrDefault().IdRoll;
                userresponse.IdRoll = idRoll;
                userresponse.NombreRoll = db.Roles.Find(idRoll).NombreRoll;
            }

            return userresponse;


        }

        private string GetToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Email.ToString())
                    }
                    ),
                //expiracion token
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public Reply GetUser()
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                try
                {

                  var lst = (from d in db.Usuarios
                                         join h in db.Roles on d.IdRoll equals h.Id
                                          select new 
                                          {
                                            Id=d.Id,
                                            Nombre=d.Nombre,
                                            Email=d.Email,
                                            Password=d.Password,
                                            IdRoll=d.IdRoll,
                                            NombreRoll=h.NombreRoll

                                          }).OrderByDescending(d => d.Id).ToList();


                    oReply.Success = 1;
                    oReply.Data = lst;
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }

        public Reply AddUser(UserRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;

                string spassword = Encrypt.GetSHA256(model.Password);

                try
                {
                    var user = new Usuario();
                    user.Nombre = model.Nombre;
                    user.IdRoll = model.IdRoll;
                    user.Password = spassword;
                    user.Email = model.Email;
                    db.Usuarios.Add(user);

                    db.SaveChanges();
                    oReply.Success = 1;

                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }

        }

        public Reply EditUser(UserRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;

                string spassword = Encrypt.GetSHA256(model.Password);

                try
                {
                    var user = db.Usuarios.Find(model.Id);
                    user.Nombre = model.Nombre;
                    user.IdRoll = model.IdRoll;
                    user.Password = spassword;
                    user.Email = model.Email;
                    db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oReply.Success = 1;

                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }

        }

        public Reply DeleteUser(UserRequest model)
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;

                string spassword = Encrypt.GetSHA256(model.Password);

                try
                {
                    var user = db.Usuarios.Find(model.Id);
                    db.Remove(user);
                    db.SaveChanges();
                    oReply.Success = 1;

                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }

        }

        public Reply GetRol()
        {
            using (DigitalWareContext db = new DigitalWareContext())
            {
                Reply oReply = new Reply();
                try
                {

                    var lst = (from d in db.Roles
                               select new Role
                               {
                                   Id = d.Id,
                                   NombreRoll = d.NombreRoll
                               }).OrderByDescending(d => d.Id).ToList();


                    oReply.Success = 1;
                    oReply.Data = lst;
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }
    }
}

