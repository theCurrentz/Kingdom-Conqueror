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
        public override void ResetHealth()
        {
            this._health = 140;
            skillused = false;
        }

        // Pummel
        public override void Skill(NPC enemy)
        {
            if (random.Next(0, 100) > 5)
            {
                enemy._health -= this._damage + 25;
                skillused = true;
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
