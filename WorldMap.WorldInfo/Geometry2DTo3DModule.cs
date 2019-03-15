using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace WorldMap.WorldInfo
{
    public class Geometry2DTo3DModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public Geometry2DTo3DModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            // var view = this.container.Resolve<EmployeeDetail>();
            // this.regionManager.Regions["EmployeeInfoRegion"].Add(view, "EmployeeDetail");

            var view = this.container.Resolve<ucGeometry2DTo3D>();
            this.regionManager.Regions["ContentRegion"].Add(view, "ucGeometry2DTo3D");
        }
    }
}
