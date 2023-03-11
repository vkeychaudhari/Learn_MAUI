using FirstappStepByStepNileshDemo.Data;

namespace FirstappStepByStepNileshDemo.Views;

[QueryProperty("Name", "name")]
public partial class BearDetailPage : ContentPage
{

    public string Name
    {
        set
        {
            BindingContext = BearData.Bears.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
        }
    }
    public BearDetailPage()
	{
		InitializeComponent();
	}
}