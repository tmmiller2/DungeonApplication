using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Wolf : Monster
    {
        public bool SharpTeeth { get; set; }

        public Wolf(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool sharpTeeth)
            : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            SharpTeeth = sharpTeeth;
        }

        public Wolf()
        {
            Name = "Wolf";
            MaxLife = 8;
            Life = 8;
            HitChance = 30;
            Block = 10;
            MinDamage = 1;
            MaxDamage = 4;
            Description = "It's so precious!";
            SharpTeeth = false;
        }

        public Wolf(string name, int life, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, int v1, int v2) : base(name, life, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
        }

        public override string ToString()
        {
            return base.ToString() + (SharpTeeth ? "Sharp" : "Not so sharp");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            //Apply a 50% increase to the Wolf's block if it has sharp teeth
            if (SharpTeeth)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
