

namespace shapelib
    {
        public class circle : paint, ishape
        {

            public int radius { get; set; }

            public circle(int radius)
            {
                this.radius = radius;
            }
            public string GetDetails()
            {
                return $"radius of the circle is {this.radius}";
            }

            public override double CalculateArea()
            {
                return Math.PI * radius + radius;
            }
        }
    }