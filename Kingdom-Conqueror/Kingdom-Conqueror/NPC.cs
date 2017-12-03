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
        protected bool _alive { get; set; }

        protected bool skillTwoUsed = false;

        public NPC()
        {
            _alive = true;

        }

        public void Attack(NPC enemy)
        {
            enemy._health -= this._damage;
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
