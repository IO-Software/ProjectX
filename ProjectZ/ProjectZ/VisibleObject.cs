using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZ
{
    interface VisibleObject
    {
        Bitmap draw(Bitmap image);
        Boolean canBeDrawn();
    }
}
