using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapelib
    {
        public class rectangle : paint, ishape
        {
            public int length { get; set; }
            public int breadth { get; set; }

            public override double CalculateArea()
            {
                return length + breadth;
            }
            public rectangle(int lenght, int breadth)
            {
                this.length = lenght;
                this.breadth = breadth;
            }
            public string GetDetails()
            {
                return $"lenght of the rectangle is {this.length},breadth is{this.breadth}";
            }
        }

    internal interface ishape
    {
    }
}        