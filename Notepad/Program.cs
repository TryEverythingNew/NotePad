// Name: xueliang sun ID: 11387859
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }

    public class FibonacciTextReader: System.IO.TextReader
    {
        private BigInteger prev;    // previous line's number
        private BigInteger now;     // current line's number
        private BigInteger swap;    // for computing, we use swap as a temporary variable
        private int cline; // current line
        private int line; // total lines needed

        public FibonacciTextReader( int n)  // initialize
        {
            prev = 0;   
            now = 0;
            swap = 0;
            cline = 0;
            line = n;
        }

        override public string ReadLine()
        {
            
            if (cline >= line)  // return null if we reach the total line required
            {
                return null;
            }

            if( cline == 0) // current line is 1st line
            {
                cline++;
                return "1:" + 0.ToString() + System.Environment.NewLine;
            }
            else if (cline == 1) // current line is 2nd line
            {
                cline++;
                prev = 0;
                now = 1;
                return "2:" + 1.ToString() + System.Environment.NewLine;
            }
            else
            {
                cline++;
                swap = prev + now;  // compute new values for prev and now
                prev = now;
                now = swap;
                return cline.ToString() + ":" + now.ToString() + System.Environment.NewLine;
            }
        }

        override public string ReadToEnd()  // loop to call readline function to read lines from 1st to the end
        {
            StringBuilder sb = new StringBuilder();
            string tmp = ReadLine();
            while ( tmp != null)    // loop to read all lines
            {
                sb.Append(tmp);
                tmp = ReadLine();
            }
            
            return sb.ToString();
        }
    }
}
