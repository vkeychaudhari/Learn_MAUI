using FirstappStepByStepNileshDemo.Data;

namespace FirstappStepByStepNileshDemo.Views;

[QueryProperty("Name", "name")]
public partial class ElephantDetailPage : ContentPage
{
    public string Name
    {
        set
        {
            BindingContext = ElephantData.Elephants.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
        }
    }
    public ElephantDetailPage()
	{
		InitializeComponent();
	}
}