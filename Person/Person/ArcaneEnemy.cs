using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class ArcaneEnemy : Person
    {        
        public ArcaneEnemy():base()
        {
            CombatType = CombatStyle.Arcane;
        }

        public ArcaneEnemy(String name, int damage):base()
        {
            _name = name;
            _damage = damage;
            CombatType = CombatStyle.Arcane;
        }

        public ArcaneEnemy(String name, int damage, int health = MAXHEALTH):base()
        {
            _name = name;
            _damage = damage;
            _health = health;
            CombatType = CombatStyle.Arcane;
        }

        // Calculates if the target is weak to attacker
        public int CalculateDamage(Person enemy)
        {

            if (enemy.GetCombatType() == (CombatStyle.Ranged))
            {
                int newDamage = _damage + 2;
                return newDamage;
            }
            else
            {
                return _damage;
            }            
        }

        // basic attack
        public int Shoot(Person enemy)
        {
            if (random.Next(0, 101) > 15) //should be rolling a 0 to 100
            {
                return (CalculateDamage(enemy));
            }
            else return 0;
        }

        // skill 1
        public int MagicMissle(Person enemy)
        {
            skillOneUsed = true;
            if (random.Next(0, 101) > 25) //should be rolling a 0 to 100
            {
                return (CalculateDamage(enemy) + 8);
            }
            else
            {
                return 0; // This would mean they missed
            }
        }

        // skill 2
        public void Heal()
        {
            skillTwoUsed = true;
            if (random.Next(0, 101) > 12) //should be rolling a 0 to 100
            {
                
            }
            else
            {
                Console.WriteLine("Healing Failed.");
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }    
}
