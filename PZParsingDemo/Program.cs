using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PZParsingDemo
{
    internal static class Program
    {
        private static void Main()
        {
            new System.Threading.Thread(() =>
            {
                new Form1().ShowDialog();
            }).Start();
        }
    }
}
