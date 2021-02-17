using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumbasLibrary;//Added


namespace TumbasDemons
{
    public class Nahual : Monster
    {
        //we will be creating a child monster with at least one unique property 

        //fields

        //properties 
        public bool IsScary { get; set; }

        //ctors
        //FQCtor
        public Nahual(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isScary) : base(name, life, maxLife, hitChance,
                block, minDamage, maxDamage, description)
        {
            //just handle the unique ones
            IsScary = isScary;
        }

        //set some values for a basic monster of this type in the default ctor
        public Nahual()
        {
            //SET Max Values first!
            MaxLife = 15;
            MaxDamage = 9;
            Name = "Tall Nahual";
            Life = 15;
            HitChance = 15;
            Block = 20;
            MinDamage = 2;
            Description = "A sorcerer once human that has transformed into an animal. It emits a terrifying laughter and grunt. It mocks you.";
            IsScary = false;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + (IsScary ? "Scary" : "Not so Scary");
        }

        //override the block to say if the wendigo is scary they get a bonus 50% to their block
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
