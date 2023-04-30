using System;
using System.IO;
#if NETFULL
using System.Windows.Forms;
#endif

namespace Westwind.Base64
{
    public class Base64Processor
    {
        private Base64CommandLineParser CommandLine { get; }

        private string Output { get; set; }

        public Base64Processor(Base64CommandLineParser commandline)
        {
            CommandLine = commandline;
        }

        public void Process()
        {

            if (CommandLine.FirstParameter.Equals("encode", StringComparison.OrdinalIgnoreCase))
            {
                Encode();
            }
            else
            {
                Decode();
            }
        }


        public void Encode()
        {
            Output = Base64Converter.Encode(CommandLine.InputFile);

            if (!string.IsNullOrEmpty(Output) &&
                !string.IsNullOrEmpty(CommandLine.OutputFile))
            {
                File.WriteAllText(CommandLine.OutputFile,
                    (CommandLine.PrependSpace ? " " : "") + Output);
            }

            if (!string.IsNullOrEmpty(Output))
            {

#if NETFULL
                if (CommandLine.SendToClipboard)
                {
                    Clipboard.SetText(Output);
                }
#endif

                if (CommandLine.SendToTerminal)
                {
                    Console.WriteLine();
                    Console.WriteLine(Output);
                }
            }
        }

        public void Decode()
        {
            bool decodeText = CommandLine.FirstParameter.Equals("decodetext", StringComparison.OrdinalIgnoreCase);

            byte[] data = null;
            if (decodeText)
            {
                data = Base64Converter.Decode(CommandLine.InputFile?.Trim());
            }
            else
            {
                string fileText = File.ReadAllText(CommandLine.InputFile);
                data = Base64Converter.Decode(fileText?.Trim());
            }

            File.WriteAllBytes(CommandLine.OutputFile, data);
        }


    }
}