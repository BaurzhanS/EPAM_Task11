using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAM_Task11.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using Microsoft.CSharp.RuntimeBinder;

namespace EPAM_Task11.Task2.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Size_NegativeSize_ThrowsArgumentException()
        {
            DiagonalMatrix<int> matr;
            matr = new DiagonalMatrix<int>(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TwoDimensionalArray_RectangularArr_ThrowsArgumentException()
        {
            DiagonalMatrix<int> matr;
            int[][] arr =
            {
                new int[] {1, 2, 3, 4},
                new int[] {5, 6, 7, 8},
                new int[] {9, 10, 11, 12}
            };

            matr = new DiagonalMatrix<int>(arr);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OneDimensionalArray_NullRef_ThrowsArgumentException()
        {
            DiagonalMatrix<int> matr;
            int[] arr = null;

            matr = new DiagonalMatrix<int>(arr);
        }

        DiagonalMatrix<int> matr1 = new DiagonalMatrix<int>(
           new int[][]
           {
                new int[] {1, 0, 0},
                new int[] {0, 6, 0},
                new int[] {0, 0, 11}
           }
       );

        [TestMethod]
        public void Add_SumOfTwoMatrices()
        {
            DiagonalMatrix<int> expectedMatrix = new DiagonalMatrix<int>(
                new int[][]
                {
                    new int[] {2, 0, 0},
                    new int[] {0, 12, 0},
                    new int[] {0, 0, 22}
                }
            );

            Func<int, int, int> sumFunc = (int x, int y) => x + y;

            DiagonalMatrix<int> resMatrix = matr1.Add(matr1, sumFunc);

            bool equalFlag = true;

            for (int i = 0; i < resMatrix.Size; i++)
                for (int j = 0; j < resMatrix.Size; j++)
                    if (resMatrix[i, j] != expectedMatrix[i, j])
                        equalFlag = false;

            Assert.IsTrue(equalFlag);
        }

        [TestMethod]
        public void AddDiagonalMatrices_SumOfTwoMatrices()
        {
            DiagonalMatrix<int> expectedMatrix = new DiagonalMatrix<int>(
                new int[][]
                {
                    new int[] {2, 0, 0},
                    new int[] {0, 12, 0},
                    new int[] {0, 0, 22}
                }
            );

            Func<int, int, int> sumFunc = (int x, int y) => x + y;

            DiagonalMatrix<int> resMatrix = matr1.Add(matr1, sumFunc);

            bool equalFlag = true;

            for (int i = 0; i < resMatrix.Size; i++)
                for (int j = 0; j < resMatrix.Size; j++)
                    if (resMatrix[i, j] != expectedMatrix[i, j])
                        equalFlag = false;

            Assert.IsTrue(equalFlag);
        }

        [TestMethod]
        public void AddDiagonalWithSymmetricalMatrices_SumOfTwoMatrices()
        {
            SymmetricalMatrix<int> matr2 = new SymmetricalMatrix<int>(
                new int[][]
                {
                    new int[] {1, 2, 3},
                    new int[] {2, 6, 0},
                    new int[] {3, 0, 11}
                }
            );

            SymmetricalMatrix<int> expectedMatrix = new SymmetricalMatrix<int>(
                new int[][]
                {
                    new int[] {2, 2, 3},
                    new int[] {2, 12, 0},
                    new int[] {3, 0, 22}
                }
            );

            Func<int, int, int> sumFunc = (int x, int y) => x + y;

            SymmetricalMatrix<int> resMatrix = matr1.Add(matr2, sumFunc);

            bool equalFlag = true;

            for (int i = 0; i < resMatrix.Size; i++)
                for (int j = 0; j < resMatrix.Size; j++)
                    if (resMatrix[i, j] != expectedMatrix[i, j])
                        equalFlag = false;

            Assert.IsTrue(equalFlag);
        }

    }
}