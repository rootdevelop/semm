using System;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace KeepOnDroning.Core.ViewModels
{
    public class InteractiveMapViewModel : MvxViewModel
    {
        public InteractiveMapViewModel()
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

