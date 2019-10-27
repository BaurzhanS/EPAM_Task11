using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task2
{
    public class DiagonalMatrix<T> : IMatrix<T>, IChangableMatrix<T> where T : struct
    {
        protected T[] array;

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public T this[int i, int j]
        {
            get
            {
                CheckInputIndexes(i, j);

                if (i != j)
                    return default(T);

                return array[i];
            }
            set
            {
                CheckInputIndexes(i, j);

                var oldValue = array[i];
                array[i] = value;

                OnElementChanged(new ElementChangedEventArgs<T>(i, j, oldValue, value));
            }
        }

        public int Size { get; protected set; }

        public int RowsNum => Size;

        public int ColumnsNum => Size;

        public DiagonalMatrix(int size)
        {
            if (size < 1)
                throw new ArgumentException("Size must be more than zero.");

            Size = size;

            array = new T[size];
        }

        public DiagonalMatrix(T[][] arr)
        {
            CheckInputArray(arr);

            Size = arr.GetLength(0);

            array = new T[Size];

            for (int i = 0; i < Size; i++)
                array[i] = arr[i][i];
        }

        public DiagonalMatrix(T[] arr)
        {
            CheckInputArray(arr);

            Size = arr.Length;

            array = new T[Size];

            for (int i = 0; i < Size; i++)
                array[i] = arr[i];
        }

        protected void OnElementChanged(ElementChangedEventArgs<T> eventArgs)
        {
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs));

            ElementChanged?.Invoke(this, eventArgs);
        }

        protected virtual void CheckInputArray(T[][] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            for (int i = 0; i < arr.GetLength(0); i++)
                if (arr[i] == null)
                    throw new ArgumentNullException(nameof(arr));

            int size = (int)Math.Sqrt(arr.Length);

            if (arr.GetLength(0) != arr[0].Length)
                throw new ArgumentException("Incorrect size of input array.");

            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    bool flag1 = EqualityComparer<T>.Default.Equals(arr[i][j], default(T));
                    bool flag2 = EqualityComparer<T>.Default.Equals(arr[j][i], default(T));

                    if (flag1 && flag2 == false)
                        throw new ArgumentException("Input matrix must be diagonal.");
                }
            }
        }

        protected virtual void CheckInputArray(T[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
        }

        private void CheckInputIndexes(int i, int j)
        {
            if (i < 0 || i >= Size)
                throw new ArgumentOutOfRangeException("Incorrect index of row.");
            if (j < 0 || i >= Size)
                throw new ArgumentOutOfRangeException("Incorrect index of column.");
        }

    }
}
