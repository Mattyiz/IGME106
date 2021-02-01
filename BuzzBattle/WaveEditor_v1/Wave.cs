using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveEditor_v1
{
    public class Wave
    {
        // Fields
        public string name;

        public int top;
        public int left;
        public int right;
        public int bottom;

        public bool isSelected;

        public Wave()
        {
            left = 0;
            right = 0;
            top = 0;
            bottom = 0;

            isSelected = true;
        }

        /*public Wave(string name, int top, int left, int right, int bottom)
        {
            //this.ordinal = ordinal;

            //name = "Wave " + ordinal;

            left = 0;
            right = 0;
            top = 0;
            bottom = 0;

            isSelected = true;
        }*/
    }
}
