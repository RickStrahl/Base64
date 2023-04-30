using System;
using System.IO;
using System.Reflection;
using Westwind.Base64;
using Westwind.Base64.CommandLine;


public class Program
{
    public static string StartupPath { get; set; }


    [STAThread]
    static void Main(string[] args)
    {
        StartupPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        var cmdLine = new Base64CommandLineParser();
        cmdLine.Parse();

        var version = Assembly.GetExecutingAssembly().GetName().Version;
        var ver = version.Major + "." + version.Minor + (version.Build > 0 ? "." + version.Build : string.Empty);

        string text = $"Base64 Encoder {ver}";
        ColorConsole.WriteLine(text, ConsoleColor.Yellow);
        ColorConsole.WriteLine(new string('-', text.Length), ConsoleColor.Yellow);
        ColorConsole.WriteLine("(c) West Wind Technologies, 2023", ConsoleColor.DarkGray);

        if (args == null || args.Length == 0 || args[0] == "HELP" || args[0] == "/?")
        {

            Console.WriteLine("\nConvert files to and from base64.");


            string options = $@"
[cyan]Syntax[/cyan]
------
[yellow]Base64  encode|decode  -i inputFile -o outputFile -c Clipboard[/yellow]

[cyan]Commands[/cyan]
--------
encode              Encode files to base64
decode              Base64 file content to binary output file
decodetext          Decode base64 text to binary output file
HELP || /?          This help display

[cyan]Input and Output Files[/cyan]
----------------------
-i                  input file (or 2nd parameter w/o -i) (encode,decode)
                    input text  (decodeText)
-o                  output file (or 3rd parameter w/o -o)

[cyan]Encoding Output[/cyan]
---------------
-c                  encoding output TO clipboard (Windows only)
                    decoding input FROM clipboard (Windows only)
-t                  encoding output to terminal
-s                  add leading space to output (allow sending Gmail)

[cyan]Examples[/cyan]
--------

base64 test.pdf                               // creates same file with .b64 ext appended
base64 encode test.pdf test.pdf.b64 -c -t     // binary file -> b64 file + clipboard +Terminal
base64 decode test.pdf.b64 test_restored.pdf -c -t  // b64 file ->binary file
decodetext -o test_restored.pdf -c    // from clipboard to output file
decodetext -i JVBERi0xLjQKMSAwIG9iago8P== -o test_restored.pdf    // b64 text -> binary output
";
            ColorConsole.WriteEmbeddedColorLine(options);
        }
        else
        {
            Console.WriteLine();

            var processor = new Base64Processor(cmdLine);
            processor.Process();

            Console.WriteLine();
        }
    }
}
