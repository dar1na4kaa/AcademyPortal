using Application.Dto;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exception;
using Domain.ValueObject;
using Shared.Result;

namespace Application.Services;

public class UserService(IUserRepository userRepository)
{
    public async Task<Result<User>> AddAsync(UserAddDto dto)
    {
        User user;
        try
        {
            if (await userRepository.GetFirstOrDefaultByEmailAsync(dto.Email) != null)
                return Result.Failure<User>(UserErrors.EmailNotUnique);

            user = User.Create(dto.Email, dto.Password);
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
        }
        catch (UserCreateException e)
        {
            Console.WriteLine(e);
            return Result.Failure<User>(UserErrors.CreationException(e.Message));
        }

        return user;
    }

    public async Task<Result<User>> GetByIdAsync(int id)
    {
        return await userRepository.GetByIdAsync(id);
    }
    
    public async Task<Result<User>> GetByGuidAsync(Guid guid)
    {
        return await userRepository.GetFirstOrDefaultByGuidAsync(guid);
    }
}