using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    public class SharedUser : User
    {
        public SharedUser(string u, string e): base(u, e)
        {
            Username = u;
            Email = e;
        }
    }

    public partial class SharedUsers : ObservableCollection<SharedUsers>
    {
        ObservableCollection<SharedUser> _SharedUserList;

        public SharedUsers()
        {
            _SharedUserList = new ObservableCollection<SharedUser>();  
        }
    }
}
