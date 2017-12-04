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

        int selection = 0;

        Game match = new Game();
        Melee enemy1 = new Melee();
        Ranged enemy2 = new Ranged();
        Caster enemy3 = new Caster();
        NPC player = null;
        NPC target; // to help with the attack section



        private void Warrior_Click(object sender, RoutedEventArgs e)
        {
            String character = "Melee";
            player = (Melee) ChooseHero(character);
            Initialize();
        }

        private void Wizard_Click(object sender, RoutedEventArgs e)
        {
            String character = "Caster";
            player = (Caster) ChooseHero(character);
            Initialize();
        }

        private void Archer_Click(object sender, RoutedEventArgs e)
        {
            String character = "Ranged";
            player = (Ranged) ChooseHero(character);
            Initialize();
        }

        public void Initialize()
        {
            loadEnemy();
            Instructions.Text = "Incoming Enemy. Use an ability to fight.";
            PlayerHP.Text = player._health + "HP";
            Attack.Visibility = Visibility.Visible;
            Ability.Visibility = Visibility.Visible;
        }

        public object ChooseHero(String character)
        {
            selection++;
            if (selection == 1)
            {
                if (Instructions.Text.Equals("Choose your hero."))
                {
                    NPC Player = null;

                    if (character.Equals("Melee"))
                    {
                        Player = new Melee();
                        Wizard.Visibility = Visibility.Collapsed;
                        Archer.Visibility = Visibility.Collapsed;
                        Warrior.Margin = new Thickness(180, 172, 0, 0);
                    }
                    else if (character.Equals("Ranged"))
                    {
                        Player = new Ranged();
                        Wizard.Visibility = Visibility.Collapsed;
                        Warrior.Visibility = Visibility.Collapsed;
                        Archer.Margin = new Thickness(180, 172, 0, 0);
                    }
                    else if (character.Equals("Caster"))
                    {
                        Player = new Caster();
                        Archer.Visibility = Visibility.Collapsed;
                        Warrior.Visibility = Visibility.Collapsed;
                        Wizard.Margin = new Thickness(180, 172, 0, 0);
                    }
                    Archer.IsEnabled = false;
                    Warrior.IsEnabled = false;
                    Wizard.IsEnabled = false;
                    return Player;
                }
                
            }
            return null;

        }

        public void loadEnemy()
        {
            player.ResetHealth(); 
            if (player is Melee)
            {
                if (enemy2._alive)
                {
                    Archer.Visibility = Visibility.Visible;
                    Archer.Margin = new Thickness(320, 172, 0, 0);
                    EnemyHP.Text = enemy2._health + "HP";
                    target = enemy2;

                } else if (enemy3._alive)
                {
                    Wizard.Visibility = Visibility.Visible;
                    Wizard.Margin = new Thickness(320, 172, 0, 0);
                    EnemyHP.Text = enemy3._health + "HP";
                    target = enemy3;
                }
            }
            else if (player is Ranged)
            {
                if (enemy1._alive)
                {
                    Warrior.Visibility = Visibility.Visible;
                    Warrior.Margin = new Thickness(320, 172, 0, 0);
                    EnemyHP.Text = enemy2._health + "HP";
                    target = enemy1;
                }
                else if (enemy3._alive)
                {
                    Wizard.Visibility = Visibility.Visible;
                    Wizard.Margin = new Thickness(320, 172, 0, 0);
                    EnemyHP.Text = enemy3._health + "HP";
                    target = enemy3;
                }

            }
            else if (player is Caster)
            {
                if (enemy1._alive)
                {
                    Warrior.Visibility = Visibility.Visible;
                    Warrior.Margin = new Thickness(320, 172, 0, 0);
                    EnemyHP.Text = enemy1._health + "HP";
                    target = enemy1;
                }
                else if (enemy2._alive)
                {
                    Archer.Visibility = Visibility.Visible;
                    Archer.Margin = new Thickness(320, 172, 0, 0);
                    EnemyHP.Text = enemy2._health + "HP";
                    target = enemy2;
                }

            }
        }

        private void updateHealth(NPC enemy)
        {
            PlayerHP.Text = player._health + "HP";
            EnemyHP.Text = target._health + "HP";
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            player.Attack(target);
            updateHealth(target);
            if (!target._alive)
            {
                loadEnemy();
            }
            else
            {                
                NPC_Attack();
            }
        }

        private void Ability_Click(object sender, RoutedEventArgs e)
        {
            if (!player.skillused)
            {
                player.Skill(target);
            }
            updateHealth(target);
            NPC_Attack();
        }

        private void NPC_Attack()
        {
            if (target.skillused == false && target._health < 40)
            {
                target.Skill(player);
                updateHealth(target);
            }
            else
            {
                target.Attack(player);
                updateHealth(target);
            }
        }
    }

}
