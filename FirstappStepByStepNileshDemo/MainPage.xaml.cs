using FirstappStepByStepNileshDemo.Views;

namespace FirstappStepByStepNileshDemo;

public partial class MainPage : ContentPage
{
    int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        await TextToSpeech.Default.SpeakAsync("My name is Nilesh");

        //IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();

        //SpeechOptions options = new SpeechOptions()
        //{
        //    Pitch = 1.5f,   // 0.0 - 2.0
        //    Volume = 0.75f, // 0.0 - 1.0
        //    Locale = locales.FirstOrDefault()
        //};

        //await TextToSpeech.Default.SpeakAsync("My name is Nilesh!", options);

        //Navigation.PushAsync(new DemoPage());
        //count++;

        //if (count == 1)
        //	CounterBtn.Text = $"Clicked {count} time";
        //else
        //	CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void ScreenshotBtn_Clicked(object sender, EventArgs e)
    {
        await TakeScreenshotAsync();
    }

    public async Task<ImageSource> TakeScreenshotAsync()
    {
        if (Screenshot.Default.IsCaptureSupported)
        {
            IScreenshotResult screen = await Screenshot.Default.CaptureAsync();

            Stream stream = await screen.OpenReadAsync();

            return ImageSource.FromStream(() => stream);
        }

        return null;
    }

    [assembly: UsesPermission(Android.Manifest.Permission.Flashlight)]
    [assembly: UsesPermission(Android.Manifest.Permission.Camera)]

    private async void FlashlightSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        try
        {
            if (FlashlightSwitch.IsToggled)
                await Flashlight.Default.TurnOnAsync();
            else
                await Flashlight.Default.TurnOffAsync();
        }
        catch (FeatureNotSupportedException ex)
        {
            // Handle not supported on device exception
        }
        catch (PermissionException ex)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to turn on/off flashlight
        }
    }
}

