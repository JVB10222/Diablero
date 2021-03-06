﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumbasLibrary;//Added

namespace TumbasDemons
{
    public class Wendigo : Monster
    {
        //we will be creating a child monster with at least one unique property 

        //fields

        //properties 
        public bool IsScary { get; set; }

        //ctors
        //FQCtor
        public Wendigo(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isScary) : base(name, life, maxLife, hitChance,
                block, minDamage, maxDamage, description)
        {
            //just handle the unique ones
            IsScary = isScary;
        }

        //set some values for a basic monster of this type in the default ctor
        public Wendigo()
        {
            //SET Max Values first!
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Swift Wendigo";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It craves human flesh and moves its position faster than your eyes can keep up";
            IsScary = false;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + (IsScary ? "Scary" : "Not so scary");
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
