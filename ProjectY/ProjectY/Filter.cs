using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using AForge.Imaging.Filters;

namespace ProjectY
{
    class Filter
    {
        private FiltersSequence filter;

        public Filter()
        {
            InitializeFilters();
        }

        private void InitializeFilters () {
            filter = new FiltersSequence();
            filter.Add(Grayscale.CommonAlgorithms.BT709);
            filter.Add(new OtsuThreshold());
        }

        public Bitmap applyFilter(Bitmap image)
        {
            if (image != null)
            {
                return filter.Apply(image);
            }
            return null;
        }
    }
}
