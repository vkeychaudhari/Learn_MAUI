﻿using FirstappStepByStepNileshDemo.Views;

namespace FirstappStepByStepNileshDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell(); //Default Mainpage set AppShell

        //var NavPage = new NavigationPage(new MainPage());
        //NavPage.BarBackground = Colors.Green;
        //NavPage.BarTextColor = Colors.White;
        // MainPage = NavPage; //set default mainpage for navigation
        //MainPage = new FlyoutPageDemo(); //set default FlyoutPage for MainPage
        //MainPage = new TabbedPageDemo(); //set default TabbedPage for Mainpage
        //MainPage = new FlexLayoutDemo(); //set default FlexLayoutDemo for Mainpage
    }

    protected override void OnStart()
    {
        // Handle when your app starts
    }

    protected override void OnSleep()
    {
        // Handle when your app sleeps
    }

    protected override void OnResume()
    {
        // Handle when your app resumes
    }
}
