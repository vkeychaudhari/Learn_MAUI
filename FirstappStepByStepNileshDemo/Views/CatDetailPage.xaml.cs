using FirstappStepByStepNileshDemo.Data;

namespace FirstappStepByStepNileshDemo.Views;

[QueryProperty("Name", "name")]
public partial class CatDetailPage : ContentPage
{
    public string Name
    {
        set
        {
            BindingContext = CatData.Cats.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
        }
    }
    public CatDetailPage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        return base.OnBackButtonPressed();
    }
}