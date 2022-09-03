using Demo.Application.Common.Dtos;
using Demo.Application.Common.Interfaces;
using Demo.Domain.Entities;
using Demo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReposioty _userReposioty;

        public UserService(IUserReposioty userReposioty)
        {
            this._userReposioty = userReposioty;
        }


        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userReposioty.GetById(id);
            if (user != null)
            {
                return await _userReposioty.DeleteAsync(user);
            }
            else
            {
                return false;
            }
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var respose = new List<UserDto>();  

            var users = await _userReposioty.GetAll();

            foreach (var user in users)
            {
                respose.Add(MapToUserDto(user));
            }

            return respose;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var result = await _userReposioty.GetById(id);

            return MapToUserDto(result);
        }

        public async Task<UserDto> SaveUser(UserRegisterationDto userRegisterationDto)
        {
            var user = await _userReposioty.GetById(userRegisterationDto.Id);

            if(user == null)
            {
                user = new Domain.Entities.User()
                {
                    Address = userRegisterationDto.Address,
                    CreatedByUserId = 0,
                    CreatedDate = DateTime.UtcNow,
                    Email = userRegisterationDto.Email,
                    IsActive =true,
                    LastName = userRegisterationDto.LastName,
                    FirstName = userRegisterationDto.FirstName,
                    Role = userRegisterationDto.Role,
                    UpdateDate = DateTime.UtcNow,
                    UpdatedByUserId = 0,
                    Password = userRegisterationDto.Password
                };

                var result = await _userReposioty.CreateAsync(user);

                return MapToUserDto(result);
            }
            else
            {
                user.Email = userRegisterationDto.Email;
                user.Address = userRegisterationDto.Address;
                user.FirstName = userRegisterationDto.FirstName;
                user.LastName = userRegisterationDto.LastName;
                user.UpdateDate = DateTime.UtcNow;
                user.CreatedByUserId = 0;

                var result = await _userReposioty.UpdateAsync(user);

                return MapToUserDto(result);
            }
        }

        private UserDto MapToUserDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
