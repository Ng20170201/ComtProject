using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RepositoriesInterfaces;
using ServicesInterfaces;
using Utils.ErrorModels;
using Utils.Handlers;
using Utils.Interfaces;
using Microsoft.AspNetCore.Http;
using Service.Models;

namespace Service
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepo;
        public JWTGenerator _jwtGenerator;
        private readonly HttpContext _httpContext;

        public UserService(IUserRepository userRepo, JWTGenerator jWTGenerator, IHttpContextAccessor contextAccessor) {
            _userRepo = userRepo;
            _jwtGenerator = jWTGenerator;
            _httpContext = contextAccessor.HttpContext;
        }

        public async Task<int> GetLoggedInUserId()
        {
            try
            {
                var idString = _httpContext.User.Claims.FirstOrDefault().Value;
                int id;
                Int32.TryParse(idString, out id);
                return id;
            }
            catch (Exception ex)
            {
                throw new UnautorizedError("Cannot find user with this param");
            }
        }

        public async Task<ITokenModel> Login(IUser model)
        {
            if (model == null)
            {
                return null;
            }

            var user = await _userRepo.Login(model);

            var jwtToken = _jwtGenerator.Generate(user);

            var token = new TokenModel
            {
                Token = jwtToken
            };

            return token;
        }

        public async Task<IUser> GetLoggedInUser()
        {
            try
            {
                var idString = _httpContext.User.Claims.FirstOrDefault().Value;
                int id;
                Int32.TryParse(idString, out id);

                var user = await _userRepo.GetUser(id);
                return user;
            }
            catch (Exception ex)
            {
                throw new UnautorizedError("Cannot find user with this param");
            }
        }

        public async Task<IUser> GetUserWithRewardedUser()
        {
            try
            {
                var idString = _httpContext.User.Claims.FirstOrDefault().Value;
                int id;
                Int32.TryParse(idString, out id);

                var user = await _userRepo.GetUserWithRewardedUser(id);
                return user;
            }
            catch (Exception ex)
            {
                throw new UnautorizedError("Cannot find user with this param");
            }
        }
    }
}
