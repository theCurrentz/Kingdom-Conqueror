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
        protected int _damage { get; set; }
        private string _name { get; set; }

        public Person()
        {
            _health = MAXHEALTH;
            _name = "Nameless Hero";
            _damage = 5;
        }

        public Person(string name, int damage, int health)
        {
            _health = health;
            _name = name;
            _damage = damage;
        }

        public Person(string name, int damage)
        {
            _health = MAXHEALTH;
            _name = name;
            _damage = damage;
        }

        public Person(string name)
        {
            _health = MAXHEALTH;
            _name = name;
            _damage = 5;
        }


    }
}

    
