using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person
    {
        public enum CombatStyle { Melee, Ranged, Arcane };
        public const int MAXHEALTH = 100;
        protected int _health { get; set; }
        protected int _damage;
        private string _name { get; set; }
        private bool _alive { get; set; }

        public Person()
        {
            _health = MAXHEALTH;
            _name = "Nameless Hero";
            _damage = 5;
            _alive = true;
        }

        public Person(string name, int damage, int health)
        {
            _health = health;
            _name = name;
            _damage = damage;
            _alive = true;
        }

        public Person(string name, int damage)
        {
            _health = MAXHEALTH;
            _name = name;
            _damage = damage;
            _alive = true;
        }

        public Person(string name)
        {
            _health = MAXHEALTH;
            _name = name;
            _damage = 5;
            _alive = true;
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        public virtual int GetDamage()
        {
            return _damage;
        }

        public void Damaged(int ammount)
        {
            _health -= ammount;
            if (_health <=0)
            {
                Killed();
            }
        }

        public void Killed()
        {            
            _alive = false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

    
