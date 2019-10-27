using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task2
{
    public class SquareMatrix<T> : RectangularMatrix<T> where T : struct
    {
        public int Size { get; protected set; }

        public SquareMatrix(int size) : base(size, size)
        {
            Size = size;
        }

        public SquareMatrix(T[][] array) : base(array)
        {
            Size = array.GetLength(0);
        }

        public SquareMatrix(T[] array)
            : base(array, (int)Math.Sqrt(array.Length), (int)Math.Sqrt(array.Length))
        {
            Size = (int)Math.Sqrt(array.Length);
        }

        protected override void CheckInputArray(T[] array, int i, int j)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int size = (int)Math.Sqrt(array.Length);

            if (size * size != array.Length)
                throw new ArgumentException("Square root of array length must be integer.");
        }

        protected override void CheckInputArray(T[][] array)
        {
            base.CheckInputArray(array);

            if (array.GetLength(0) != array[0].Length)
                throw new ArgumentException("Incorrect size of input array.");
        }
    }
}
