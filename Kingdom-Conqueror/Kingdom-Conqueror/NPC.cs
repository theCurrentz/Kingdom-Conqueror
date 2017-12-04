using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingdom_Conqueror
{
    class NPC
    {
        protected int _damage;
        public int _health { get; set; }
        public bool _alive { get; set; }

        public bool skillTwoUsed = false;

        public NPC()
        {
            _alive = true;

        }

        public virtual void ResetHealth()
        {
            _health = 100;
        }

        public void Attack(NPC enemy)
        {
            enemy._health -= this._damage;
        }


        public virtual void Skill(NPC enemy)
        {
            enemy._health -= this._damage;
        }

        public void Killed()
        {
            if (this._health <= 0)
            {
                this._alive = false;
            }
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
