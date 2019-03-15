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

            requestRegion = RegionManager.Regions["ContentRegion"];
        }
        #endregion

        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer123 { get; set; }
        public IModuleManager ModuleManager { get; set; }
        public IRegion requestRegion;
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
            //ModuleManager.LoadModule("WorldModule");
            //var requestInfoRegion = RegionManager.Regions["ContentRegion"];
            //var newView = requestInfoRegion.GetView("ucWorldDetail");
            // As RequestInfoRegion uses ContentControlRegionAdapter so at a time only one view will be activated.
            //requestInfoRegion.Activate(newView);

            //requestInfoRegion.Deactivate(newView);
            
            ModuleManager.LoadModule("WorldModule");
            requestRegion.Activate(requestRegion.GetView("ucWorldDetail"));
        }
        private void loadStatusModule()
        {
            ModuleManager.LoadModule("Geometry2DTo3DModule");
            var requestInfoRegion = RegionManager.Regions["ContentRegion"];
            var newView = requestInfoRegion.GetView("ucGeometry2DTo3D");
            requestInfoRegion.Activate(newView);
        }
        private void loadHardwareModule()
        {
            //ModuleManager.LoadModule("Geometry2DTo3DModule");
            //var requestInfoRegion = RegionManager.Regions["ContentRegion"];
            //var newView = requestInfoRegion.GetView("ucGeometry2DTo3D");
            //requestInfoRegion.Activate(newView);

            ModuleManager.LoadModule("Geometry2DTo3DModule");
            requestRegion.Activate(requestRegion.GetView("ucGeometry2DTo3D"));
        }

        #endregion
    }
}
