using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task1
{
    public static class DoubleExtensions
    {
        private const int BYTELENGTH = 8;
        private const int DOUBLEBYTELENGTH = BYTELENGTH * 8;

        public static string ToByteString(double number)
        {
            StringBuilder byteString = new StringBuilder();
            StringBuilder temple = new StringBuilder();
            Converter converter = new Converter();
            converter.DoubleView = number;
            long pointer = converter.LongView;

            for (int i = 0; i < DOUBLEBYTELENGTH; i++, pointer >>= 1)
            {
                if ((pointer & 1) == 1)
                {
                    byteString.Insert(0, "1");
                }
                else
                {
                    byteString.Insert(0, "0");
                }
            }

            return byteString.ToString();
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 64)]
        struct Converter
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            private long longView;
            [System.Runtime.InteropServices.FieldOffset(0)]
            private double doubleView;

            public long LongView
            {
                get => this.longView;
            }

            public double DoubleView
            {
                set => this.doubleView = value;
            }
        }
    }

   


}
