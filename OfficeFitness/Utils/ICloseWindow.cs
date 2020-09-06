using System;

namespace OfficeFitness.Utils
{
    interface ICloseWindow
    {
        Action Close { get; set; }
    }
}
