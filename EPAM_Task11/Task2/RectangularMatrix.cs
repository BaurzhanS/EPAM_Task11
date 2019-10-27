using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task2
{
    public class RectangularMatrix<T> : IMatrix<T>, IChangableMatrix<T>
        where T : struct
    {
        protected T[][] matrix;

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public T this[int i, int j]
        {
            get
            {
                CheckInputIndexes(i, j);
                return matrix[i][j];
            }
            set
            {
                CheckInputIndexes(i, j);

                var oldValue = matrix[i][j];
                matrix[i][j] = value;

                OnElementChanged(new ElementChangedEventArgs<T>(i, j, oldValue, value));
            }
        }

        public int RowsNum { get; }

        public int ColumnsNum { get; }

        public RectangularMatrix(int rows, int columns)
        {
            CheckInputSizes(rows, columns);

            RowsNum = rows;
            ColumnsNum = columns;

            matrix = new T[rows][];

            for (int i = 0; i < rows; i++)
                matrix[i] = new T[columns];
        }

        public RectangularMatrix(T[][] array)
        {
            CheckInputArray(array);

            RowsNum = array.GetLength(0);
            ColumnsNum = array[0].Length;

            matrix = array;
        }

        public RectangularMatrix(T[] array, int rows, int columns)
        {
            CheckInputArray(array, rows, columns);

            matrix = new T[rows][];
            RowsNum = rows;
            ColumnsNum = columns;

            for (int i = 0; i < rows; i++)
                matrix[i] = new T[columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = array[i * ColumnsNum + j];
                }
        }

        protected void OnElementChanged(ElementChangedEventArgs<T> eventArgs)
        {
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs));

            ElementChanged?.Invoke(this, eventArgs);
        }

        protected virtual void CheckInputArray(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.GetLength(0); i++)
                if (array[i] == null)
                    throw new ArgumentNullException(nameof(array));
        }

        protected virtual void CheckInputArray(T[] array, int i, int j)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Length != i * j)
                throw new ArgumentException("Multiplication of indexes must be equal to array length.");
            if (i < 1 || j < 1)
                throw new ArgumentOutOfRangeException("Indexes must be more than zero.");
        }


        private void CheckInputIndexes(int i, int j)
        {
            if (i < 0 || i >= RowsNum)
                throw new ArgumentOutOfRangeException("Incorrect index of row.");
            if (j < 0 || i >= ColumnsNum)
                throw new ArgumentOutOfRangeException("Incorrect index of column.");
        }

        private void CheckInputSizes(int rows, int columns)
        {
            if (rows < 1)
                throw new ArgumentException("Number of rows must be more then zero.");
            if (columns < 1)
                throw new ArgumentException("Number of coumns must be more then zero.");
        }
    }
}
