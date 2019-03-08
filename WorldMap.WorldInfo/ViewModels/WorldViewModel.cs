using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using System.Collections.ObjectModel;
using WorldMap.Model;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using WorldMap.WorldInfo.CountryDataServiceReference;

namespace WorldMap.WorldInfo.ViewModels
{
    public class WorldViewModel : NotificationObject
    {
        #region Private Fields

        private ObservableCollection<CountryData> _countryData;
        private IEventAggregator eventAggregator;

        #endregion

        public WorldViewModel(IUnityContainer countryDataService)
        {
            this.eventAggregator = eventAggregator;
            
            //this._countryDataService = countryDataService.Resolve<ICountryDataService>(); ;
            fetchCountryList();
            //var tgb = _countryDataService.SelectAll();
        }

        #region Public Properties

        public ObservableCollection<CountryData> CountryData
        {
            get { return _countryData; }
            set
            {
                _countryData = value;
                RaisePropertyChanged("CountryData");
            }
        }

        #endregion

        #region Private Methods

        private void fetchCountryList()
        {
            //List<CountryData> lstcountryData = _countryDataService.SelectAll();
            //CountryData = new ObservableCollection<CountryData>(lstcountryData);
        }

        #endregion
    }
}
