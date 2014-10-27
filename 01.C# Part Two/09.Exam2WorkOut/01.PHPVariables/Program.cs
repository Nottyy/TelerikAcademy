using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PHPVariables
{
    class Program
    {
        public static string ReadInput()
        {
            string currentLine = Console.ReadLine().Trim();

            StringBuilder phpCode = new StringBuilder();

            while (currentLine != "?>")
            {
                phpCode.AppendLine(currentLine);
                currentLine = Console.ReadLine().Trim();
            }

            return phpCode.ToString();

        }

        public static bool isValidVariableSymbol(char symbol)
        {
            if (!char.IsLetterOrDigit(symbol) || symbol == '_')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ExtractWords(string inputCode)
        {
            bool inOneLineComment = false;
            bool inMultiLineComment = false;
            bool inSingleQuoteString = false;
            bool inDoubleQuoteString = false;
            bool inVariable = false;

            for (int i = 0; i < inputCode.Length; i++)
            {
                char currentSymbol = inputCode[i];
                if (inOneLineComment)
                {
                    if (currentSymbol == '\n')
                    {
                        inOneLineComment = false;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (inMultiLineComment)
                {
                    if (currentSymbol == '*' && i + 1 < inputCode.Length && inputCode[i + 1] == '/')
                    {
                        inMultiLineComment = false;
                        i++;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (inVariable)
                {
                    
                }
            }
        }
        static void Main(string[] args)
        {

            string inputCode = ReadInput();
            
            

        }
    }
}
