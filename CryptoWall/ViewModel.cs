using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWall
{
    class ViewModel
    {
        private static List<CryptoWallScreen.DataToDisplay> AllDataToDisplay { get; set; }

        public ViewModel(List<CryptoWallScreen.DataToDisplay> DataInList)
        {
            AllDataToDisplay = DataInList;
        }
    }
}
