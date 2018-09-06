using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models.Classes
{
    class Triangle : ShapeBase
    {
        //Properties
        /// <summary>
        /// Returns the perimeter of the triangle
        /// </summary>
        public override double GetPerimeter
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Returns the square of the triangle
        /// </summary>
        public override double GetSquare
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        //METHODS
        /// <summary>
        /// Returns the position of the triangle whithin coordinate querter
        /// </summary>
        /// <returns></returns>
        protected override Point GetMiddlePoint()
        {
            throw new NotImplementedException();
        }
    }
}

