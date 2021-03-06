using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.Ioc;
#if (AADAuth || AADB2CAuth)
using Microsoft.Identity.Client;
#endif

namespace Company.MobileApp.UWP
{
    public class UWPInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Any Platform Specific Implementations that you cannot 
            // access from Shared Code
#if (AADAuth || AADB2CAuth) 
            containerRegistry.RegisterInstance(new UIParent());
#endif
        }
    }
}