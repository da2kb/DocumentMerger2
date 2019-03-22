
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {   
            var filenames = new List<string> { "Jan", "Feb", "Mar" };
            Console.WriteLine("Document Merger\n");
            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file>");
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
                return;
            }
            Console.WriteLine("The name of the first file: "+args[0]);
            Console.WriteLine("The name of the second file name: "+args[1]);
           
                int Length = args.Length;
                int c = 0;
                while (c < Length-1)
                {
                    var exist = filenames.IndexOf(args[c]);
                if (exist == -1)
                { 
                    Console.WriteLine("The filename " + args[c] + " does not exist. Please enter another filename:");
                }
                c++;
                }
            string filename = args[args.Length-1] + ".txt";
            StreamWriter sw = new StreamWriter(filename);

            string line1, line2;
            bool success = false;

            StreamReader sr1 = null;
            StreamReader sr2 = null;

            try
            {
                sr1 = new StreamReader(args[0] + ".txt");
                sr2 = new StreamReader(args[1] + ".txt");

                line1 = sr1.ReadToEnd();
                line2 = sr2.ReadToEnd();

                sw.Write(line1 + line2);
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (sr1 != null)
                    sr1.Close();
                if (sr2 != null)
                    sr2.Close();
                if (success)
                    Console.WriteLine(filename + " was successfully saved.");

            }

        }
    }
}
