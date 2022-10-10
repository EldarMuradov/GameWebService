using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Web_Service.Models.Interfaces
{
    public interface IUsersCollection
    {
        IEnumerable<User> GetUsers { get; }
        Task<User> GetCurrentUser(int id);
    }
}
