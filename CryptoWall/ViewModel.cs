using System;
using System.Collections.Generic;

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
