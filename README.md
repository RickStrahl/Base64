<img src="https://raw.githubusercontent.com/RickStrahl/base64/master/Assets/Base64-512.png" width=200 />

# Base64 Windows Command Line Conversion Utility

This is a small tool to allow for command line base64 encoding. The tool provides a number of ways to convert to and from base64 format. It's useful for script automation and installer scripts or for simply getting base64 output from binary files for pasting etc.

Features:

* Single file executable on Windows
* Cross Platform `dotnet tool`
* File based creation and parsing
* base64 string encoding and decoding support
* StdIo and StdIo input and output support
* Mix and match input and output formats
* Clipboard output (Windows)

The standalone EXE is windows only, while the .NET tool can work cross-platform.

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
@="Convert to Base64 File (.b64)"

[HKEY_CLASSES_ROOT\*\shell\Base64\command]
@="C:\\Users\\rstrahl\\Dropbox\\admin\\Base64.exe \"%1\""
```

Save as `Base64.reg` and double-click in Explorer to add to the registry after which you should see a **Convert to Base64 (.b64)** shortcut on the Explorer File Context Menu.

You can also set up another one to convert a file to Base64 on the clipboard which is useful for other use cases:

```text
Windows Registry Editor Version 5.00

[HKEY_CLASSES_ROOT\*\shell\Base64]
"Command"="C:\\Users\\rstrahl\\Dropbox\\admin\\Base64.exe"
@="Convert to Base64 and place on Clipboard"

[HKEY_CLASSES_ROOT\*\shell\Base64\command]
@="C:\\Users\\rstrahl\\Dropbox\\admin\\Base64.exe \"%1\" -c"
```


## Syntax
The command line syntax available is as follows:

```text
Base64 Encoder
--------------
(c) West Wind Technologies, 2023-2025

Convert files to and from base64.

Syntax
------
Base64  encode|decode|decodetext  -i inputFile -o outputFile -c Clipboard -t Console output

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
-c                  encoding output TO clipboard (Windows only)
                    decoding input FROM clipboard (Windows only)
-t                  encoding output to terminal console output
-s                  add leading space to output (allow sending Gmail)

Examples
--------

base64 test.pdf                               // creates same file with .b64 ext appended
base64 test.pdf -c -t                         // creates output to clipboard and console out
base64 encode test.pdf test.pdf.b64           // binary file -> b64 file + clipboard +Terminal
base64 decode test.pdf.b64 test_restored.pdf  // b64 file ->binary file
base64 decodetext -o test_restored.pdf -c            // from clipboard to output file
base64 decodetext -i JVBERi0xLjQKMSAwIG9iago8P== -o test_restored.pdf    // b64 text -> binary output
```


## License
This library is published under **MIT license** terms.

**Copyright &copy; 2023-2025 Rick Strahl, West Wind Technologies**

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sub-license, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
