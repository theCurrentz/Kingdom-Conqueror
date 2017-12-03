using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingdom_Conqueror
{
    class Melee : NPC
    {
        public Melee():base()
        {
            this._alive = true;
            this._health = 140;
            this._damage = 10;
        }


        // skill
        public void Pummel(NPC enemy)
        {
            enemy._health -= this._damage + 25;
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
