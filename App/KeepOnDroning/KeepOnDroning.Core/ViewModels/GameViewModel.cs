using System;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace KeepOnDroning.Core.ViewModels
{
    public class GameViewModel : MvxViewModel
    {
        public GameViewModel()
        {
        }

        public ICommand GoBackCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        Close(this);
                    });
            }
        }
    }
}

