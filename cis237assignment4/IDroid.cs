﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    interface IDroid : IComparable<Droid>
    {
        //Method to calculate the total cost of a droid
        void CalculateTotalCost();
        new int CompareTo(Droid arr);

        //property to get the total cost of a droid
        decimal TotalCost { get; set; }
        string Model { get; } // ********

    }
}
