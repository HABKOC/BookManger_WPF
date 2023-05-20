using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookManger_WPF
{
    /// <summary>
    /// 不用理解，完全照抄即可
    /// </summary>
    
    class RelayCommond:ICommand
    {
        //判断命令是否能够执行
        readonly Func<bool> _canExecute;

        /// <summary>
        /// 命令需要执行的方法
        /// </summary>
        readonly Action _exectue;

        public RelayCommond(Action action,Func<bool> canExecute)
        {
            _exectue = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_exectue == null)
            {
                return true;
            }
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _exectue();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
    }
}
