using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWall
{
    public partial class CryptoWallScreen : Window
    {
        private static Task<LunarCrush.Root> AllData;
        private string Info { get; set; }
        public CryptoWallScreen()
        {
            InitializeComponent();
            AllData = Initialize();
            AllData = Initialize2();
        }

        //init for the first combo box in the xaml
        private async Task<LunarCrush.Root> Initialize()
        {
            LunarCrush lunarCrush = new LunarCrush();
            //print out all the info in a hidden box in the xaml so that we can then choose what we want to print out
            //info.Text = await lunarCrush.Connect();

            Info = await lunarCrush.Connect();

            //init the list of cryptocurrencies
            List<string> CryptoName = new List<string>() { } ;

            //send all the crypto data in said hidden box above
            LunarCrush.Root tmp = lunarCrush.transfert(info.Text);
            try
            {
                for (int i=0; i<20; i++)
                {
                    CryptoName.Add(tmp.data[i].name);
                }
                ChoiceComboBox.ItemsSource = CryptoName;
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
        
        //init for the second combo box in the xaml
        private async Task<LunarCrush.Root> Initialize2()
        {
            LunarCrush lunarCrush = new LunarCrush();
            info.Text = await lunarCrush.Connect();
            List<string> CryptoName = new List<string>() { } ;
            LunarCrush.Root transf = lunarCrush.transfert(info.Text);

            try
            {
                for (int i=0; i<20 ; i++)
                {
                    CryptoName.Add(transf.data[i].name);
                }
                ChoiceComboBox2.ItemsSource = CryptoName;
                
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
        
        //get the date from the select crypto and return it in the table
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
        
        //get the date from select crypto and return it in the second table
        private void GetCheckBox2(Task<LunarCrush.Root> AllData)
        {
            var queryAllDataName = from Data in AllData.Result.data
                where Data.name == ChoiceComboBox2.Text
                select new { Name = Data.name, Price = Data.price, Symbol = Data.symbol, Price_btc = Data.price_btc, Market_cap = Data.market_cap};


            foreach (var item in queryAllDataName)
            {
                name3.Text = item.Name;
                stockSymbol3.Text = item.Symbol;
                price3.Text = "" + item.Price;
                btc3.Text = "" + item.Price_btc;
                market3.Text = "" + item.Market_cap;
            }
        }

        //button to validate our choice ("see" button)
        private void CryptoButton(object sender, RoutedEventArgs e) //first button to get info crypto
        {
            name1.Text = "";
            stockSymbol1.Text = "";
            price1.Text = "";
            btc1.Text = "";
            market1.Text = "";
            
            GetCheckBox(AllData);
        }
        
        //second see button
        private void CryptoButton2(object sender, RoutedEventArgs e) //second button to get info crypto
        {
            name3.Text = "";
            stockSymbol3.Text = "";
            price3.Text = "";
            btc3.Text = "";
            market3.Text = "";
            
            GetCheckBox2(AllData);
        }

        //button back home to loop through
        private void Home_button(object sender, RoutedEventArgs e) //button to go back to StartPage
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
