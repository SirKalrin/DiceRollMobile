using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DiceRollerMobile.Views
{
    public partial class MainPage : ContentPage
    {
        private List<Label> _dices = new List<Label>();
        public int _diceMin { get; set; } = 1;
        public int _diceMax { get; set; } = 6;
        public MainPage()
        {
            InitializeComponent();
            AddStepperListener();
            InitDefaultDices();
        }

        private void InitDefaultDices()
        {
            dices.Children.Add(GetDice());
        }

        private void AddStepperListener()
        {
            diceAmountPicker.ValueChanged += SetDices;
        }

        private void SetDices(object sender, ValueChangedEventArgs valueChangedEventArgs)
        {
            dices.Children.Clear();
            _dices.Clear();
            GetLayoutForDices((int)diceAmountPicker.Value);
        }

        private void GetLayoutForDices(int dices)
        {
            if (dices < 3)
            {
                var diceRow = GetStackLayout();
                for (int i = 0; i < dices; i++)
                {
                    diceRow.Children.Add(GetDice());
                }
                this.dices.Children.Add(diceRow);
            }
            //else if (dices == 4)
            //{
            //    var diceRow1 = GetStackLayout();
            //    var diceRow2 = GetStackLayout();
            //    for (int i = 0; i < dices/2; i++)
            //    {
            //        diceRow1.Children.Add(GetDice());
            //        diceRow2.Children.Add(GetDice());
            //    }
            //    this.dices.Children.Add(GetStackLayout());
            //}
            else
            {
                var diceRow1 = GetStackLayout();
                var diceRow2 = GetStackLayout();
                for (int i = 0; i < dices/2; i++)
                {
                    diceRow1.Children.Add(GetDice());
                    diceRow2.Children.Add(GetDice());
                }
                for (int i = 0; i < dices % 2; i++)
                {
                    diceRow1.Children.Add(GetDice());
                }
                this.dices.Children.Add(diceRow1);
                this.dices.Children.Add(diceRow2);
            }
        }

        private StackLayout GetStackLayout()
        {
            return new StackLayout()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
            };
        }

        private Label GetDice()
        {
            Label dice = new Label() {Text = "1-6"};
            _dices.Add(dice);
            return dice;
        }

        private void RollDices(object sender, EventArgs e)
        {
            Random random = new Random();
            foreach (var dice in _dices)
            {
                dice.Text = random.Next(_diceMin, _diceMax+1).ToString();
            }
        }

        private async void HistoryBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }
    }
}
