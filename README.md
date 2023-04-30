<img src="Assets/Base64-512.png" width=250 />

# Base64 Windows Command Line Conversion Utility

This is a small tool to allow for command line base64 encoding on Windows. The tool provides a number of ways to convert to and from base64 format. 

## Single File Binary Download and Usage

You can download the single file `Base64.exe` file directly from the GitHub site here:

[Base64.exe Single File Exe](https://github.com/RickStrahl/Base64/raw/master/Distribution/Base64.exe)

You can also install this tool as a **Dotnet Tool** with the .NET SDK 6.0 or later (cross platform):

```ps
dotnet tool update -g Westwind.Base64
```

*Note that the Clipboard features (`-c`) do not work in the Dotnet Tool version at this time.*

### Create a Windows File Context Menu Shortcut
Recommended usage is to save the file to a location that is in your Windows path so that you can execute it from anywhere.

It's also useful to add a Explorer File Context Menu Shortcut which lets you interactively create `.b64` files from any file:


```text
Windows Registry Editor Version 5.00

[HKEY_CLASSES_ROOT\*\shell\Base64]
"Command"="C:\\Users\\rstrahl\\Dropbox\\admin\\Base64.exe"
@="Convert to Base64 (.b64)"

[HKEY_CLASSES_ROOT\*\shell\Base64\command]
@="C:\\Users\\rstrahl\\Dropbox\\admin\\Base64.exe \"%1\""
```

Save as `Base64.reg` and double-click in Explorer to add to the registry after which you should see a **Convert to Base64 (.b64)** shortcut on the Explorer File Context Menu.



## Syntax
The command line syntax available is as follows:

```text
Base64 Encoder 0.1
------------------
(c) West Wind Technologies, 2023

Convert files to and from base64.

Syntax
------
Base64  encode|decode  -i inputFile -o outputFile -c toClipboard

Commands
--------
encode              Encode files to base64
decode              Base64 file content to binary output file
decodetext          Decode base64 text to binary output file
HELP || /?          This help display

Input and Output Files
----------------------
-i                  input file (or 2nd parameter w/o -i) (encode,decode)
                    input text  (decodeText)
-o                  output file (or 3rd parameter w/o -o)

Encoding Output
---------------
-c                  encoding output to clipboard
                    decoding input from clipboard
-t                  encoding output to terminal

Examples
--------
base64 encode test.pdf test.pdf.b64 -c -t     // binary file -> b64 file + clipboard +Terminal
base64 decode test.pdf.b64 test_restored.pdf -c -t  // b64 file ->binary file
decodetext -o test_restored.pdf -c    // from clipboard to output file
decodetext -i JVBERi0xLjQKMSAwIG9iago8P== -o test_restored.pdf    // b64 text -> binary output
```


## License
This library is published under **MIT license** terms.

**Copyright &copy; 2023 Rick Strahl, West Wind Technologies**

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.