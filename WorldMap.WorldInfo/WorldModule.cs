﻿using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace WorldMap.WorldInfo
{
    public class WorldModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public WorldModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            // var view = this.container.Resolve<EmployeeDetail>();
            // this.regionManager.Regions["EmployeeInfoRegion"].Add(view, "EmployeeDetail");

            var view = this.container.Resolve<ucWorldDetail>();
            this.regionManager.Regions["ContentRegion"].Add(view, "ucWorldDetail");
        }
    }
}
