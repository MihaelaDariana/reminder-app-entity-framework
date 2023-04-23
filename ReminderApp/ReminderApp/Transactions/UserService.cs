using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReminderApp.Models;
using ReminderApp.Models.Dto;
using ReminderApp.DAO;

public class UserService
{
    private readonly UserRepository _dbContext;
    private readonly UserManager<User> _userManager;

    public UserService(UserRepository dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task SaveUserAsync(UserRegistrationDto userRegistrationDto)
    {
        var user = new User
        {
            FirstName = userRegistrationDto.FirstName,
            LastName = userRegistrationDto.LastName,
            Email = userRegistrationDto.Email,
            UserName = userRegistrationDto.Email
        };

        var result = await _userManager.CreateAsync(user, userRegistrationDto.Password);

        if (!result.Succeeded)
        {
            // handle errors
        }
    }

    public async Task UpdateUserAsync(UserDto userDto)
    {
        var user = await _userManager.FindByEmailAsync(userDto.Email);

        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;

        await _userManager.UpdateAsync(user);
    }

    public async Task<UserDto> FindUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return null;
        }

        return new UserDto(user.FirstName, user.LastName, user.Email, user.Id);
    }

    public async Task<List<UserDto>> FindUsersAsync()
    {
        var users = await _dbContext.Users.ToListAsync();

        return users.Select(user => new UserDto(user.FirstName, user.LastName, user.Email, user.Id))
            .ToList();
    }
}