using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task2
{
    public class SymmetricalMatrix<T> : SquareMatrix<T> where T : struct
    {
        public SymmetricalMatrix(int size) : base(size) { }

        public SymmetricalMatrix(T[][] array) : base(array) { }

        public SymmetricalMatrix(T[] array) : base(array) { }

        protected override void CheckInputArray(T[][] array)
        {
            base.CheckInputArray(array);

            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    if (array[i][j].Equals(array[j][i]))
                    {
                        throw new ArgumentException("Input matrix must be symmetrical.");
                    }
                }
            }
        }

        protected override void CheckInputArray(T[] array, int i, int j)
        {
            base.CheckInputArray(array, i, j);

            for (i = 0; i < Size; i++)
            {
                for (j = i + 1; j < Size; j++)
                {
                    if (array[i * Size + j].Equals(array[j * Size + i]))
                    {
                        throw new ArgumentException("Input matrix must be symmetrical.");
                    }
                }
            }
        }
    }
}
