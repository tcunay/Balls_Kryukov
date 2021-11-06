using System.Collections.Generic;
using UnityEngine;

namespace Sources.Libraries
{
    public class ColorLibraries : Libraries<Color>
    {
        protected override List<Color> ReturnedObjects => new List<Color>() 
            {Color.black, Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow};
    }
}