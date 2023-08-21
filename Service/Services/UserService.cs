using AutoMapper;
using Data.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.User;
using Service.Exeptions;
using Service.Interfaces;

namespace Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IRepository<User> repository;

    public UserService(IRepository<User> repository,IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        User existUser = await this.repository.GetAsync(x=>x.Email.Equals(dto.Email));

        if(existUser is not null) 
        {
            throw new AllReadyExistException($"This user email {dto.Email} allready exist");
        }

        var mappedUser=mapper.Map<User>(dto);
        await this.repository.CreateAsync(mappedUser);
        await this.repository.SaveAsync();

        var result = mapper.Map<UserResultDto>(mappedUser);
        return result;
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        User existUser = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existUser is null)
        {
            throw new NotFoundException($"This user is not found with Id-{dto.Id}");
        }

        var mappedUser = mapper.Map<User>(dto);
        this.repository.Update(mappedUser);
        await this.repository.SaveAsync();

        var result = mapper.Map<UserResultDto>(mappedUser);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        User existUser = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existUser is null)
        {
            throw new NotFoundException($"This user is not found with Id-{id}");
        }

        this.repository.Delete(existUser);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync()
    {
        var users = await this.repository.GetAll().ToListAsync();
        var result=mapper.Map<IEnumerable<UserResultDto>>(users);
        return result;
    }

    public async Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        User existUser = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existUser is null)
        {
            throw new NotFoundException($"This user is not found with Id-{id}");
        }
        return mapper.Map<UserResultDto>(existUser);
    }
}
