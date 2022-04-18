using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Caribou : Monster
    {
        public bool IsSharp { get; set; }

        public Caribou(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isSharp)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            IsSharp = isSharp;
        }

        public Caribou()
        {
            Name = "Baby Caribou";
            MaxLife = 8;
            Life = 8;
            HitChance = 30;
            Block = 10;
            MinDamage = 1;
            MaxDamage = 4;
            Description = "Awe! Let me pet it!";
            IsSharp = false;
        }

        public override string ToString()
        {
            return base.ToString() + (IsSharp ? "Sharp" : "Not so sharp");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            //Apply a 50% increase to the Caribou's block if it's horns are sharp.
            if (IsSharp)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
