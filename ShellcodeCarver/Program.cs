using Iced.Intel;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShellcodeCarver
{
    class Program
    {

        static void Main(string[] args)
        {
            
            // Set default badChars if no arg entered
            int[] badChars = {0x00, 0x0a, 0x0d, 0x2f, 0x3a, 0x3f, 0x40, 0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87,
               0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e, 0x8f, 0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96,
               0x97, 0x98, 0x99, 0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f, 0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5,
               0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf, 0xb0, 0xb1, 0xb2, 0xb3, 0xb4,
               0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf, 0xc0, 0xc1, 0xc2, 0xc3,
               0xc4, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcc, 0xcd, 0xce, 0xcf, 0xd0, 0xd1, 0xd2,
               0xd3, 0xd4, 0xd5, 0xd6, 0xd7, 0xd8, 0xd9, 0xda, 0xdb, 0xdc, 0xdd, 0xde, 0xdf, 0xe0, 0xe1,
               0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef, 0xf0,
               0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff };

            // Set default all available character space hex list
            int[] allChars = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a,
              0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15,
              0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f, 0x20,
              0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x2b,
              0x2c, 0x2d, 0x2e, 0x2f, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36,
              0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 0x40, 0x41,
              0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c,
              0x4d, 0x4e, 0x4f, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57,
              0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f, 0x60, 0x61, 0x62,
              0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d,
              0x6e, 0x6f, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78,
              0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x7f, 0x80, 0x81, 0x82, 0x83,
              0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e,
              0x8f, 0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99,
              0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f, 0xa0, 0xa1, 0xa2, 0xa3, 0xa4,
              0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf,
              0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba,
              0xbb, 0xbc, 0xbd, 0xbe, 0xbf, 0xc0, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5,
              0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcc, 0xcd, 0xce, 0xcf, 0xd0,
              0xd1, 0xd2, 0xd3, 0xd4, 0xd5, 0xd6, 0xd7, 0xd8, 0xd9, 0xda, 0xdb,
              0xdc, 0xdd, 0xde, 0xdf, 0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6,
              0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef, 0xf0, 0xf1,
              0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc,
              0xfd, 0xfe, 0xff };

            // Pre initialise List for available characters
            List<int> availableChars = new List<int>();

            List<string> carvedCode = new List<string>();

            // Handle command line args
            var cmdArgs = new CommandLineApplication();
            CommandOption argSc = cmdArgs.Option("-s | --shellcode <value>", "Enter Shellcode as opcode format (e.g. \\x64\\x01)", CommandOptionType.SingleValue);
            CommandOption argEspStart = cmdArgs.Option("-e | --esp-start <value>", "Enter ESP address value at start of carved shellcode", CommandOptionType.SingleValue);
            CommandOption argEspEnd = cmdArgs.Option("-d | --esp-end <value>", "Enter stack address value to write carved shellcode (allow for sufficient space for carved shellcode side)", CommandOptionType.SingleValue);
            CommandOption argBadChars = cmdArgs.Option("-b | --bad-chars <value>", "Enter the bad characters withg the hex format separated by spaces, e.g. \"0x00 0x01 0xff\" or \"00 01 ff\"", CommandOptionType.SingleValue);
            CommandOption argFormat = cmdArgs.Option("-f | --format <value>", "Enable this option to preformat variable as C or P(ython)", CommandOptionType.SingleValue);
            CommandOption argArch = cmdArgs.Option("--x64", "Enable this option for x64 based payload carving", CommandOptionType.NoValue);
            CommandOption argDebug = cmdArgs.Option("--debug", "Enable this option for basic debugging/verbose output", CommandOptionType.NoValue);

            cmdArgs.HelpOption("-? | -h | --help");
            cmdArgs.Execute(args);

            // Write Help if -h or not all required options entered
            if (args.Contains("-h"))
            {
                System.Environment.Exit(0);
            }
            else if (!(argSc.HasValue() || argEspStart.HasValue() || argEspEnd.HasValue()))
            {
                cmdArgs.ShowHelp();
                System.Environment.Exit(0);
            }

            // Parse badChar args to int[]
            if (argBadChars.HasValue())
            {
                var results = new List<int>();
                foreach (string x in argBadChars.Value().Replace("0x", "").Split(" ")){
                    int y = Convert.ToInt32(x, 16);
                    results.Add(y);
                }
                badChars = results.ToArray();
            }

            // Set arg variables
            string sc = argSc.Value();
            string startEsp = argEspStart.Value();
            string destEsp = argEspEnd.Value();

            bool formatVar = argFormat.HasValue();


            // Determine available chars from badchars
            foreach (var b in allChars)
            {
                int pos = Array.IndexOf(badChars,b);
                if (pos < 0)
                {
                    availableChars.Add(b);
                }
            }

            string scLengthStr = sc.Replace("0x", "").Replace("\\x", "").Replace(" ","");
            int scLength = scLengthStr.Length / 2;

            Console.WriteLine("[i] Shellcode Length: " + scLength.ToString() + " bytes\n");
            if (scLength % 4 != 0)
            {
                string nops = String.Concat(Enumerable.Repeat("\\x90", (4 - (scLength % 4))));
                sc = sc + nops;
                Console.WriteLine("[!] Prepending NOPs to align Shellcode: " + nops.Length.ToString() + " bytes\n");
            }


            if (argArch.HasValue())
            {
                carvedCode.Add("\\x48\\x25\\x4a\\x4d\\x4e\\x55");
                carvedCode.Add("\\x48\\x25\\x35\\x32\\x31\\x2a");
                carvedCode.Add("\\x48\\x54\\x58");
            }
            else
            {
                // AND XOR opcodes
                carvedCode.Add("\\x25\\x4a\\x4d\\x4e\\x55");
                carvedCode.Add("\\x25\\x35\\x32\\x31\\x2a");
                carvedCode.Add("\\x54\\x58");

            }

            

            if (argArch.HasValue())
            {
                // Convert Carve Value for ESP Destination
                long diffEsp = Convert.ToInt64(Convert.ToUInt64(destEsp, 16) - Convert.ToUInt64(startEsp, 16));
                string value = ulong.MaxValue.ToString("X");
                long number = Convert.ToInt64(value, 16);
                var diff = (number - diffEsp).ToString("X16");
                string[] carvedOutput = CarveEncode(diff, availableChars.ToArray(), argArch.HasValue());
                carvedCode.Add(carvedOutput[0]);
                carvedCode.Add(carvedOutput[1]);
                carvedCode.Add(carvedOutput[2]);
                carvedCode.Add(carvedOutput[3]);
                carvedCode.Add(carvedOutput[4]);
                carvedCode.Add(carvedOutput[5]);
                carvedCode.Add(carvedOutput[6]);

                // PUSHPOP
                carvedCode.Add("\\x50\\x5c");
            }
            else
            {
                // Convert Carve Value for ESP Destination
                long diffEsp = Convert.ToInt32(Convert.ToInt32(destEsp, 16) - Convert.ToInt32(startEsp, 16));
                var diff = (4294967295 - diffEsp).ToString("X");
                string[] carvedOutput = CarveEncode(diff, availableChars.ToArray(), argArch.HasValue());
                carvedCode.Add(carvedOutput[0]);
                carvedCode.Add(carvedOutput[1]);
                carvedCode.Add(carvedOutput[2]);

                // PUSHPOP
                carvedCode.Add("\\x50\\x5c");
            }

            string[] reversedShellcodeList;

            if (argArch.HasValue())
            {
                // Reverse shellcode for Carving values
                string reversedShellcode = ReverseHexString(sc);
                
                double partSize = 16;
                int k = 0;
                var output = reversedShellcode
                    .ToLookup(c => Math.Floor(k++ / partSize))
                    .Select(e => new String(e.ToArray()));
                reversedShellcodeList = output.ToArray();
            }
            else
            {
                // Reverse shellcode for Carving values
                string reversedShellcode = ReverseHexString(sc);
                double partSize = 8;
                int k = 0;
                var output = reversedShellcode
                    .ToLookup(c => Math.Floor(k++ / partSize))
                    .Select(e => new String(e.ToArray()));
                reversedShellcodeList = output.ToArray();
            }
          
            // Loop through each 4 bytes of reversed shellcode
            foreach (string op in reversedShellcodeList)
            {
                string revScHex;

                if (argArch.HasValue())
                {
                    revScHex = (-1 - Convert.ToInt64(op, 16) + 0x01).ToString("X16");
                }
                else
                {
                    revScHex = (4294967295 - Convert.ToInt32(op, 16) + 0x01).ToString("X8");
                    if (revScHex.Length > 8)
                    {
                        revScHex = revScHex.Substring(revScHex.Length - 8, 8);
                    }
                }
                
                

                if (argArch.HasValue())
                {
                    // Carve shellcode and prefix with AND XOR opcodes
                    carvedCode.Add("\\x48\\x25\\x4a\\x4d\\x4e\\x55");
                    carvedCode.Add("\\x48\\x25\\x35\\x32\\x31\\x2a");
                    if (argDebug.HasValue())
                    {
                        Console.WriteLine("[i] Reversed shellcode bytes: " + op);
                        Console.WriteLine("[i] Byte difference: " + revScHex);
                    }
                    
                    string[] carvedOutput = CarveEncode(revScHex, availableChars.ToArray(), argArch.HasValue());

                    carvedCode.Add(carvedOutput[0]);
                    carvedCode.Add(carvedOutput[1]);
                    carvedCode.Add(carvedOutput[2]);
                    carvedCode.Add(carvedOutput[3]);
                    carvedCode.Add(carvedOutput[4]);
                    carvedCode.Add(carvedOutput[5]);
                    carvedCode.Add(carvedOutput[6]);
                }
                else
                {
                    // Carve shellcode and prefix with AND XOR opcodes
                    carvedCode.Add("\\x25\\x4a\\x4d\\x4e\\x55");
                    carvedCode.Add("\\x25\\x35\\x32\\x31\\x2a");

                    if (argDebug.HasValue())
                    {
                        Console.WriteLine("[i] Reversed shellcode bytes: " + op);
                        Console.WriteLine("[i] Byte difference: " + revScHex);
                    }
                    string[] carvedOutput = CarveEncode(revScHex, availableChars.ToArray(), argArch.HasValue());
                    carvedCode.Add(carvedOutput[0]);
                    carvedCode.Add(carvedOutput[1]);
                    carvedCode.Add(carvedOutput[2]);
                }


                if (argArch.HasValue())
                {
                    // PUSH
                    carvedCode.Add("\\x50");
                }
                else
                {
                    // PUSH
                    carvedCode.Add("\\x50");
                }
            }

            Console.WriteLine("[i] Start ESP: \t\t" + startEsp);
            Console.WriteLine("[i] Destination ESP: \t" + destEsp);
            Console.WriteLine("[i] Shellcode: \t\t" + sc + "\n");

            if (formatVar)
            {
                
                if (argFormat.Value().ToLower() == "p" || argFormat.Value().ToLower() == "python")
                {
                    Console.WriteLine("[+] Carved Shellcode (Python):\n");
                    Console.WriteLine("shellcode = (");
                    foreach (string outFormat in carvedCode)
                    {
                        Console.WriteLine(outFormat);
                    }
                    Console.WriteLine(")");
                }
                else if (argFormat.Value().ToLower() == "n" || argFormat.Value().ToLower() == "nasm" || argFormat.Value().ToLower() == "a" || argFormat.Value().ToLower() == "asm")
                {
                    Console.WriteLine("[+] Carved Shellcode (ASM):\n");                    
                    ShellcodeDecoder(string.Concat(carvedCode), destEsp, argArch.HasValue());
                }
                else
                {
                    Console.WriteLine("[+] Carved Shellcode (HEX):\n");
                    Console.WriteLine(string.Concat(carvedCode).Replace("\\x",""));
                }

            }
            else
            {
                Console.WriteLine("\"" + string.Concat(carvedCode) + "\"");
            }
            Console.WriteLine("\n[+] nCompleted");

        }

        static string ReverseHexString(string hexString)
        {
            if (hexString.Contains("\\"))
            {
                hexString = hexString.Replace("\\x", "");
            }
            string output = "";
            for (int i = 0; i < hexString.Length - 1; i += 2)
            {
                output += hexString[(hexString.Length - 2) - i];
                output += hexString[(hexString.Length - 1) - i];
            }
            return (output);
        }

        static string padAndStrip(string x)
        {
            string xOut;
            try
            {
                xOut = ("\\x" + int.Parse(x).ToString("X2"));
            }
            catch
            {
                xOut = "";
            }
            return xOut;
        }

        static void ShellcodeDecoder(string shellcode, string RIP, bool x64)
        {
            string[] hexValues = shellcode.Split("\\x").Skip(1).ToArray();
            int bitness;
            if (x64)
            {
                bitness = 64;
            }
            else
            {
                bitness = 32;
            }
            byte[] code = hexValues
              .Select(value => Convert.ToByte(value, 16))
              .ToArray();
            var codeBytes = code;
            var codeReader = new ByteArrayCodeReader(codeBytes);
            var decoder = Iced.Intel.Decoder.Create(bitness, codeReader);
            ulong CodeRIP = Convert.ToUInt64(RIP, 16);
            decoder.IP = CodeRIP;

            ulong endRip = decoder.IP + (uint)codeBytes.Length;

            var instructions = new InstructionList();
            while (decoder.IP < endRip)
            {
                decoder.Decode(out instructions.AllocUninitializedElement());
            }
            var formatter = new NasmFormatter();
            formatter.Options.DigitSeparator = "";
            formatter.Options.FirstOperandCharIndex = 10;
            var output = new StringBuilderFormatterOutput();
            foreach (ref var instr in instructions)
            {
                formatter.Format(instr, output);
                int instrLen = instr.ByteLength;
                int byteBaseIndex = (int)(instr.IP - CodeRIP);
                for (int i = 0; i < instrLen; i++)
                    Console.Write(codeBytes[byteBaseIndex + i].ToString("X2"));
                int missingBytes = 10 - instrLen;
                for (int i = 0; i < missingBytes; i++)
                    Console.Write("  ");
                Console.Write(" ");
                Console.WriteLine(output.ToStringAndReset().ToUpper());
            }
        }


        static string[] CarveEncode(string x, int[] availChars, bool x64)
        {
            Random rnd = new Random();
            int r;

            double partSize = 2;
            int k = 0;
            var output = x
                .ToLookup(c => Math.Floor(k++ / partSize))
                .Select(e => new String(e.ToArray()));
            string[] carveVal = output.ToArray();

            int row1 = Convert.ToInt32(carveVal[0],16);
            int a1 = row1;
            int row2 = Convert.ToInt32(carveVal[1], 16);
            int a2 = row2;
            int row3 = Convert.ToInt32(carveVal[2], 16);
            int a3 = row3;
            int row4 = Convert.ToInt32(carveVal[3], 16);
            int a4 = row4;

            int row4Loop = 0;
            int row3Loop = 0;
            int row2Loop = 0;
            int row1Loop = 0;
            

            string b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4;
            b1 = b2 = b3 = b4 = c1 = c2 = c3 = c4 = d1 = d2 = d3 = d4 = string.Empty;

            string b5, b6, b7, b8, c5, c6, c7, c8, d5, d6, d7, d8;
            b5 = b6 = b7 = b8 = c5 = c6 = c7 = c8 = d5 = d6 = d7 = d8 = string.Empty;

            if (x64)
            {
                int row5 = Convert.ToInt32(carveVal[4], 16);
                int a5 = row5;
                int row6 = Convert.ToInt32(carveVal[5], 16);
                int a6 = row6;
                int row7 = Convert.ToInt32(carveVal[6], 16);
                int a7 = row7;
                int row8 = Convert.ToInt32(carveVal[7], 16);
                int a8 = row8;

                int row5Loop = 0;
                int row6Loop = 0;
                int row7Loop = 0;
                int row8Loop = 0;

                

                if (row8 == 0)
                {
                    row8 = a8 = 256;
                    row7Loop = 1;
                }


                if (row7 == 0)
                {
                    row7 = a7 = 256;
                    row6Loop = 1;
                }

                if (row6 == 0)
                {
                    row6 = a6 = 256;
                    row5Loop = 1;
                }

                if (row5 == 0)
                {
                    row5 = a5 = 256;
                    row4Loop = 1;
                }

                while (row8 != row8Loop)
                {
                    try
                    {
                        r = rnd.Next(0, availChars.Length);
                        b8 = availChars[r].ToString();
                        r = rnd.Next(0, availChars.Length);
                        c8 = availChars[r].ToString();
                        r = rnd.Next(0, availChars.Length);
                        d8 = availChars[r].ToString();


                        if (a8 - int.Parse(b8) - int.Parse(c8) - int.Parse(d8) == row8Loop)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        b8 = c8 = d8 = "";

                        break;
                    }
                }

                while (row7 != row7Loop)
                {
                    try
                    {
                        r = rnd.Next(0, availChars.Length);
                        b7 = availChars[r].ToString();
                        r = rnd.Next(0, availChars.Length);
                        c7 = availChars[r].ToString();
                        r = rnd.Next(0, availChars.Length);
                        d7 = availChars[r].ToString();


                        if (a7 - int.Parse(b7) - int.Parse(c7) - int.Parse(d7) == row3Loop)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        b7 = c7 = d7 = "";

                        break;
                    }
                }

                while (row6 != row6Loop)
                {
                    try
                    {
                        r = rnd.Next(0, availChars.Length);
                        b6 = availChars[r].ToString();
                        r = rnd.Next(0, availChars.Length);
                        c6 = availChars[r].ToString();
                        r = rnd.Next(0, availChars.Length);
                        d6 = availChars[r].ToString();


                        if (a6 - int.Parse(b6) - int.Parse(c6) - int.Parse(d6) == row6Loop)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        b6 = c6 = d6 = "";

                        break;
                    }
                }

                while (row5 != row5Loop)
                {
                    try
                    {
                        r = rnd.Next(0, availChars.Length);
                        b5 = availChars[r].ToString();
                        r = rnd.Next(0, availChars.Length);
                        c5 = availChars[r].ToString();
                        r = rnd.Next(0, availChars.Length);
                        d5 = availChars[r].ToString();


                        if (a5 - int.Parse(b5) - int.Parse(c5) - int.Parse(d5) == row5Loop)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        b5 = c5 = d5 = "";

                        break;
                    }
                }
            }

            if (row4 == 0)
            {
                row4 = a4 = 256;
                row3Loop = 1;
            }


            if (row3 == 0)
            {
                row3 = a3 = 256;
                row2Loop = 1;
            }

            if (row2 == 0)
            {
                row2 = a2 = 256;
                row1Loop = 1;
            }

            if (row1 == 0)
            {
                row1 = a1 = 256;
            }

            while (row4 != row4Loop)
            {
                try
                {
                    r = rnd.Next(0, availChars.Length);
                    b4 = availChars[r].ToString();
                    r = rnd.Next(0, availChars.Length);
                    c4 = availChars[r].ToString();
                    r = rnd.Next(0, availChars.Length);
                    d4 = availChars[r].ToString();


                    if (a4 - int.Parse(b4) - int.Parse(c4) - int.Parse(d4) == row4Loop)
                    { 
                        break;
                    }
                }
                catch
                {
                    b4 = c4 = d4 = "";
                    
                    break;
                }
            }

            while (row3 != row3Loop)
            {
                try
                {
                    r = rnd.Next(0, availChars.Length);
                    b3 = availChars[r].ToString();
                    r = rnd.Next(0, availChars.Length);
                    c3 = availChars[r].ToString();
                    r = rnd.Next(0, availChars.Length);
                    d3 = availChars[r].ToString();


                    if (a3 - int.Parse(b3) - int.Parse(c3) - int.Parse(d3) == row3Loop)
                    {
                        break;
                    }
                }
                catch
                {
                    b3 = c3 = d3 = "";

                    break;
                }
            }

            while (row2 != row2Loop)
            {
                try
                {
                    r = rnd.Next(0, availChars.Length);
                    b2 = availChars[r].ToString();
                    r = rnd.Next(0, availChars.Length);
                    c2 = availChars[r].ToString();
                    r = rnd.Next(0, availChars.Length);
                    d2 = availChars[r].ToString();


                    if (a2 - int.Parse(b2) - int.Parse(c2) - int.Parse(d2) == row2Loop)
                    {
                        break;
                    }
                }
                catch
                {
                    b2 = c2 = d2 = "";

                    break;
                }
            }

            while (row1 != row1Loop)
            {
                try
                {
                    r = rnd.Next(0, availChars.Length);
                    b1 = availChars[r].ToString();
                    r = rnd.Next(0, availChars.Length);
                    c1 = availChars[r].ToString();
                    r = rnd.Next(0, availChars.Length);
                    d1 = availChars[r].ToString();


                    if (a1 - int.Parse(b1) - int.Parse(c1) - int.Parse(d1) == row1Loop)
                    {
                        break;
                    }
                }
                catch
                {
                    b1 = c1 = d1 = "";

                    break;
                }
            }

            string sub1, sub2, sub3, sub4, sub5, sub6, sub7;
            sub1 = sub2 = sub3 = sub4 = sub5 = sub6 = sub7 = string.Empty;

            if (x64)
            {
                sub1 = ("\\x48\\x2d" + (padAndStrip(b4) + padAndStrip(b3) + padAndStrip(b2) + padAndStrip(b1)));
                sub2 = ("\\x48\\x2d" + (padAndStrip(c4) + padAndStrip(c3) + padAndStrip(c2) + padAndStrip(c1)));
                sub3 = ("\\x48\\x2d" + (padAndStrip(d4) + padAndStrip(d3) + padAndStrip(d2) + padAndStrip(d1)));
                sub4 = ("\\x48\\xC1\\xE0\\x20");
                
                sub5 = ("\\x48\\x2d" + (padAndStrip(b8) + padAndStrip(b7) + padAndStrip(b6) + padAndStrip(b5) ));
                sub6 = ("\\x48\\x2d" + (padAndStrip(c8) + padAndStrip(c7) + padAndStrip(c6) + padAndStrip(c5) ));
                sub7 = ("\\x48\\x2d" + (padAndStrip(d8) + padAndStrip(d7) + padAndStrip(d6) + padAndStrip(d5) ));
            }
            else
            {
                // Write SUB carved shellcode
                sub1 = ("\\x2d" + (padAndStrip(b4) + padAndStrip(b3) + padAndStrip(b2) + padAndStrip(b1)));
                sub2 = ("\\x2d" + (padAndStrip(c4) + padAndStrip(c3) + padAndStrip(c2) + padAndStrip(c1)));
                sub3 = ("\\x2d" + (padAndStrip(d4) + padAndStrip(d3) + padAndStrip(d2) + padAndStrip(d1)));
            }
            string[] subOutput = { sub1, sub2, sub3, sub4, sub5, sub6, sub7 };

            return subOutput;
        }
    }
}
