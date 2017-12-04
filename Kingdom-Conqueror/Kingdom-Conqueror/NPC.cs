using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingdom_Conqueror
{
    class NPC
    {
        public Random random = new Random();
        protected int _damage;
        public int _health { get; set; }
        public bool _alive { get; set; }

        public bool skillused = false;

        public NPC()
        {
            _alive = true;

        }

        public virtual void ResetHealth()
        {
            _health = 100;
            skillused = false;
        }

        public void Attack(NPC enemy)
        {

            if (random.Next(0, 100) > 10)
            {
                enemy.Damaged(_damage);
            }
            else
            {
                //throw a missed message?
            }
        }

        public void Damaged(int ammount)
        {
            _health = _health - ammount;
            if (_health <= 0)
            {
                Killed();
            }
        }

        public virtual void Skill(NPC enemy)
        {
            enemy.Damaged(this._damage);
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
