using MahApps.Metro.Controls;
using System.IO;
using System.Reflection;
using System.Windows;
using XamlAnimatedGif;

namespace GamePlay
{
    public partial class MainWindow : MetroWindow
    {
        private int _health = 0;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _health = 30;
            UpdateHealth();
        }

        private void UpdateHealth(int health = 0)
        {
            _health += health;

            if (_health <= 0)
            {
                MessageBox.Show("Game over", "Wasted", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else if (_health >= 100)
            {
                _health = 100;

                CarrotButton.IsEnabled = false;
                BreadButton.IsEnabled = false;
                PortionButton.IsEnabled = false;
                }
            else
            {
                CarrotButton.IsEnabled = true;
                BreadButton.IsEnabled = true;
                PortionButton.IsEnabled = true;
            }

            var fileName = _health < 50 ? "Media/elf.gif" : "Media/jump.gif";

            if (WeaponToggleButton.IsChecked.GetValueOrDefault())
            {
                fileName = "Media/arrow.gif";
            }

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            AnimationBehavior.SetSourceUri(CharacterMedia, new System.Uri(path));

            this.HealthLabel.Text = _health.ToString();
            this.HealthProgress.Value = _health;
        }

        private void WeaponToggleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateHealth();
        }

        private void CarrotButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateHealth(10);
        }

        private void BreadButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateHealth(20);
        }

        private void PortionButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateHealth(30);
        }

        private void AttackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateHealth(-10);
        }
    }
}