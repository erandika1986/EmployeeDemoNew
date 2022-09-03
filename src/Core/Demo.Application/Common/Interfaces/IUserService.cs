using Demo.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> SaveUser(UserRegisterationDto userRegisterationDto);
        Task<List<UserDto>> GetAllUsers();
        Task<bool> DeleteUser(int id);
        Task<UserDto> GetUserById(int id);
    }
}
