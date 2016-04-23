using System;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace KeepOnDroning.Core
{
	public class CustomLocationViewModel : MvxViewModel
	{
		public CustomLocationViewModel ()
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

