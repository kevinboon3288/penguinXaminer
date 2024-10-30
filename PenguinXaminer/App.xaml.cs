using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Runtime.Versioning;
using System.Windows;
using Unity;

namespace PenguinXaminer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<PenguinXaminerMainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            IEventAggregator? eventAggregator = containerRegistry.GetContainer().Resolve<IEventAggregator>();
            IRegionManager _regionManager = containerRegistry.GetContainer().Resolve<IRegionManager>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<XmlReaderModule.XmlReaderModule>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}