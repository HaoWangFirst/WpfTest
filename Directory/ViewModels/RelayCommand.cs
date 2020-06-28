using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTest
{
    class RelayCommand : ICommand
    {
        private Action mAction;
        /// <summary>
        /// 当CanExcute函数返回true时事件响应
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender,e)=> { };
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        /// <summary>
        /// 返回true，一直响应事件
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(mAction !=null)
            {
                mAction();
            }
        }
    }
}
