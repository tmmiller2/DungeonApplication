using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Muskox : Monster
    {
        public bool IsBig { get; set; }

        public Muskox(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isBig)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            IsBig = isBig;
        }

        public Muskox()
        {
            Name = "Muskox";
            MaxLife = 28;
            Life = 28;
            HitChance = 40;
            Block = 20;
            MinDamage = 3;
            MaxDamage = 10;
            Description = "It looks scary!";
            IsBig = false;
        }

        public Muskox(string name, int life, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description) : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
        }

        public override string ToString()
        {
            return base.ToString() + (IsBig ? "Big" : "Not so big");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            //Apply a 50% increase to the block if it's big
            if (IsBig)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
