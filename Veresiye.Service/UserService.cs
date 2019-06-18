using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veresiye.Data;
using Veresiye.Model;

namespace Veresiye.Service
{
    public class UserService : IUserService
    {
        public readonly IUnitOfWork unifOfWork;
        private readonly IRepository<User> userRepository;
        public UserService(IUnitOfWork ıunitOfWork,IRepository<User> userRepository)
        {
            this.unifOfWork = unifOfWork;
            this.userRepository = userRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User Login(string userName, string password)
        {
            userName = userName.ToLower();
            var user = userRepository.Get(x => x.UserName == userName && x.Password == password);
            return user;
            
        }

        public bool Register(string userName, string password, string confirmPassword)
        {
            userName = userName.ToLower();
            //validasyonlar
           if (password == confirmPassword)
            {
                return false;
            }
            else if(string.IsNullOrEmpty(userName))
            {
                return false;
            }
           else
            {
                var user = userRepository.Get(x => x.UserName == userName);
                if (user != null)
                {
                    return false;
                }
            }
            var newUser = new User();
            newUser.UserName = userName;
            newUser.Password = password;
            userRepository.Insert(newUser);
            unifOfWork.SaveChanges();
            return true;
        }
    }
    public interface IUserService
    {
        User Login(string userName, string password);
        bool Register(string userName, string password, string confirmPassword);
        IEnumerable <User> GetAll();

    }
}
