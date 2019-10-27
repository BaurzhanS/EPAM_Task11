using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task2
{
    public interface IMatrix<T> where T : struct
    {
        T this[int i, int j] { get; }

        int RowsNum { get; }

        int ColumnsNum { get; }
    }

    public interface IChangableMatrix<T> where T : struct
    {
        event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        T this[int i, int j] { set; }
    }

    public class ElementChangedEventArgs<T> : EventArgs
    {
        public int Row { get; }

        public int Column { get; }

        public T OldValue { get; }

        public T NewValue { get; }

        public ElementChangedEventArgs(int i, int j, T oldValue, T value)
        {
            Row = i;
            Column = j;
            OldValue = oldValue;
            NewValue = value;
        }
    }
}
