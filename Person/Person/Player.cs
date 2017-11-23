using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Player:Person
    {
        private int special = 0;

        public Player():base()
        {
            CombatType = CombatStyle.Melee; // default to melee
        }

        public Player(String name, CombatStyle style):base()
        {
            _name = name;
            CombatType = style;            
        }

        public int CalculateDamage(Person enemy)
        {
            if ((CombatType == CombatStyle.Melee) && (enemy.GetCombatType() == CombatStyle.Arcane))
            {
                int newDamage = _damage + 2;
                return newDamage;
            }
            else if ((CombatType == CombatStyle.Arcane) && (enemy.GetCombatType() == CombatStyle.Ranged))
            {
                int newDamage = _damage + 4;                
                return newDamage;
            }
            else if ((CombatType == CombatStyle.Ranged) && (enemy.GetCombatType() == CombatStyle.Melee))
            {
                int newDamage = _damage + 4;                
                return newDamage;
            }
            else
            {
                return _damage;
            }
        }
        
        public int Attack(Person enemy)
        {
            if (random.Next(0,101) > 5)
            {
                special += 10;
                return CalculateDamage(enemy);
            }
            special += 5;
            return 0;
        }

        public void Heal()
        {
            skillOneUsed = true;
            if (random.Next(0, 101) > 5) //should be rolling a 0 to 100
            {
                special += 15;
                _health += 20;
                Console.WriteLine("Healed 20 hp.");
            }
            else
            {
                special += 5;
                Console.WriteLine("Healing Failed.");
            }
        }

        public int DoubleAttack(Person enemy)
        {
            skillTwoUsed = true;
            if (random.Next(0, 100) > 23)
            {
                special += 15;
                return (CalculateDamage(enemy) * 2);
            }
            else
            {
                special += 5;
                return (CalculateDamage(enemy) - 2);  // missed second strike but still allowed a single hit with penalty.
            }
        }

        public int Special(Person enemy)  // should be available when health is under 50% and special is at 100? or 75?
        {
            special = 0;
            return CalculateDamage(enemy) * 4;
        }
    }
}
