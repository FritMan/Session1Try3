using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1Try3.Data
{
    public partial class User
    {
        public string Fio { get
            {
                return $"{Surname}. {Name[0]}. {Patronimic[0]}.";
            } 
        }
    }
}
