using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task2
{
    public static class MatrixExtensions
    {
        public static dynamic Add<T>(this IMatrix<T> source, IMatrix<T> other, Func<T, T, T> add)
            where T : struct
        {
            CheckInputData(source, other, add);

            return SumMatrices<T>((dynamic)source, (dynamic)other, add);
        }

        private static DiagonalMatrix<T> SumMatrices<T>(DiagonalMatrix<T> ob1, DiagonalMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new DiagonalMatrix<T>(CalculateSum(ob1, ob2, add));

        private static SymmetricalMatrix<T> SumMatrices<T>(SymmetricalMatrix<T> ob1, SymmetricalMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new SymmetricalMatrix<T>(CalculateSum(ob1, ob2, add));

        private static SymmetricalMatrix<T> SumMatrices<T>(SymmetricalMatrix<T> ob1, DiagonalMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new SymmetricalMatrix<T>(CalculateSum(ob1, ob2, add));

        private static SymmetricalMatrix<T> SumMatrices<T>(DiagonalMatrix<T> ob1, SymmetricalMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new SymmetricalMatrix<T>(CalculateSum(ob1, ob2, add));

        private static SquareMatrix<T> SumMatrices<T>(SquareMatrix<T> ob1, SquareMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new SquareMatrix<T>(CalculateSum(ob1, ob2, add));

        private static SquareMatrix<T> SumMatrices<T>(DiagonalMatrix<T> ob1, SquareMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new SquareMatrix<T>(CalculateSum(ob1, ob2, add));

        private static SquareMatrix<T> SumMatrices<T>(SquareMatrix<T> ob1, DiagonalMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new SquareMatrix<T>(CalculateSum(ob1, ob2, add));

        private static RectangularMatrix<T> SumMatrices<T>(RectangularMatrix<T> ob1, RectangularMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new RectangularMatrix<T>(CalculateSum(ob1, ob2, add));

        private static RectangularMatrix<T> SumMatrices<T>(DiagonalMatrix<T> ob1, RectangularMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new RectangularMatrix<T>(CalculateSum(ob1, ob2, add));

        private static RectangularMatrix<T> SumMatrices<T>(RectangularMatrix<T> ob1, DiagonalMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
            => new RectangularMatrix<T>(CalculateSum(ob1, ob2, add));

        private static T[][] CalculateSum<T>(IMatrix<T> ob1, IMatrix<T> ob2, Func<T, T, T> add) where T : struct
        {
            T[][] res = new T[ob1.RowsNum][];

            for (int i = 0; i < ob1.RowsNum; i++)
                res[i] = new T[ob1.ColumnsNum];

            for (int i = 0; i < ob1.RowsNum; i++)
                for (int j = 0; j < ob1.ColumnsNum; j++)
                    res[i][j] = add(ob1[i, j], ob2[i, j]);

            return res;
        }

        private static void CheckInputData<T>(IMatrix<T> ob1, IMatrix<T> ob2, Func<T, T, T> add)
            where T : struct
        {
            if (ob1 == null)
                throw new ArgumentNullException(nameof(ob1));
            if (ob2 == null)
                throw new ArgumentNullException(nameof(ob2));

            if (ob1.RowsNum != ob2.RowsNum || ob1.ColumnsNum != ob2.ColumnsNum)
                throw new ArgumentException("Matrices must have the same sizes.");
        }
    }
}
