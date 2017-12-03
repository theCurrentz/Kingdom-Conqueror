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
        protected int _health { get; set; }
        protected string _name { get; set; }
        private bool _alive { get; set; }

        protected bool skillTwoUsed = false;

        public NPC()
        {
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
            if (_health <= 0)
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
