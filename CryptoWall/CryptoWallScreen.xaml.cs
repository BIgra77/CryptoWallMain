using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace CryptoWall
{
    /// <summary>
    /// Logique d'interaction pour CryptoWallScreen.xaml
    /// </summary>
    public partial class CryptoWallScreen : Window
    {
        private static Task<LunarCrush.Root> AllData;
        private static List<DataToDisplay> AllDataToDisplay = new List<DataToDisplay>() { };

        public CryptoWallScreen()
        {
            InitializeComponent();
            CryptoWallScreen.AllData = Initialize();
            CryptoWallScreen.AllData = Initialize2();
        }

        private async Task<LunarCrush.Root> Initialize()
        {
            LunarCrush Lune = new LunarCrush();
            info.Text = await Lune.Connect();
            List<string> AllName = new List<string>() { } ;
            LunarCrush.Root tmp = Lune.transfert(info.Text);

            try
            {
                for (int i=0; i<20; i++)
                {
                    AllName.Add(tmp.data[i].name);
                }
                ChoiceComboBox.ItemsSource = AllName;
                
            }
            catch (Exception e)
            {
                name1.Text = e.ToString();
                stockSymbol1.Text = e.ToString();
                price1.Text = e.ToString();
                btc1.Text = e.ToString();
                market1.Text = e.ToString();
            }
            return tmp;
        }
        
        private async Task<LunarCrush.Root> Initialize2()
        {
            LunarCrush Lune = new LunarCrush();
            info.Text = await Lune.Connect();
            List<string> AllName = new List<string>() { } ;
            LunarCrush.Root transf = Lune.transfert(info.Text);

            try
            {
                for (int i=0; i<20; i++)
                {
                    AllName.Add(transf.data[i].name);
                }
                ChoiceComboBox2.ItemsSource = AllName;
                
            }
            catch (Exception e)
            {
                name3.Text = e.ToString();
                stockSymbol3.Text = e.ToString();
                price3.Text = e.ToString();
                btc3.Text = e.ToString();
                market3.Text = e.ToString();
            }
            return transf;
        }

        private void GetCheckBox(Task<LunarCrush.Root> AllData)
        {
            var queryAllDataName = from Data in AllData.Result.data
                                   where Data.name == ChoiceComboBox.Text
                                   select new { Name = Data.name, Price = Data.price, Symbol = Data.symbol, Price_btc = Data.price_btc, Market_cap = Data.market_cap};


            foreach (var item in queryAllDataName)
            {
                name1.Text = item.Name;
                stockSymbol1.Text = item.Symbol;
                price1.Text = "" + item.Price;
                btc1.Text = "" + item.Price_btc;
                market1.Text = "" + item.Market_cap;
            }
        }
        
        private void GetCheckBox2(Task<LunarCrush.Root> AllData)
        {
            var queryAllDataName2 = from Data in AllData.Result.data
                where Data.name == ChoiceComboBox2.Text
                select new { Name = Data.name, Price = Data.price, Symbol = Data.symbol, Price_btc = Data.price_btc, Market_cap = Data.market_cap};


            foreach (var item in queryAllDataName2)
            {
                name3.Text = item.Name;
                stockSymbol3.Text = item.Symbol;
                price3.Text = "" + item.Price;
                btc3.Text = "" + item.Price_btc;
                market3.Text = "" + item.Market_cap;
            }
        }
        //Boutonss
        private void CryptoButton(object sender, RoutedEventArgs e)
        {
            name1.Text = "try Button_Clicked";
            stockSymbol1.Text = "try Button_Clicked";
            price1.Text = "try Button_Clicked";
            btc1.Text = "try Button_Clicked";
            market1.Text = "try Button_Clicked";
            
            GetCheckBox(CryptoWallScreen.AllData);
        }
        
        private void CryptoButton2(object sender, RoutedEventArgs e)
        {
            name3.Text = "try Button_Clicked";
            stockSymbol3.Text = "try Button_Clicked";
            price3.Text = "try Button_Clicked";
            btc3.Text = "try Button_Clicked";
            market3.Text = "try Button_Clicked";
            
            GetCheckBox2(CryptoWallScreen.AllData);
        }
        
        public class DataToDisplay
        {
            public string name { get; set; }
            public double? price { get; set; }
        }

        private void Home_button(object sender, RoutedEventArgs e)
        {
            try
            {
                StartPage p = new StartPage();
                p.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }

}
