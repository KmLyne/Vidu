using AppLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Service
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login(string username, string password);
    }
}
