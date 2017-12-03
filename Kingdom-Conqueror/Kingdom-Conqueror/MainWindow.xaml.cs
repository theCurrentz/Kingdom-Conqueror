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

namespace Kingdom_Conqueror
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int warriorClick = 0;
        int wizardClick = 0;
        int archerClick = 0;

        Melee enemy1 = new Melee();
        Caster enemy2 = new Caster();
        Caster enemy3 = new Caster();


        private void Warrior_Click(object sender, RoutedEventArgs e)
        {
            String character = "Melee";
            warriorClick++;
            ChooseHero(character);
        }

        private void Wizard_Click(object sender, RoutedEventArgs e)
        {
            String character = "Caster";
            wizardClick++;
            ChooseHero(character);
        }

        private void Archer_Click(object sender, RoutedEventArgs e)
        {
            String character = "Ranged";
            archerClick++;
            ChooseHero(character);
        }



        public object ChooseHero(String character)
        {
            if (warriorClick == 1 || wizardClick == 1 || archerClick == 1)
            {
                if (Instructions.Text.Equals("Choose your hero."))
                {

                    if (character.Equals("Melee"))
                    {
                        Melee Player = new Melee();
                        Wizard.Visibility = Visibility.Collapsed;
                        Archer.Visibility = Visibility.Collapsed;
                        Warrior.Margin = new Thickness(180,140,0,0);
                    }
                    else if (character.Equals("Ranged"))
                    {
                        Ranged Player = new Ranged();
                        Wizard.Visibility = Visibility.Collapsed;
                        Warrior.Visibility = Visibility.Collapsed;
                        Archer.Margin = new Thickness(180, 140, 0, 0);
                    }
                    else if (character.Equals("Caster"))
                    {
                        Caster Player = new Caster();
                        Archer.Visibility = Visibility.Collapsed;
                        Warrior.Visibility = Visibility.Collapsed;
                        Wizard.Margin = new Thickness(180, 140, 0, 0);
                    }
                    Instructions.Text = "Incoming Enemy. Use an ability to fight.";
                }
            }
            return null;
        }



    }

}
