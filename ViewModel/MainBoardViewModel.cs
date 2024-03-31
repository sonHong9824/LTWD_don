﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Market.View;
namespace WPF_Market.ViewModel
{
    class MainBoardViewModel : BaseViewModel
    {
        // Fields

        // Constructor
        private Object currentContent = new product();
        public MainBoardViewModel()
        {
            HomeCommand = new BaseViewModelCommand(ExecuteHomeCommand);
            CartCommand = new BaseViewModelCommand(ExecuteCartCommand);
            ShopCommand = new BaseViewModelCommand(ExecuteShopCommand);
            AccountCommand = new BaseViewModelCommand(ExecuteAccountCommand);
        }

        private void ExecuteAccountCommand(object obj)
        {
            CloseDrawerHost(obj);
            CurrentContent = new Myinf();
        }

        private void ExecuteShopCommand(object obj)
        {
            CloseDrawerHost(obj);
            CurrentContent = new ShopUI();
        }

        private void CloseDrawerHost(object obj)
        {
            DrawerHost drawerHost = obj as DrawerHost;
            DrawerHost.CloseDrawerCommand.Execute(null, drawerHost);
        }
        private void ExecuteCartCommand(object obj)
        {
            CloseDrawerHost(obj);
            CurrentContent = new Cart();
        }

        private void ExecuteHomeCommand(object obj)
        {
            CloseDrawerHost(obj);
            CurrentContent = new product();
        }
        // Commands
        public ICommand HomeCommand { get; }
        public ICommand CartCommand { get; }
        public ICommand ShopCommand { get; }
        public ICommand AccountCommand { get; }
        public object CurrentContent
        {
            get { return currentContent; }
            set
            {
                if (currentContent != value)
                {
                    currentContent = value;
                    OnPropertyChanged(nameof(CurrentContent));
                }
            }
        }
    }
}
