using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.UserDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class UserService
    {
        private MainDb context;
        private IMapper mapper;

        public UserService(MainDb _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task<Result<UserDTO>> CreateUser(CreateUserDTO user)
        {
            if (IsUserEmailExist(user.UserMail))
            {
                throw new Exception("The user already exist");
            }

            try
            {
                var _user = mapper.Map<User>(user);
                context.Users.Add(_user);
                await context.SaveChangesAsync();
                if(_user != null)
                {
                    var userCreate = mapper.Map<UserDTO>(_user);
                    return Result<UserDTO>.PrepareSuccess(userCreate);
                }
                else { return Result<UserDTO>
                        .PrepareFailure("Kayıt Başarısız!"); }
            }
            catch(Exception ex) 
            { return Result<UserDTO>.PrepareFailure(ex.ToString()); }

        }

        public async Task<Result<UserDTO>> LoginUser(UserLoginDTO user)
        {
            try
            {
                var _user = await context.Users
                    .Where(p => p.UserMail == user.UserMail &&
                    p.UserPassword == user.UserPassword)
                    .FirstOrDefaultAsync();
                if(_user != null )
                {
                    UserDTO userlog = mapper.Map<UserDTO>(_user);
                    return Result<UserDTO>.PrepareSuccess(userlog);
                }
                else 
                {return Result<UserDTO>.PrepareFailure("Kayıt Yok!");}

            }
            catch(Exception ex) 
            {return Result<UserDTO>.PrepareFailure(ex.ToString());}
        }

        public async  Task<Result<User>> UpdateUser(UserInfoDTO user)
        {
            if (!IsUserExist(user.Id)) 
            { throw new Exception("User not found!"); }

            try
            {
                var _user = mapper.Map<User>(user);
                context.Users.Update(_user);
                await context.SaveChangesAsync();
                return Result<User>.PrepareSuccess(_user);
            }
            catch(Exception ex) 
            {return Result<User>.PrepareFailure(ex.ToString());}
        }

        public async Task<Result> DeleteUser(int id)
        {
            if (!IsUserExist(id)) 
            { throw new Exception("User not found!"); }

            try
            {
                var _user = await context.Users
                    .FirstOrDefaultAsync(x => x.Id == id);
                context.Users.Remove(_user);
                await context.SaveChangesAsync();
                return Result.PrepareSuccess();
            }
            catch (Exception ex) 
            { return Result.PrepareFailure(ex.ToString()); }
        }

        public async Task<Result<List<UserInfoDTO>>> GetUser()
        {
            try
            {
                var _user = await context.Users
                    .Select(x => mapper.Map<UserInfoDTO>(x))
                    .ToListAsync();
                return Result<List<UserInfoDTO>>.PrepareSuccess(_user);
            }
            catch (Exception ex) 
            { return Result<List<UserInfoDTO>>
                    .PrepareFailure(ex.ToString()); }
        }

        /////////////////////////////////////////////////////////
        private bool IsUserEmailExist(string name)
        {
            return context.Users.Any(x => x.UserMail == name);
        }

        private bool IsUserExist(int id)
        {
            return context.Users.Any(x => x.Id == id);
        }
    }
}
