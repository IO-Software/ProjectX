﻿using AForge;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZ
{
    class Wall : VisibleObject, ObjectWithEdge
    {
        public Wall()
        {

        }

        public void updatePosition(List<IntPoint> corners)
        {

        }

        public Bitmap draw(Bitmap image)
        {
            return image;
        }

        public void addEdgesToKeeper()
        {

        }
    }
}
