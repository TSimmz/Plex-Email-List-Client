using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatPlex.Common;
using DatPlex.DataModel;
using System.Windows.Input;

namespace DatPlex.ViewModel
{
    public class Add_UserVM : BaseViewModel
    {
        Window Parent;

        public Add_UserVM()
        {

        }

        public Add_UserVM(SharedUser s)
        {
            Name = s.Name;
            Email = s.Email;
        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        DelegateCommand _OK_Cmd;
        public ICommand OK_Cmd
        {
            get
            {
                if (null == _OK_Cmd)
                    _OK_Cmd = new DelegateCommand(OnOK);
                return _OK_Cmd;
            }
        }

        public void OnOK()
        {
            //CHeck name and email and create new Shared User
        }

        DelegateCommand _Cancel_Cmd;
        public ICommand Cancle_Cmd
        {
            get
            {
                if (null == _Cancel_Cmd)
                    _Cancel_Cmd = new DelegateCommand(OnCancel);
                return _Cancel_Cmd;
            }
        }

        public void OnCancel()
        {
            //CHeck name and email and create new Shared User
        }

    }
}
