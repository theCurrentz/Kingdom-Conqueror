using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kingdom_Conqueror
{
    class Caster : NPC
    {
        public Caster():base()
        {
            this._alive = true;
            this._health = 90;
            this._damage = 30;
        }

        public override void ResetHealth()
        {
            this._health = 90;
            skillUsed = false;
        }

        // Heal
        public override bool Skill(NPC enemy)   //still targets enemy so it can be an override vs overload method
        {
            if (random.Next(0, 100) > 5)
            {
                this._health += 40;
                skillUsed = true;
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
