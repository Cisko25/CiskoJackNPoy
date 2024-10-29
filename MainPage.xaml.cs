using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace JackNPoy
{
    public partial class MainPage : ContentPage
    {
        private string _player1Choice;
        private string _player2Choice;
        private bool _isPlayer1Turn = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnChoiceButtonClicked(object sender, EventArgs e)
        {
            // Get the choice from the button clicked
            var choice = (sender as Button)?.Text;
            if (choice == null) return;

            if (_isPlayer1Turn)
            {
                // Player 1's turn
                _player1Choice = choice;
                TurnLabel.Text = "Player 2's Turn";
                _isPlayer1Turn = false; // Switch to Player 2's turn
            }
            else
            {
                // Player 2's turn
                _player2Choice = choice;
                TurnLabel.Text = "Game Over";

                // Show loading animation before displaying the result
                LoadingLabel.IsVisible = true;
                await ShowLoadingAnimation();

                // Reveal both players' choices
                Player1ChoiceLabel.Text = $"Player 1 chose: {_player1Choice}";
                Player2ChoiceLabel.Text = $"Player 2 chose: {_player2Choice}";

                // Determine the result after the loading animation
                DetermineResult();

                // Reset for next round
                await ResetGameAfterDelay();
            }
        }

        private async Task ShowLoadingAnimation()
        {
            // Display dots sequentially
            LoadingLabel.Text = "Battling";
            LoadingLabel.IsVisible = true;
            for (int i = 0; i < 3; i++)
            {
                LoadingLabel.Text += ".";
                await Task.Delay(500); // Wait half a second between each dot
            }
            LoadingLabel.IsVisible = false; // Hide after loading
        }

        private void DetermineResult()
        {
            // Check if both players have made their choices
            if (string.IsNullOrEmpty(_player1Choice) || string.IsNullOrEmpty(_player2Choice))
                return;

            string result;
            if (_player1Choice == _player2Choice)
            {
                result = "It's a Draw!";
            }
            else if ((_player1Choice == "✊" && _player2Choice == "✌️") ||
                     (_player1Choice == "✋" && _player2Choice == "✊") ||
                     (_player1Choice == "✌️" && _player2Choice == "✋"))
            {
                result = "Player 1 Wins!";
            }
            else
            {
                result = "Player 2 Wins!";
            }

            // Display the result
            ResultLabel.Text = $"Result: {result}";
        }

        private async Task ResetGameAfterDelay()
        {
            // Show the progress bar and reset it
            ResetProgressBar.IsVisible = true;
            ResetProgressBar.Progress = 0;

            // Wait for 10 seconds while updating the progress bar
            for (int i = 0; i <= 10; i++)
            {
                ResetProgressBar.Progress = i / 10.0; // Update progress bar (0.0 to 1.0)
                await Task.Delay(1000); // Wait for 1 second
            }

            // Clear player choices and reset the turn
            _player1Choice = null;
            _player2Choice = null;
            _isPlayer1Turn = true;

            // Reset labels
            Player1ChoiceLabel.Text = "Player 1 chose: ?";
            Player2ChoiceLabel.Text = "Player 2 chose: ?";
            TurnLabel.Text = "Player 1's Turn";
            ResultLabel.Text = "Result: ?";

            // Hide the progress bar after resetting
            ResetProgressBar.IsVisible = false;
        }
    }
}
