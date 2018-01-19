using DatPlex.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatPlex.Common
{
    public class Button : BaseViewModel
    {
        private string Name;
        private Action<object> _Action;
        public Button()
        {
        }

        public Button(Action<object> iAction)
        {
            _Action = iAction;
        }
        public Button(Action iAction)
        {
            _Action = new Action<object>(o => iAction());
        }

        private DelegateCommand _Cmd;
        public ICommand Cmd
        {
            get
            {
                if (null == _Cmd)
                    if (null != _Action)
                        _Cmd = new DelegateCommand(_Action);
                //else
                //    throw new NotImplementedException("Cannot use this binding if Action has not been set");
                return _Cmd;
            }
        }

        private bool _IsEnabled = false;
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                OnPropertyChanged();
            }
        }
        private bool _IsVisible = false;
        public bool IsVisible
        {
            get
            {
                return _IsVisible;
            }
            set
            {
                _IsVisible = value;
                OnPropertyChanged();
            }
        }

        public PropertyInfo GetPropertyInfo<TSource, TProperty>(TSource source, Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            return propInfo;
        }
    }
}
