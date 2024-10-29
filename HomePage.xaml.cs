using System;
using Microsoft.Maui.Controls;

namespace JackNPoy
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnEnterGameClicked(object sender, EventArgs e)
        {
            // Navigate to the MainPage
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnFAQClicked(object sender, EventArgs e)
        {
            string faqContent =
            "### Game Mechanics\n\n" +
            "1. **Objective**: The goal is to choose an option (Rock, Paper, or Scissors) that defeats your opponent's choice.\n\n" +
            "2. **Choices**: Each player has three choices:\n" +
            "   - Rock (✊) defeats Scissors (✌️)\n" +
            "   - Scissors (✌️) defeats Paper (✋)\n" +
            "   - Paper (✋) defeats Rock (✊)\n\n" +
            "3. **Turns**: The game is played in turns. Player 1 goes first to select their choice, followed by Player 2.\n\n" +
            "4. **Game Flow**:\n" +
            "   - After both players have made their choices, the game will display each player's selection.\n" +
            "   - The result of the game will be displayed: either Player 1 wins, Player 2 wins, or it’s a draw.\n" +
            "   - The game will then reset for another round.\n\n" +
            "5. **Winning Conditions**: The outcome is determined by the choices made by both players. \n\n" +
            "6. **Resetting the Game**: After each round, you can choose to play again. Just click the option you want when it’s your turn.\n\n" +
            "Enjoy playing Jack N Poy!";

            await DisplayAlert("FAQ - Game Mechanics", faqContent, "OK");
        }
    }
}
