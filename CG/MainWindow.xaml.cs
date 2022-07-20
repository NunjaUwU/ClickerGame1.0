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

namespace CG
{
    public partial class MainWindow : Window
    {
        //Version: Alpha

        public float clicks;
        public float points;
        public float cheat;
        public float multi = 1f;
        public int price1 = 100;
        public bool isActive = true;


        public MainWindow()
        {
            InitializeComponent();
        }

        // raised when the mouse pointer moves.
        public void RootCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.None;

            // Get the x and y coordinates of the mouse pointer
            Point p = e.GetPosition(RootCanvas);
            double pX = p.X;
            double pY = p.Y;

            // Set the coordinates of customPointer to the mouse pointer coordinates
            if(this.game.IsMouseOver)
            {
                customPointer.Visibility = Visibility.Visible;
            }
            else
            {
                customPointer.Visibility = Visibility.Hidden;
            }

            Canvas.SetTop(customPointer, pY);
            Canvas.SetLeft(customPointer, pX);
            Cursor = Cursors.None;
        }

        public void Multies()
        {
            if (points  >= price1)
            {
            }
        }

        public void TextBlocks()
        {
            //<brick TextBlock>
                brick.Text = "0";
                brick.Foreground = Brushes.White;
                brick.Background = Brushes.Black;
                brick.FontSize = 30;
            //<brick TextBlock>

            //<Shop Buttons>
                SBT1.Text = "x0.25 Multiplier";//SbT1 = Shop Button TextBlock 1
            //<Shop Buttons>
        }

        public void Commandss(object sender, KeyEventArgs e)
        {
            if(CommandLine.Text == "points + 50" && Keyboard.IsKeyDown(Key.Enter))
            {
                points += 50;
            }
            if (CommandLine.Text == "points + 100" && Keyboard.IsKeyDown(Key.Enter))
            {
                points += 100;
            }
            if (CommandLine.Text == "points + 500" && Keyboard.IsKeyDown(Key.Enter))
            {
                points += 500;
            }

            if (CommandLine.Text == "points - 50" && Keyboard.IsKeyDown(Key.Enter))
            {
                points -= 50;
            }
            if (CommandLine.Text == "points - 100" && Keyboard.IsKeyDown(Key.Enter))
            {
                points -= 100;
            }
            if (CommandLine.Text == "points - 500" && Keyboard.IsKeyDown(Key.Enter))
            {
                points -= 500;
            }

            brick.Text = points.ToString();
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.C) && Keyboard.IsKeyDown(Key.H))
            {
                Commands.Visibility = Visibility.Visible;
                Commands.IsEnabled = true;
            }

            if (Keyboard.IsKeyDown(Key.Escape))
            {
                Commands.Visibility = Visibility.Hidden;
                Commands.IsEnabled = false;
            }
        }

        private void RootCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += HandleKeyPress;
        }

        private void Commands_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += HandleKeyPress;
            window.KeyDown += Commandss;
        }
    }

    public partial class MainWindow
    {
        private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {
            if (points >= price1)
            {
                points -= 50f;
                brick.Text = points.ToString();
            }
        }

        //ShB1 = Shop Button 1
        private void ShB1_Click(object sender, RoutedEventArgs e)
        {
            if (points >= price1)
            {
                multi += 0.25f;
                points -= price1;
                price1 += 45;
                brick.Text = points.ToString();
            }
            test_Tb.Text = "x" + multi.ToString();
        }

        public void Hans_MouseDown(object sender, RoutedEventArgs e)
        {
            if (clicker_Button.IsMouseOver)
            {
                brick.Text = points.ToString();
                points += 1 * multi;
            }
        }

        private void ShopButtonOn_Click(object sender, RoutedEventArgs e)
        {
            if (shopButtonOn.IsMouseOver)
            {
                shopButtonBorder.Visibility = Visibility.Visible;
            }
            Shop.Visibility = Visibility.Visible;
            Shop.IsEnabled = true;
            shopButtonOf.Visibility = Visibility.Visible;
            shopButtonOf.IsEnabled = true;
            shopButtonOn.Visibility = Visibility.Hidden;
            shopButtonOn.IsEnabled = false;
        }

        private void ShopButtonOf_Click(object sender, RoutedEventArgs e)
        {
            Shop.Visibility = Visibility.Hidden;
            Shop.IsEnabled = false;
            shopButtonOn.Visibility = Visibility.Visible;
            shopButtonOn.IsEnabled = true;
            shopButtonOf.Visibility = Visibility.Hidden;
            shopButtonOf.IsEnabled = false;
        }

        private void ShopButtonOf_MouseEnter(object sender, MouseEventArgs e)
        {
            shopButtonBorder.Visibility = Visibility.Visible;
        }

        private void ShopButtonOn_MouseEnter(object sender, MouseEventArgs e)
        {
            shopButtonBorder.Visibility = Visibility.Visible;
        }

        private void ShopButtonOn_MouseLeave(object sender, MouseEventArgs e)
        {
            shopButtonBorder.Visibility = Visibility.Hidden;
        }

        private void ShopButtonOf_MouseLeave(object sender, MouseEventArgs e)
        {
            shopButtonBorder.Visibility = Visibility.Hidden;
        }

        private void Start_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StartMenu.Visibility = Visibility.Hidden;
            StartMenu.IsEnabled = false;
            GameWindow.Visibility = Visibility.Visible;
            GameWindow.IsEnabled = true;
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Resume_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PauseMenu.Visibility = Visibility.Hidden;
            PauseMenu.IsEnabled = false;
            GameWindow.Visibility = Visibility.Visible;
            GameWindow.IsEnabled = true;
        }

        private void PauseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PauseMenu.Visibility = Visibility.Visible;
            PauseMenu.IsEnabled = true;
            GameWindow.Visibility = Visibility.Hidden;
            GameWindow.IsEnabled = false;
        }

        private void OptionButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BackToMainMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PauseMenu.Visibility = Visibility.Hidden;
            PauseMenu.IsEnabled = false;
            StartMenu.Visibility = Visibility.Visible;
            StartMenu.IsEnabled = true;
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
