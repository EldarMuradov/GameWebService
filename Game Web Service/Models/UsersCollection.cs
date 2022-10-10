using Game_Web_Service.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Game_Web_Service.Models
{
    public class UsersCollection : IUsersCollection
    {

        public List<User> Users;

        public UsersCollection() 
        {
            Users = new List<User>(){};
        }

        public IEnumerable<User> GetUsers 
        {
            get 
            {
                return GetAllUsers().Result;
            }
        }


        public async Task<User> GetCurrentUser(int uid)
        {
            User user = new();
            WebRequest request = WebRequest.Create($"http://localhost/ServerPHPCodeBase/GetUserInfoById.php?userId={uid}");
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using StreamReader reader = new(stream);
                string[] str = reader.ReadToEnd().Split('|');
                user.Name = str[0];
                user.Title = str[1];
                user.Id = Convert.ToInt32(str[2]);
                user.Score = Convert.ToInt32(str[3]);
                user.KD = str[4];
                user.Email = str[5];
                user.Password = str[6];
                user.Currence = Convert.ToUInt16(str[7]);
                user.Level = Convert.ToUInt16(str[8]);
            }
            response.Close();
            return user;
        }

        private static async Task<IEnumerable<User>> GetAllUsers()
        {
            List<User> list = new();
            WebRequest request = WebRequest.Create($"http://localhost/ServerPHPCodeBase/GetAllUsers.php");
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using StreamReader reader = new(stream);
                string[] str = reader?.ReadToEnd()?.Split('|');
                for (int i = 0; i < str.Length-5; i+=5)
                {
                    User user = new();
                    user.Name = str[0 + i];
                    user.Title = str[1 + i];
                    user.IdS = str[2 + i];
                    user.ScoreS = str[3 + i];
                    user.LevelS = str[4 + i];
                    list.Add(user);
                }

            }
            response.Close();
            return list;
        }
    }
}
