using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Windows.Input;

namespace WorldMap.WorldNavigation.ViewModels
{
    public class NavigationViewModel
    {
        #region Private Fields

        private DelegateCommand loadCountryCommand;
        private DelegateCommand loadHardwareCommand;
        private DelegateCommand requestCommand;
        #endregion

        #region Constructor
        public NavigationViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer123 = container;
            loadCountryCommand = new DelegateCommand(loadCountryModule, canLoadCountryModule);
            loadHardwareCommand = new DelegateCommand(loadHardwareModule, canLoadHardwareModule);
            requestCommand = new DelegateCommand(loadStatusModule, canLoadStatusModule);
        }
        #endregion

        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer123 { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion

        #region Command
        public ICommand LoadCountryModuleCommand
        {
            get
            {
                return loadCountryCommand;
            }
        }
        public ICommand LoadHardwareModuleCommand
        {
            get
            {
                return loadHardwareCommand;
            }
        }
        public ICommand RequestModuleCommand
        {
            get
            {
                return requestCommand;
            }
        }
        #endregion

        #region Private Methods


        private bool canLoadHardwareModule()
        {
            return true;
        }
        private bool canLoadCountryModule()
        {
            return true;
        }
        private bool canLoadStatusModule()
        {
            return true;
        }

        private void loadCountryModule()
        {
            // LoadModule method is responsible to load and initialize the module
            // It loads only if module is not initialize already.
            ModuleManager.LoadModule("WorldModule");
            var requestInfoRegion = RegionManager.Regions["ContentRegion"];
            var newView = requestInfoRegion.GetView("WorldDetail");
            // As RequestInfoRegion uses ContentControlRegionAdapter so at a time only one view will be activated.
            requestInfoRegion.Activate(newView);
        }
        private void loadStatusModule()
        {
            ModuleManager.LoadModule("RequestModule");
            var requestInfoRegion = RegionManager.Regions["ContentRegion"];
            var newView = requestInfoRegion.GetView("RequestDetail");
            requestInfoRegion.Activate(newView);
        }
        private void loadHardwareModule()
        {
            ModuleManager.LoadModule("EmployeeModule");
            var requestInfoRegion = RegionManager.Regions["ContentRegion"];
            var newView = requestInfoRegion.GetView("PractiseEmployee");
            requestInfoRegion.Activate(newView);
        }

        #endregion
    }
}
