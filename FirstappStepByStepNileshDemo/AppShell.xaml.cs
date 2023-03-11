using FirstappStepByStepNileshDemo.Data;
using FirstappStepByStepNileshDemo.Views;
using System.Windows.Input;

namespace FirstappStepByStepNileshDemo;

public partial class AppShell : Shell
{
    Random rand = new Random();
    Dictionary<string, Type> routes = new Dictionary<string, Type>();
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
    public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public ICommand RandomPageCommand => new Command(async () => await NavigateToRandomPageAsync());

    public AppShell()
	{
		InitializeComponent();
        RegisterRoutes();
        BindingContext = this;
    }
    void RegisterRoutes()
    {
        Routes.Add("monkeydetails", typeof(MonkeyDetailPage));
        Routes.Add("beardetails", typeof(BearDetailPage));
        Routes.Add("catdetails", typeof(CatDetailPage));
        Routes.Add("dogdetails", typeof(DogDetailPage));
        Routes.Add("elephantdetails", typeof(ElephantDetailPage));

        foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }
    }

    async Task NavigateToRandomPageAsync()
    {
        string destinationRoute = Routes.ElementAt(rand.Next(0, Routes.Count)).Key;
        string animalName = null;

        switch (destinationRoute)
        {
            case "monkeydetails":
                animalName = MonkeyData.Monkeys.ElementAt(rand.Next(0, MonkeyData.Monkeys.Count)).Name;
                break;
            case "beardetails":
                animalName = BearData.Bears.ElementAt(rand.Next(0, BearData.Bears.Count)).Name;
                break;
            case "catdetails":
                animalName = CatData.Cats.ElementAt(rand.Next(0, CatData.Cats.Count)).Name;
                break;
            case "dogdetails":
                animalName = DogData.Dogs.ElementAt(rand.Next(0, DogData.Dogs.Count)).Name;
                break;
            case "elephantdetails":
                animalName = ElephantData.Elephants.ElementAt(rand.Next(0, ElephantData.Elephants.Count)).Name;
                break;
        }

        ShellNavigationState state = Shell.Current.CurrentState;
        await Shell.Current.GoToAsync($"{state.Location}/{destinationRoute}?name={animalName}");
        Shell.Current.FlyoutIsPresented = false;
    }

    void OnNavigating(object sender, ShellNavigatingEventArgs e)
    {
        // Cancel any back navigation
        //if (e.Source == ShellNavigationSource.Pop)
        //{
        //    e.Cancel();
        //}
    }

    void OnNavigated(object sender, ShellNavigatedEventArgs e)
    {
    }

}
