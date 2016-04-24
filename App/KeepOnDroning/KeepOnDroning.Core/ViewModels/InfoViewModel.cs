using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace KeepOnDroning.Core
{
	public class InfoViewModel : MvxViewModel
	{
		public InfoViewModel ()
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