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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool xTurn;
        public List<Button> xListButton = new List<Button>();
        public List<Button> oListButton = new List<Button>();
                

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }


        private void InitializeGame()
        {
            xTurn = true;
            uxTurn.Text = "X's turn";
            foreach (Button button in uxGrid.Children)
            {
                button.Content = null;
                button.IsEnabled = true;
            }
            xListButton = new List<Button>();
            oListButton = new List<Button>();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            InitializeGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (xTurn)
            {
                button.Content = "X";
                button.IsEnabled = false;

                xListButton.Add(button);

                uxTurn.Text = "O's turn";
                testIfWin(xTurn);
                xTurn = false;
            }
            else
            {
                button.Content = "O";
                button.IsEnabled = false;
                oListButton.Add(button);


                uxTurn.Text = "X's turn";
                testIfWin(xTurn);
                xTurn = true;
            }
        }


        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void testIfWin(bool isxTurn)
        {
            if (isxTurn)
            {
                List<string> xstrList = new List<string>();
                List<string> ystrList = new List<string>();
                List<string> XYstrList = new List<string>();

                foreach (var bt in xListButton)
                {
                    xstrList.Add((bt.Tag.ToString()[0]).ToString());
                    ystrList.Add((bt.Tag.ToString()[2]).ToString());
                    XYstrList.Add(bt.Tag.ToString());
                }

                if ((XYstrList.Contains("0,0") && XYstrList.Contains("1,1") && XYstrList.Contains("2,2")) || (XYstrList.Contains("0,2") && XYstrList.Contains("1,1") && XYstrList.Contains("2,0")))
                {
                    uxTurn.Text = "X Wins";
                    MessageBox.Show("X Wins");
                    
                    GameOver();
                    return;
                }



                var group = xstrList.GroupBy(i => i);
                foreach (var g in group)
                {
                    if (g.Count() == 3)
                    {
                        uxTurn.Text = "X Wins";
                        MessageBox.Show("X Wins");
                        
                        GameOver();
                        return;
                    }
                }

                group = ystrList.GroupBy(i => i);
                foreach (var g in group)
                {
                    if (g.Count() == 3)
                    {
                        uxTurn.Text = "X Wins";
                        MessageBox.Show("X Wins");
                        
                        GameOver();
                        return;
                    }
                }
            }
            else
            {
                List<string> xstrList = new List<string>();
                List<string> ystrList = new List<string>();
                List<string> XYstrList = new List<string>();

                foreach (var bt in oListButton)
                {
                    xstrList.Add((bt.Tag.ToString()[0]).ToString());
                    ystrList.Add((bt.Tag.ToString()[2]).ToString());
                    XYstrList.Add(bt.Tag.ToString());
                }

                if ((XYstrList.Contains("0,0") && XYstrList.Contains("1,1") && XYstrList.Contains("2,2")) || (XYstrList.Contains("0,2") && XYstrList.Contains("1,1") && XYstrList.Contains("2,0")))
                {
                    uxTurn.Text = "O Wins";
                    MessageBox.Show("O Wins");
                    
                    GameOver();
                    return;
                }

                var group = xstrList.GroupBy(i => i);
                foreach (var g in group)
                {
                    if (g.Count() == 3)
                    {
                        uxTurn.Text = "O Wins";
                        MessageBox.Show("O Wins");
                       
                        GameOver();
                        return;
                    }
                }

                group = ystrList.GroupBy(i => i);
                foreach (var g in group)
                {
                    if (g.Count() == 3)
                    {
                        MessageBox.Show("O Wins");
                        uxTurn.Text = "O Wins";
                        GameOver();
                        return;
                    }
                }
            }







        }

        private void GameOver()
        {
            foreach (Button button in uxGrid.Children)
            {
                button.IsEnabled = false;
            }
        }



    }
}
