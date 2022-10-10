using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Web_Service.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string KD { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Currence { get; set; }

        public int Level { get; set; }

        public int Score { get; set; }


        public string LevelS { get; set; }
        public string ScoreS { get; set; }
        public string IdS { get; set; }

    }
}
