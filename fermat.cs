
using System;           // MicroSoft Visual Studio Express 2015 for Windows Desktop
using System.Numerics;              // needed for BigInteger
using System.Windows.Forms;         // needed for Clipboard

namespace fermat		            // fermat factoring
{   class Program
    {   [STAThread]                 // needed for Clipboard
        static void Main(string[] args)
        {
            /* Variables ********************************************************************/
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            BigInteger a, b, c, d, n;
            int flag;

            /* Assign Data ******************************************************************/
            n = 224869951114090657;     // p=675730721, q=332780417 (~55 seconds)
            a = Isqrt(n) + 1;
            b = 0;
            c = a * a;
            d = n;
            Console.WriteLine("\t Basic Fermat Factoring n = {0}", n);

            /* Algorithm ********************************************************************/
            do
            {   flag = BigInteger.Compare(c, d);            // test & set flag
                if (flag < 0) c += a++ + a;                 // enlarge "c"
                if (flag > 0) d += b++ + b;                 // enlarge "d"
            } while (flag != 0);

            /* Output Data ******************************************************************/
            Console.WriteLine("\n p = {0}\n q = {1}", a + b, a - b);
            Console.WriteLine(" Press <Enter> to write to Paste Buffer");
            Console.Read(); Console.Read();
            sb.Append(a + b + "\n"); sb.Append(a - b + "\n");   // store in a string
            Clipboard.SetText(sb.ToString());                   // output to clipboard
            Console.Read();
        } //end of Main()

        /* Methods **********************************************************************/
        // Finds the integer square root of a positive number
        private static BigInteger Isqrt(BigInteger num)
        {   if (0 == num) { return 0; }             // Avoid zero divide
            BigInteger n = (num / 2) + 1;           // Initial estimate, never low
            BigInteger n1 = (n + (num / n)) >> 1;   // right shift to divide by 2
            while (n1 < n)
            {   n = n1;
                n1 = (n + (num / n)) >> 1;          // right shift to divide by 2
            }
            return n;
        } // end Isqrt()
    } // end of Program
} // end of namespace
