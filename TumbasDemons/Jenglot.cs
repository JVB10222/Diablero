using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumbasLibrary;//Added


namespace TumbasDemons
{
    public class Jenglot : Monster
    {
        //we will be creating a child monster with at least one unique property 

        //fields

        //properties 
        public bool IsScary { get; set; }

        //ctors
        //FQCtor
        public Jenglot(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isScary) : base(name, life, maxLife, hitChance,
                block, minDamage, maxDamage, description)
        {
            //just handle the unique ones
            IsScary = isScary;
        }

        //set some values for a basic monster of this type in the default ctor
        public Jenglot()
        {
            //SET Max Values first!
            MaxLife = 7;
            MaxDamage = 2;
            Name = "Uncaged Jenglot";
            Life = 7;
            HitChance = 20;
            Block = 15;
            MinDamage = 2;
            Description = "A small doll-like creature, It feeds on blood and has escaped captivity. Hungry for more and has its sight set on you.";
            IsScary = false;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + (IsScary ? "Scary" : "Not so Scary");
        }

        //override the block to say if the jenglot is scary they get a bonus 50% to their block
        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsScary)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;

            //return IsFluffy ? base.CalcBlock() + (base.CalcBlock() / 2) : base.CalcBlock();

        }
    }
}
