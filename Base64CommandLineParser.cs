using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
#if NETFULL
using System.Windows.Forms;
#endif

namespace Westwind.Base64
{
    public class Base64CommandLineParser : CommandLineParser
    {

        public string action;

        public string InputFile { get; set;  }

        public string OutputFile { get; set; }

        public bool SendToClipboard { get; set;  }

        public bool SendToTerminal { get; set;  }

        public bool PrependSpace { get; set; }

        public bool Help { get; set;  }
        public Base64CommandLineParser(string[] args = null, string cmdLine = null)
            : base(args, cmdLine)
        {
        }

        public override void Parse()
        {

            InputFile = ParseStringParameterSwitch("-i");

            if (Arguments.Length > 0 &&
                !FirstParameter.Equals("encode", StringComparison.OrdinalIgnoreCase) &&
                !FirstParameter.Equals("decode", StringComparison.OrdinalIgnoreCase))
            {
                InputFile = Arguments[0];
                FirstParameter = "encode";
            }

            if (string.IsNullOrEmpty(InputFile))
            {
                if (Arguments.Length > 1 && !Arguments[1].StartsWith("-"))
                {
                    InputFile = Arguments[1];
                }
                else
                    InputFile = string.Empty;
            }
           
            
            OutputFile = ParseStringParameterSwitch("-o");
            if (string.IsNullOrEmpty(OutputFile))
            {
                if (Arguments.Length > 2 && !Arguments[2].StartsWith("-") && !Arguments[2].StartsWith("-"))
                {
                    OutputFile = Arguments[2];
                }

            }

            SendToClipboard = ParseParameterSwitch("-c");
            SendToTerminal = ParseParameterSwitch("-t");
            PrependSpace = ParseParameterSwitch("-s");
            Help = ParseParameterSwitch("-h");


            // Only .b64 file is passed 
            if (FirstParameter.Contains(".b64") && string.IsNullOrEmpty(OutputFile))
            {
                InputFile = FirstParameter;
                OutputFile = InputFile.Replace(".b64", "");
            }
            // No output file, but .b64 passed 
            else if (string.IsNullOrEmpty(OutputFile) && InputFile.Contains(".b64"))
            {
                OutputFile = InputFile.Replace(".b64", "");
            }
            // No output file and not to clipboard - assume .b64
            else if (string.IsNullOrEmpty(OutputFile) && !string.IsNullOrEmpty(InputFile) && !SendToClipboard)
            {
                OutputFile = InputFile + ".b64";
            }

            

#if NETFULL
            if (FirstParameter.Equals("decodetext",StringComparison.OrdinalIgnoreCase) && 
                SendToClipboard && 
                string.IsNullOrEmpty(InputFile))
            {
                InputFile = Clipboard.GetText();
            }
#endif

        }


    }
}
