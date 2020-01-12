using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShellcodeCarver
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] badChars = {0x00, 0x0a, 0x0d, 0x2f, 0x3a, 0x3f, 0x40, 0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87,
               0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e, 0x8f, 0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96,
               0x97, 0x98, 0x99, 0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f, 0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5,
               0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf, 0xb0, 0xb1, 0xb2, 0xb3, 0xb4,
               0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf, 0xc0, 0xc1, 0xc2, 0xc3,
               0xc4, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcc, 0xcd, 0xce, 0xcf, 0xd0, 0xd1, 0xd2,
               0xd3, 0xd4, 0xd5, 0xd6, 0xd7, 0xd8, 0xd9, 0xda, 0xdb, 0xdc, 0xdd, 0xde, 0xdf, 0xe0, 0xe1,
               0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef, 0xf0,
               0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff };

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

            List<int> availableChars = new List<int>();

            var cmdArgs = new CommandLineApplication();
            CommandOption argSc = cmdArgs.Option("-s | --shellcode <value>", "Enter Shellcode as opcode format (e.g. \\x64\\x01)", CommandOptionType.SingleValue);
            CommandOption argEspStart = cmdArgs.Option("-e | --esp-start <value>", "Enter ESP address value at start of carved shellcode", CommandOptionType.SingleValue);
            CommandOption argEspEnd = cmdArgs.Option("-d | --esp-end <value>", "Enter stack address value to write carved shellcode (allow for sufficient space for carved shellcode side)", CommandOptionType.SingleValue);
            cmdArgs.HelpOption("-? | -h | --help");

            cmdArgs.Execute(args);

            if (!(argSc.HasValue() || argEspStart.HasValue() || argEspEnd.HasValue()))
            {
                cmdArgs.ShowHelp();
                System.Environment.Exit(0);
            }
            string sc;
            sc = argSc.Value();
            string startEsp = argEspStart.Value();
            string destEsp = argEspEnd.Value();

            foreach (var b in allChars)
            {
                int pos = Array.IndexOf(badChars,b);
                if (pos < 0)
                {
                    availableChars.Add(b);
                }
            }

            Console.WriteLine("\"\\x25\\x4a\\x4d\\x4e\\x55\"");
            Console.WriteLine("\"\\x25\\x35\\x32\\x31\\x2a\"");
            Console.WriteLine("\"\\x54\\x58\"");
            int diffEsp = Convert.ToInt32(Convert.ToInt64(destEsp, 16) - Convert.ToInt32(startEsp, 16));
            var diff = (4294967295 - diffEsp).ToString("X");
            CarveEncode(diff, availableChars.ToArray());
            Console.WriteLine("\"\\x50\\x5c\"");

            string reversedShellcode = ReverseHexString(sc);
            string[] reversedShellcodeList;
            double partSize = 8;
            int k = 0;
            var output = reversedShellcode
                .ToLookup(c => Math.Floor(k++ / partSize))
                .Select(e => new String(e.ToArray()));
            reversedShellcodeList = output.ToArray();
            foreach (string op in reversedShellcodeList)
            {
                
                string revScHex = (4294967295 - Convert.ToInt32(op,16) + 0x01).ToString("X8");
                if (revScHex.Length > 8)
                {
                    revScHex = revScHex.Substring(revScHex.Length - 8,8);
                }

                Console.WriteLine("\"\\x25\\x4a\\x4d\\x4e\\x55\"");
                Console.WriteLine("\"\\x25\\x35\\x32\\x31\\x2a\"");
                CarveEncode(revScHex, availableChars.ToArray());
                Console.WriteLine("\"\\x50\"");
            }

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
            //return  x);
            return ("\\x" + int.Parse(x).ToString("X2"));
        }

        static void CarveEncode(string x, int[] availChars)
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

            Console.WriteLine("\"\\x2d" + (padAndStrip(b4) + padAndStrip(b3) + padAndStrip(b2) + padAndStrip(b1))+ "\"");
            Console.WriteLine("\"\\x2d" + (padAndStrip(c4) + padAndStrip(c3) + padAndStrip(c2) + padAndStrip(c1)) + "\"");
            Console.WriteLine("\"\\x2d" + (padAndStrip(d4) + padAndStrip(d3) + padAndStrip(d2) + padAndStrip(d1)) + "\"");
        }
    }
}
