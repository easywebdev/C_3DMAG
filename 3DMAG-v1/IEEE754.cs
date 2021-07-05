using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace _3DMAG_v1
{
    class IEEE754
    {

        /*
         * Function convert 4 bytes array to double (as float single precisio value)
         * Using IEEE 754 standart
         * @param byte[] code - array of 4 or more bytes (uses onle last 4 bytes)
         *        bool reverse - reverse or not bytes array (for standart is true)
         */
        public static double bytesToDouble32(byte[] code, bool reverse)
        {
            float result = 0;

            if(reverse)
            {
                Array.Reverse(code);
            }
                                                                
            result = BitConverter.ToSingle(code, 0);
            
            return (double)result;
        }
        
        /*
         * Function Revers bits on each byte in byte array
         */
        public static byte[] reversBits(byte[] b)
        {
            byte[] result = new byte[b.Length];

            for (int i = 0; i < b.Length; i++)
            {
                result[i] = (byte)((b[i] * 0x0202020202 & 0x010884422010) % 1023);
            }

            return result;
        }
    }
}
