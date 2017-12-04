using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kingdom_Conqueror
{
    class NPC
    {
        public Random random = new Random();
        public MainWindow win;
        protected int _damage;
        public int _health { get; set; }
        public bool _alive { get; set; }

        public bool skillUsed = false;

        public NPC()
        {
            _alive = true;

        }

        public virtual void ResetHealth()
        {
            _health = 100;
            skillUsed = false;
        }

        public bool Attack(NPC enemy)
        {
            if (random.Next(0, 100) > 5)
            {
                enemy._health -= this._damage;
                return true;
            }
            else
            {
                return false;
            }
        }


        public virtual bool Skill(NPC enemy)
        {
            enemy._health -= this._damage;
            return true;
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
