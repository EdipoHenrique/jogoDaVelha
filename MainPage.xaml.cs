namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";

        public MainPage()
        {
            InitializeComponent();
        }

        // O "async" e o "await" são necessários para o DisplayAlert funcionar no MAUI atual
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false;
            btn.Text = vez;

            bool ganhou = false;

            /* Verificando se ganhou nas Linhas */
            if (btn10.Text == vez && btn11.Text == vez && btn12.Text == vez) ganhou = true;
            else if (btn20.Text == vez && btn21.Text == vez && btn22.Text == vez) ganhou = true;
            else if (btn30.Text == vez && btn31.Text == vez && btn32.Text == vez) ganhou = true;
            
            /* Verificando se ganhou nas Colunas */
            else if (btn10.Text == vez && btn20.Text == vez && btn30.Text == vez) ganhou = true;
            else if (btn11.Text == vez && btn21.Text == vez && btn31.Text == vez) ganhou = true;
            else if (btn12.Text == vez && btn22.Text == vez && btn32.Text == vez) ganhou = true;
            
            /* Verificando se ganhou nas Diagonais */
            else if (btn10.Text == vez && btn21.Text == vez && btn32.Text == vez) ganhou = true;
            else if (btn12.Text == vez && btn21.Text == vez && btn30.Text == vez) ganhou = true;

            /* Se o jogador da vez ganhou */
            if (ganhou)
            {
                await DisplayAlert("Parabéns!", $"O {vez} ganhou!", "OK");
                Zerar();
            }
            /* Se ninguém ganhou, verifica se deu velha (empate) */
            else if (!btn10.IsEnabled && !btn11.IsEnabled && !btn12.IsEnabled &&
                     !btn20.IsEnabled && !btn21.IsEnabled && !btn22.IsEnabled &&
                     !btn30.IsEnabled && !btn31.IsEnabled && !btn32.IsEnabled)
            {
                await DisplayAlert("Empate!", "Deu velha!", "OK");
                Zerar();
            }
            /* Se o jogo continua, troca a vez */
            else
            {
                if (vez == "X")
                {
                    vez = "O";
                }
                else
                {
                    vez = "X";
                }
            }

        } // Fecha método

        void Zerar()
        {
            btn10.Text = ""; btn10.IsEnabled = true;
            btn11.Text = ""; btn11.IsEnabled = true;
            btn12.Text = ""; btn12.IsEnabled = true;
            
            btn20.Text = ""; btn20.IsEnabled = true;
            btn21.Text = ""; btn21.IsEnabled = true;
            btn22.Text = ""; btn22.IsEnabled = true;
            
            btn30.Text = ""; btn30.IsEnabled = true;
            btn31.Text = ""; btn31.IsEnabled = true;
            btn32.Text = ""; btn32.IsEnabled = true;

            vez = "X"; // Reseta para o X começar sempre
        }

    } // Fecha Classe
} // Fecha Namespace