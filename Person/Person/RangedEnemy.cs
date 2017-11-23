using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class RangedEnemy : Person
    {        
        public RangedEnemy() : base()
        {
            CombatType = CombatStyle.Ranged;
        }

        public RangedEnemy(String name, int damage):base()
        {
            _name = name;
            _damage = damage;
            CombatType = CombatStyle.Ranged;
        }

        public RangedEnemy(String name, int damage, int health = MAXHEALTH):base()
        {
            _name = name;
            _damage = damage;
            _health = health;
            CombatType = CombatStyle.Ranged;
        }

        // Calculates if the target is weak to attacker (not sure if it was better to add to person class)
        public int CalculateDamage(Person enemy)
        {

            if (enemy.GetCombatType() == (CombatStyle.Melee))
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
        public int DualShot(Person enemy)
        {
            skillOneUsed = true;
            if (random.Next(0, 101) > 40) //should be rolling a 0 to 100
            {
                return (CalculateDamage(enemy) * 2);
            }
            else
            {
                return 0; // This would mean they missed
            }
        }

        // skill 2
        public Boolean Poison(Person enemy)
        {
            skillTwoUsed = true;
            if (random.Next(0, 101) > 50) //should be rolling a 0 to 100
            {
                return true;
            }
            else
            {
                return false;
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
