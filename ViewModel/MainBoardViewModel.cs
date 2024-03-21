using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Market.ViewModel
{
    class MainBoardViewModel
    {
        // Fields

        // Constructor
        public MainBoardViewModel()
        {
            HomeCommand = new BaseViewModelCommand(ExecuteHomeCommand);
        }

        private void ExecuteHomeCommand(object obj)
        {
            
        }

        // Commands
        ICommand HomeCommand { get;}
    }
}
