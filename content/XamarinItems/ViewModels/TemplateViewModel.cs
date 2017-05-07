using System;
using System.Linq;
#if (UseMvvmHelpers)
using MvvmHelpers;
#endif
#if (IsIActiveAware)
using Prism;
#endif
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
#if (!UseMvvmHelpers)
using Prism.Mvvm;
#endif
using Prism.Navigation;
using Prism.Services;

namespace MobileApp.ViewModels
{
#if (UseMvvmHelpers)
    #if (IsIActiveAware && IsINavigationAware)
    #if (IsIDestructible)
    public class TemplateViewModel : BaseViewModel, IActiveAware, INavigationAware, IDestructible
    #else
    public class TemplateViewModel : BaseViewModel, IActiveAware, INavigationAware
    #endif
    #elseif (IsIActiveAware)
    public class TemplateViewModel : BaseViewModel, IActiveAware, INavigatingAware, IDestructible
    #if (IsIDestructible)
    #else
    public class TemplateViewModel : BaseViewModel, IActiveAware, INavigatingAware
    #endif
    #elseif (IsINavigatedAware)
    #if (IsIDestructible)
    public class TemplateViewModel : BaseViewModel, INavigatedAware, IDestructible
    #else
    public class TemplateViewModel : BaseViewModel, INavigatedAware
    #endif
    #elseif (IsINavigationAware)
    #if (IsIDestructible)
    public class TemplateViewModel : BaseViewModel, INavigationAware, IDestructible
    #else
    public class TemplateViewModel : BaseViewModel, INavigationAware
    #endif
    #else
    #if (IDestructible)
    public class TemplateViewModel : BaseViewModel, IDestructible
    #else
    public class TemplateViewModel : BaseViewModel
    #endif
    #endif
#else
    #if (IsIActiveAware && IsINavigationAware)
    #if (IsIDestructible)
    public class TemplateViewModel : BindableBase, IActiveAware, INavigationAware, IDestructible
    #else
    public class TemplateViewModel : BindableBase, IActiveAware, INavigationAware
    #endif
    #elseif (IsIActiveAware)
    #if (IsIDestructible)
    public class TemplateViewModel : BindableBase, IActiveAware, INavigatingAware, IDestructible
    #else
    public class TemplateViewModel : BindableBase, IActiveAware, INavigatingAware
    #endif
    #elseif (IsINavigatedAware)
    #if (IsIDestructible)
    public class TemplateViewModel : BindableBase, INavigatedAware, IDestructible
    #else
    public class TemplateViewModel : BindableBase, INavigatedAware
    #endif
    #elseif (IsINavigationAware)
    #if (IsIDestructible)
    public class TemplateViewModel : BindableBase, INavigationAware, IDestructible
    #else
    public class TemplateViewModel : BindableBase, INavigationAware
    #endif
    #else
    #if (IDestructible)
    public class TemplateViewModel : BindableBase, IDestructible
    #else
    public class TemplateViewModel : BindableBase
    #endif
    #endif
#endif
    {
        private INavigationService _navigationService { get; }

        public TemplateViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            #if (UseMvvmHelpers)
            Title = "Template";
            #endif
        }
#if (IsIActiveAware)

        public event EventHandler IsActiveChanged;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, OnIsActiveChanged); }
        }
#endif
#if (IsINavigatingAware || IsIActiveAware || IsINavigationAware)

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
        }
#endif
#if (IsINavigatedAware || IsINavigationAware)

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // TODO: Handle anything tasks you need to now that the page has been pushed to the Navigation Stack
        }
#endif
#if (IsIDestructible)

        public void Destroy()
        {
            // TODO: Dispose of any objects you need to for memory management
        }
#endif
#if (IsIActiveAware)

        private void OnIsActiveChanged()
        {
            #if (UseMvvmHelpers)
            IsBusy = true;
            #endif
            // Notify anything that might be listening to the Event
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
            // TODO: Implement your refresh logic
            #if (UseMvvmHelpers)

            IsBusy = false;
            #endif
        }
#endif
    }
}