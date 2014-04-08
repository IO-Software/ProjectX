using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using AForge.Imaging.Filters;

namespace ProjectZ
{
    class Filter
    {
        private FiltersSequence filter;
        private FiltersSequence tempFilter;
        private Bitmap filterImage;

        public Filter()
        {
            InitializeFilters();
        }

        private void InitializeFilters()
        {
            filter = new FiltersSequence();
            filter.Add(Grayscale.CommonAlgorithms.BT709);
            filter.Add(new OtsuThreshold());
            tempFilter = new FiltersSequence();
            tempFilter.Add(Grayscale.CommonAlgorithms.BT709);
        }

        public Bitmap applyFilter(Bitmap image)
        {
            filterImage = image;
            if (filterImage != null)
            {
                try
                {
                    return filter.Apply(filterImage);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("in de applyfilter is er een fout opgetreden");
                    /// tijdelijke oplossing door tijdstress. Is niet netjes maar werkt :p
                    return filter.Apply(filterImage);
                }
            }
            return null;
        }

        internal Image applyGrayFilter(Bitmap bitmap)
        {
            return tempFilter.Apply(bitmap);
        }
    }
}
