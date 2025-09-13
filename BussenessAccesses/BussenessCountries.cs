using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesses;
 

namespace BussenessAccesses
{
    public class clsBussenessCountriesManagement
    {

        public int ID { set; get; }
        public string CountryName { set; get; }

        public clsBussenessCountriesManagement()

        {
            this.ID = -1;
            this.CountryName = "";

        }

        private clsBussenessCountriesManagement(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static clsBussenessCountriesManagement Find(int ID)
        {
            string CountryName = "";

            if (clsDataCountriesManagement.GetCountryInfoByID(ID, ref CountryName))

                return new clsBussenessCountriesManagement(ID, CountryName);
            else
                return null;

        }

        public static clsBussenessCountriesManagement Find(string CountryName)
        {

            int ID = -1;

            if (clsDataCountriesManagement.GetCountryInfoByName(CountryName, ref ID))

                return new clsBussenessCountriesManagement(ID, CountryName);
            else
                return null;

        }

        public static DataTable GetAllCountries()
        {
            return clsDataCountriesManagement.GetAllCountries();

        }

    }
}
