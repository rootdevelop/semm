using System;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace KeepOnDroning.Core
{
	public class GameViewModel : MvxViewModel
	{
		public GameViewModel ()
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

