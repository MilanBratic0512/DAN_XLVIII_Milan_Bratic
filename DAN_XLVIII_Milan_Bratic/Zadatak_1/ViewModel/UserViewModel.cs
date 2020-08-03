using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class UserViewModel : ViewModelBase
    {
        //Creating object that will conect Model and ViewModel (using Entity Framework)
        static Zadatak_48Entities1 context = new Zadatak_48Entities1();
        User uvm;
        MainWindowViewModel mvvm = new MainWindowViewModel();

        public UserViewModel(User uvmOpen, string username)
        {
            uvm = uvmOpen;
            tblorder = new tblOrder();
            //taking JMBG that was forwarded from login form
            tblorder.CustomerJMBG = username;
            //filling list with data from database
            OrderList = GetOrders();
            
        }
        private tblOrder tblorder;
        public tblOrder tblOrder
        {
            get
            {
                return tblorder;
            }
            set
            {
                tblorder = value;
                OnPropertyChanged("tblOrder");
            }
        }
        private List<tblOrder> orderList;
        public List<tblOrder> OrderList
        {
            get
            {
                return orderList;
            }
            set
            {
                orderList = value;
                OnPropertyChanged("OrderList");
            }
        }
        private int napolitana;
        public int Napolitana
        {
            get
            {
                return napolitana;
            }
            set
            {
                napolitana = value;
                OnPropertyChanged("Napolitana");
            }
        }
        private int kapricoza;
        public int Kapricoza
        {
            get
            {
                return kapricoza;
            }
            set
            {
                kapricoza = value;
                OnPropertyChanged("Kapricoza");
            }
        }
        private int margarita;
        public int Margarita
        {
            get
            {
                return margarita;
            }
            set
            {
                margarita = value;
                OnPropertyChanged("Margarita");
            }
        }
        private int sicilijana;
        public int Sicilijana
        {
            get
            {
                return sicilijana;
            }
            set
            {
                sicilijana = value;
                OnPropertyChanged("Sicilijana");
            }
        }
        private int special;
        public int Special
        {
            get
            {
                return special;
            }
            set
            {
                special = value;
                OnPropertyChanged("Special");
            }
        }
        //Taking values that represent price for every meal in database
        static tblPrice napolitanaMeal = (from r in context.tblPrices where r.Meal == "Napolitana" select r).First();
        int napolitanaCost = napolitanaMeal.Price.GetValueOrDefault();

        static tblPrice kapricozaMeal = (from r in context.tblPrices where r.Meal == "Kapricoza" select r).First();
        int kapricozaCost = kapricozaMeal.Price.GetValueOrDefault();

        static tblPrice margaritaMeal = (from r in context.tblPrices where r.Meal == "Margarita" select r).First();
        int margaritaCost = margaritaMeal.Price.GetValueOrDefault();

        static tblPrice sicilijanaMeal = (from r in context.tblPrices where r.Meal == "Sicilijana" select r).First();
        int sicilijanaCost = sicilijanaMeal.Price.GetValueOrDefault();

        static tblPrice specialMeal = (from r in context.tblPrices where r.Meal == "Special" select r).First();
        int speicalCost = specialMeal.Price.GetValueOrDefault();

        //property that represents total cost =>based on input from every text box
        private int totalAmount;
        public int TotalAmount
        {
            get
            {
                return Napolitana * napolitanaCost + Kapricoza * kapricozaCost + Margarita * margaritaCost + Sicilijana * sicilijanaCost + Special * speicalCost;
            }
            set
            {
                totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        private ICommand order;
        public ICommand Order
        {
            get
            {
                if (order == null)
                {
                    order = new RelayCommand(param => OrderExecute(), param => CanOrderExecute());
                }
                return order;
            }
        }
        //method that saves order into database
        private void OrderExecute()
        {
            try
            {
                tblOrder newOrder = new tblOrder();
                //values from text boxes
                newOrder.Napolitana = Napolitana;
                newOrder.Margarita = Margarita;
                newOrder.Kapricoza = Kapricoza;
                newOrder.Sicilijana = Sicilijana;
                newOrder.Special = Special;
                //date and time
                string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                newOrder.OrderDate = text;
                //jmbg that was forwarded into constructor (from login window)
                newOrder.CustomerJMBG = tblorder.CustomerJMBG;
                //status automaticaly set to waiting
                newOrder.OrderStatus = "Waiting";
                newOrder.TotalAmount = TotalAmount;

                context.tblOrders.Add(newOrder);
                context.SaveChanges();
                MessageBox.Show("Order is waiting for approval.");
                OrderList = GetOrders();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanOrderExecute()
        {
            if (EverythingEmpty() == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //method checks if every textbox is empty=>if true=>cant save
        private bool EverythingEmpty()
        {
            if (Napolitana == 0 && Kapricoza == 0 && Margarita == 0 && Special == 0 && Sicilijana == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            uvm.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        /// <summary>
        /// Method takes rows from sql and puts them into list
        /// </summary>
        /// <returns></returns>
        private List<tblOrder> GetOrders()
        {
            List<tblOrder> list = new List<tblOrder>();

            list = context.tblOrders.ToList();

            List<tblOrder> ByUser = new List<tblOrder>();

            foreach (tblOrder item in list)
            {
                if (item.CustomerJMBG == tblorder.CustomerJMBG)
                {
                    ByUser.Add(item);
                }
            }
            return ByUser;
        }
    }
}
