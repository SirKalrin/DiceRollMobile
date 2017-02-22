using System;
using System.Collections.Generic;
using System.Linq;
using DiceRollerMobile.Models;
using Xamarin.Forms;

namespace DiceRollerMobile.Views
{
    public partial class MainPage : ContentPage
    {
        //private List<Dice> _dices = new List<Dice>();
        public List<Roll> Rolls { get; set; } = new List<Roll>();

        public MainPage()
        {
            InitializeComponent();
            AddStepperListener();
            InitDefaultDices();
        }

        //This method creates the inital default dices to be used when the game starts and visualizes them.
        private void InitDefaultDices()
        {
            dices.Children.Add(VisualizeDice(GetDice()));
        }

        //This method returns a label with properties based on the given dice
        private Label VisualizeDice(Dice dice)
        {
            if (dice.Val == null)
            return new Label() {Text = $"({dice.MinVal},{dice.MaxVal})"};
            return new Label() {Text = dice.Val.ToString()};
        }

        //This method listens for changes on no. dices and sets corresponding dices.
        private void AddStepperListener()
        {
            diceAmountPicker.ValueChanged += SetDices;
        }

        //This method clears all dices from stacklayout and list of dices and adds new no. of dices
        private void SetDices(object sender, ValueChangedEventArgs valueChangedEventArgs)
        {
            dices.Children.Clear();
            //_dices.Clear();

            GetLayoutForDices(CreateDices((int)diceAmountPicker.Value));
        }

        private void GetLayoutForDices(List<Dice> rolledDices)
        {
            if (rolledDices.Count < 3)
            {
                var diceRow = GetStackLayout();
                for (int i = 0; i < rolledDices.Count; i++)
                {
                    diceRow.Children.Add(VisualizeDice(rolledDices[i]));
                }
                this.dices.Children.Add(diceRow);
            }
            else
            {
                var diceRow1 = GetStackLayout();
                var diceRow2 = GetStackLayout();
                for (int i = 0; i < rolledDices.Count-1;)
                {
                    diceRow1.Children.Add(VisualizeDice(rolledDices[i++]));
                    diceRow2.Children.Add(VisualizeDice(rolledDices[i++]));
                }
                for (int i = 0; i < rolledDices.Count % 2; i++)
                {
                    diceRow1.Children.Add(VisualizeDice(rolledDices[i]));
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

        private List<Dice> CreateDices(int count)
        {
            //_dices.Clear();
            var dices = new List<Dice>();
            for (int i = 0; i < count; i++)
            {
                dices.Add(GetDice());
            }
            return dices;
        }

        private Dice GetDice()
        {
            Dice dice = new Dice();
            //_dices.Add(dice);
            return dice;
        }

        private void RollDices(object sender, EventArgs e)
        {
            var roll = new Roll(CreateDices((int)diceAmountPicker.Value));
            dices.Children.Clear();
            GetLayoutForDices(roll.Dices);
            Rolls.Add(roll);
        }

        private async void HistoryBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage(Rolls));
        }
    }
}
