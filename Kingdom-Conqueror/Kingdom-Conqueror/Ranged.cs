using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingdom_Conqueror
{
    class Ranged : NPC
    {
        public Ranged() : base()
        {
            _alive = true;
            _health = 100;
            _damage = 25;
        }

        public override void ResetHealth()
        {
            this._health = 100;
        }



        // DualShot
        public override void Skill(NPC enemy)
        {
            enemy.Damaged(this._damage + 10);
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
