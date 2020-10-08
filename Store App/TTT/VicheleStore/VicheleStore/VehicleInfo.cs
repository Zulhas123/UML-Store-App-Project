using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VicheleStore
{
    public class VehicleInfo : INotifyPropertyChanged
    {
        public int VehicleID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }

}
