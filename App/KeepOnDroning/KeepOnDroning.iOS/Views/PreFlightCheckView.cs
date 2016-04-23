using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace KeepOnDroning.iOS
{
	public partial class PreFlightCheckView : MvxViewController
	{
		public PreFlightCheckView() : base("PreFlightCheckView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<PreFlightCheckView, Core.ViewModels.PreFlightCheckViewModel>();
			//set.Bind(Label).To(vm => vm.Hello);
			//set.Bind(TextField).To(vm => vm.Hello);
			set.Apply();
		}
	}
}