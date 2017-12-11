/*
 * Kingdom Conqueror - Final Project
 * By David and Parker
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        int ini = 0;

        Game match = new Game();
        Melee enemy1 = new Melee();
        Ranged enemy2 = new Ranged();
        Caster enemy3 = new Caster();
        NPC player = null;
        NPC target;



        private void Warrior_Click(object sender, RoutedEventArgs e)
        {
            String character = "Melee";
            player = (Melee)ChooseHero(character);
            Initialize();
        }

        private void Wizard_Click(object sender, RoutedEventArgs e)
        {
            String character = "Caster";
            player = (Caster)ChooseHero(character);
            Initialize();
        }

        private void Archer_Click(object sender, RoutedEventArgs e)
        {
            String character = "Ranged";
            player = (Ranged)ChooseHero(character);
            Initialize();
        }

        public void Initialize()
        {
            ini++;
            loadEnemy();
            if (ini == 1)
            {
                Instructions.Text = "Battle Begins.";
                SkillName.Visibility = Visibility.Visible;
            }
            Attack.Visibility = Visibility.Visible;
            Ability.Visibility = Visibility.Visible;
            PlayerHP.Text = player._health + "HP";
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
            // to have the enemy facing the player
            ScaleTransform flip = new ScaleTransform();
            flip.ScaleX = -1;

            player.ResetHealth(); 
            if (player is Melee)
            {
                if (enemy2._alive)
                {
                    Archer.Visibility = Visibility.Visible;
                    Archer.RenderTransform = flip;
                    Archer.Margin = new Thickness(420, 172, 0, 0);
                    EnemyHP.Text = enemy2._health + "HP";
                    target = enemy2;

                } else if (enemy3._alive)
                {
                    Archer.Visibility = Visibility.Collapsed;                                      
                    Wizard.Visibility = Visibility.Visible;
                    Wizard.RenderTransform = flip;
                    Wizard.Margin = new Thickness(420, 172, 0, 0);
                    EnemyHP.Text = enemy3._health + "HP";
                    target = enemy3;
                }
                else
                {
                    endGame();
                }
            }
            else if (player is Ranged)
            {
                if (enemy1._alive)
                {
                    Warrior.Visibility = Visibility.Visible;
                    Warrior.RenderTransform = flip;
                    Warrior.Margin = new Thickness(420, 172, 0, 0);
                    EnemyHP.Text = enemy2._health + "HP";
                    target = enemy1;
                }
                else if (enemy3._alive)
                {
                    Warrior.Visibility = Visibility.Collapsed;                    
                    Wizard.Visibility = Visibility.Visible;
                    Wizard.RenderTransform = flip;
                    Wizard.Margin = new Thickness(420, 172, 0, 0);
                    EnemyHP.Text = enemy3._health + "HP";
                    target = enemy3;
                }
                else
                {
                    endGame();
                }

            }
            else if (player is Caster)
            {
                if (enemy1._alive)
                {
                    Warrior.Visibility = Visibility.Visible;
                    Warrior.RenderTransform = flip;
                    Warrior.Margin = new Thickness(420, 172, 0, 0);
                    EnemyHP.Text = enemy1._health + "HP";
                    target = enemy1;
                }
                else if (enemy2._alive)
                {
                    Warrior.Visibility = Visibility.Collapsed;
                    Archer.Visibility = Visibility.Visible;
                    Archer.RenderTransform = flip;
                    Archer.Margin = new Thickness(420, 172, 0, 0);
                    EnemyHP.Text = enemy2._health + "HP";
                    target = enemy2;
                }
                else
                {
                    endGame();
                }

            }
            else
            {
                endGame();
            }
        }

        private void updateHealth(NPC enemy)
        {
            enemy.Killed();
            player.Killed();
            if (!player._alive)
            {
                    endGame();
            }
            PlayerHP.Text = player._health + "HP";
            EnemyHP.Text = target._health + "HP";
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            if(!player.Attack(target))
            {                                     //displays that the attack/skill missed
                MissedMessAsync();
            }
            else
            {
                HitMessage();
            }
            updateHealth(target);
            if (!target._alive)
            {
                if(target.Equals(enemy1))
                {
                    Warrior.Visibility = Visibility.Collapsed;
                } else if(target.Equals(enemy2))
                {
                    Archer.Visibility = Visibility.Collapsed;
                }
                else if (target.Equals(enemy3))
                {
                    Wizard.Visibility = Visibility.Collapsed;
                }
                Initialize();
            }
            else
            {                
                NPC_AttackAsync();
            }
        }

        private void Ability_Click(object sender, RoutedEventArgs e)
        {
            if (!player.skillUsed)
            {
                if(!player.Skill(target))
                {                                     //displays that the attack/skill missed
                    MissedMessAsync();
                }
                else
                {
                    HitMessage();
                    Ability.Visibility = Visibility.Hidden;
                    SkillName.Visibility = Visibility.Hidden;
                }
            }
            updateHealth(target);
            if (!target._alive)
            {
                Initialize();
            }
            else
            {
                NPC_AttackAsync();
            }

        }

        private async Task NPC_AttackAsync()
        {
            await Task.Delay(150);
            if (!target.skillUsed && target._health < 40)
            {
                if(!target.Skill(player))
                {
                    MissedMessAsync();
                }
                else
                {
                    HitMessage();
                }
                updateHealth(target);
            }
            else
            {
                if(!target.Attack(player))
                {
                    MissedMessAsync();
                }
                else
                {
                    HitMessage();
                }
                updateHealth(target);
            }
        }

        private async Task HitMessage()
        {
            HitMessage_.Visibility = Visibility.Visible;      
            await Task.Delay(150);
            HitMessage_.Visibility = Visibility.Hidden;            
        }

        private async Task MissedMessAsync()
        {
            MissedMessage.Visibility = Visibility.Visible;      //displays that the attack/skill missed
            await Task.Delay(150);
            MissedMessage.Visibility = Visibility.Hidden;
            
        }

        private void endGame()
        {   if (!player._alive) {
                Instructions.Text = "Game Over.";
            }
            else
            {
                Instructions.Text = "You Won!";
            }
            Archer.Visibility = Visibility.Collapsed;
            Warrior.Visibility = Visibility.Collapsed;
            Wizard.Visibility = Visibility.Collapsed;
            Archer.Visibility = Visibility.Collapsed;
            PlayerHP.Visibility = Visibility.Collapsed;
            EnemyHP.Visibility = Visibility.Collapsed;
            Attack.IsEnabled = false;
            Ability.IsEnabled = false;
            Attack.Visibility = Visibility.Collapsed;
            Ability.Visibility = Visibility.Collapsed;
            SkillName.Visibility = Visibility.Collapsed;
            Exit.Visibility = Visibility.Visible;
        }
        
        private void ReplayButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }

}
