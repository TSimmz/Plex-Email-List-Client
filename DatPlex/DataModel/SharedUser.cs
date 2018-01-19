using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    public class SharedUser : User
    {
        public SharedUser(string n, string e): base(n, e)
        {
            Name = n;
            Email = e;
        }
    }
}
