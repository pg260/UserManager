using Manager.Services.DTO;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;

namespace Manager.Services.Services;

public class UserService : IUserService
{
    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public async Task<UserDto> Create(UserDto userDTO)
    {
        var userExists = await _userRepository.GetByEmail(userDTO.Email);

        if (userExists != null)
        {
            throw new DomainExceptions("Email já cadastrado");
        }

        var user = _mapper.Map<User>(userDTO);
        user.Validate();

        var userCreated = await _userRepository.Create(user);

        return _mapper.Map<UserDto>(userCreated);
    }

    public async Task<UserDto> Update(UserDto userDTO)
    {
        var userExists = await _userRepository.Get(userDTO.Id);

        if (userExists == null)
            throw new DomainExceptions("Id inválida");

        var user = _mapper.Map<User>(userDTO);
        user.Validate();

        var userUpdated = await _userRepository.Update(user);

        return _mapper.Map<UserDto>(userUpdated);
    }

    public async Task Remove(long id)
    {
        await _userRepository.Remove(id);
    }

    public async Task<UserDto> Get(long id)
    {
        var user = await _userRepository.Get(id);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserDto>> Get()
    {
        var allUsers = await _userRepository.Get();

        return _mapper.Map<List<UserDto>>(allUsers);
    }

    public async Task<List<UserDto>> SearchByName(string name)
    {
        var allUser = await _userRepository.SearchByName(name);

        return _mapper.Map<List<UserDto>>(allUser);
    }

    public async Task<List<UserDto>> SearchByEmail(string email)
    {
        var allUsers = await _userRepository.SearchByEmail(email);

        return _mapper.Map<List<UserDto>>(allUsers);
    }

    public async Task<UserDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        return _mapper.Map<UserDto>(user);
    }
}