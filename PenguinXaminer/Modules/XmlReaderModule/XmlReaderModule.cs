namespace XmlReaderModule
{
    public class XmlReaderModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public XmlReaderModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("XmlReaderContentRegion", typeof(XmlReaderView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<XmlReaderView>();

            ViewModelLocationProvider.Register<XmlReaderView, XmlReaderViewModel>();
        }
    }
}
