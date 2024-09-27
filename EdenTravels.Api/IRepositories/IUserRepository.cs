﻿using EdenTravels.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}