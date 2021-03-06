using System.Collections.Generic;
using UnityEngine;

namespace Sources.Libraries
{
    public class ColorsLibrary : Library<Color>
    {
        protected override List<Color> ReturnedObjects => new List<Color>() 
            {Color.black, Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow};
    }
}