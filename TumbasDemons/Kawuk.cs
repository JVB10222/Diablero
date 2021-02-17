using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumbasLibrary;//Added


namespace TumbasDemons
{
    public class Kawuk : Monster
    {
        //we will be creating a child monster with at least one unique property 

        //fields

        //properties 
        public bool IsScary { get; set; }

        //ctors
        //FQCtor
        public Kawuk(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isScary) : base(name, life, maxLife, hitChance,
                block, minDamage, maxDamage, description)
        {
            //just handle the unique ones
            IsScary = isScary;
        }

        //set some values for a basic monster of this type in the default ctor
        public Kawuk()
        {
            //SET Max Values first!
            MaxLife = 10;
            MaxDamage = 4;
            Name = "Kawuk horde";
            Life = 8;
            HitChance = 20;
            Block = 22;
            MinDamage = 3;
            Description = "The horde tracks you and could smell you enter the room. These reptilian creatures walk on two feet and eat humans.";
            IsScary = false;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + (IsScary ? "Scary" : "Not so Scary");
        }

        //override the block to say if the kawuk is scary they get a bonus 50% to their block
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
