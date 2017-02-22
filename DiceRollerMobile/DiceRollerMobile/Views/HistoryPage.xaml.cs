using System;
using System.Collections.Generic;
using DiceRollerMobile.Models;
using Xamarin.Forms;

namespace DiceRollerMobile.Views
{
    public partial class HistoryPage : ContentPage
    {
        public List<Roll> Rolls { get; set; }
        public HistoryPage(List<Roll> rolls)
        {
            InitializeComponent();
            Rolls = rolls;
            History.ItemsSource = rolls;
        }

        private void ClearBtn_OnClicked(object sender, EventArgs e)
        {
            Rolls.Clear();
            History.ItemsSource = null;
            History.ItemsSource = Rolls;
        }
    }
}
