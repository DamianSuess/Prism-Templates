﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApp.Views;
#if (AutofacContainer)
using Autofac;
using Prism.Autofac;
#elif (DryIocContainer)
using DryIoc;
using Prism.DryIoc;
#elif (NinjectContainer)
using Ninject;
using Prism.Ninject;
#else
using Microsoft.Practices.Unity;
using Prism.Unity;
#endif

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/MainPage?todo=Item1&todo=Item2&todo=Item3");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
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
}
