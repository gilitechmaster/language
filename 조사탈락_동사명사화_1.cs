using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp118
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n" + "--------입력-" + "\n");

                string A = "";
                A = Console.ReadLine();


                Console.WriteLine("\n" + "-결과-------");
                Console.WriteLine();
                Console.WriteLine(A

                                   //기호
                                   .Replace(".", " ")
                                   .Replace(", ", " ")
                                   .Replace(",", " ")
                                   .Replace("!", " ")
                                   .Replace("?", " ")
                                   .Replace("·", " ")
                                   .Replace("'", "")
                                   .Replace("(", " ")
                                   .Replace(")", " ")

                                   //ㄱ
                                   //ㄴ
                                   .Replace("는데 ", "다 ")
                                   //ㄷ
                                   //ㄹ
                                   .Replace("를 ", " ")
                                   //ㅁ
                                   //ㅂ
                                   //ㅅ
                                   //ㅇ
                                   .Replace("에 ", " ")
                                   .Replace("을 ", " ")
                                   //ㅈ
                                   .Replace("적인 ", " ")
                                   //ㅊ
                                   //ㅌ
                                   //ㅍ
                                   //ㅎ
                                   .Replace("하고 ", " ")
                                   .Replace("하거나 ", "하다 ")
                                   .Replace("하기 ", "하다 ")
                                   .Replace("하다거나 ", "하다 ")
                                   .Replace("하면 ", "하다 그러면 ")
                                   .Replace("하지 ", "하다 ")

                                   );
                Console.WriteLine();
            }
        }
    }
}
