namespace CaesarCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!Test Program!");


            SafeParse("Enter step to code it: ", out int step);

            string cryptStroke = CaesarEncryptEnglish("zyx", step);

            Console.WriteLine(cryptStroke);

            Console.WriteLine(CaesarDecryptEnglish(cryptStroke, step));

        }

        static string CaesarEncryptEnglish(string strokeToEncrypt, int optionalStep = 1)
        {

            
            if (optionalStep >= 26)
            {
                optionalStep -= 26 * (optionalStep / 26); 
            }


            char[] charArray = strokeToEncrypt.ToCharArray();


            for (int i = 0; i < charArray.Length; i++)
            {
                int curLetterNumber = (int)charArray[i];

                for (int j = 0; j < optionalStep; j++)
                {
                    
                    if ((curLetterNumber >= 90 && curLetterNumber <= 91) || (curLetterNumber >= 122 && curLetterNumber <= 123))
                    {

                        curLetterNumber -= 25;
                        j++;

                        if (j == optionalStep)
                            break;
                        
                    }
                    
                    curLetterNumber++;

                }

                charArray[i] = (char)curLetterNumber;


            }

            return new string(charArray);

        }

        static string CaesarDecryptEnglish(string strokeToDecrypt, int optionalStep = 1)
        {


            if (optionalStep >= 26)
            {
                optionalStep -= 26 * (optionalStep / 26);
            }


            char[] charArray = strokeToDecrypt.ToCharArray();


            for (int i = 0; i < charArray.Length; i++)
            {
                int curLetterNumber = (int)charArray[i];

                for (int j = 0; j < optionalStep; j++)
                {

                    if ((curLetterNumber >= 64 && curLetterNumber <= 65) || (curLetterNumber >= 96 && curLetterNumber <= 97))
                    {

                        curLetterNumber += 25;
                        j++;

                        if (j == optionalStep)
                            break;

                    }

                    curLetterNumber--;

                }

                charArray[i] = (char)curLetterNumber;


            }

            return new string(charArray);

        }

        static void SafeParse(string s, out int numb)
        {
            bool isSafe = false;

            do
            {
                Console.Write(s);

                isSafe = int.TryParse(Console.ReadLine(), out numb);

            } while (!isSafe);
        }
    
    
    }
}