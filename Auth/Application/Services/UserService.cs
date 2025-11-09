using Application.Dto;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exception;

namespace Application.Services;

public class UserService(IUserRepository userRepository)
{
    public async Task AddAsync(UserAddDto dto)
    {
        User user;
        try
        {
            user = User.Create(dto.Email, dto.Password);
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
        }
        catch (UserCreateException e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}