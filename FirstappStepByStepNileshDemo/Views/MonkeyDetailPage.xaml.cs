using FirstappStepByStepNileshDemo.ViewModels;

namespace FirstappStepByStepNileshDemo.Views;

public partial class MonkeyDetailPage : ContentPage
{
	public MonkeyDetailPage()
	{
		InitializeComponent();
        BindingContext = new MonkeyDetailViewModel();
    }
}