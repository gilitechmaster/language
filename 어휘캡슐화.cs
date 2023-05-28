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
                if (A.IndexOf("가") == 2) // "가"라는 글자가 3번째 위치하면 사람으로 캡슐시키는 어휘
                    Console.WriteLine(A.Replace("가", " 사람"));//음악가
                if (A.IndexOf("사") == 2)
                    Console.WriteLine(A.Replace("사", " 사람"));//간호사
                if (A.IndexOf("관") == 2)
                    Console.WriteLine(A.Replace("관", " 사람"));//경찰관
                if (A.IndexOf("원") == 2)
                    Console.WriteLine(A.Replace("원", " 사람"));//은행원
                if (A.IndexOf("장") == 2)
                    Console.WriteLine(A.Replace("장", " 사람"));//단체장
                if (A.IndexOf("인") == 2)
                    Console.WriteLine(A.Replace("인", " 사람"));//외국인
                if (A.IndexOf("자") == 2)
                    Console.WriteLine(A.Replace("자", " 사람"));//과학자
                if (A.IndexOf("진") == 2)
                    Console.WriteLine(A.Replace("진", " 사람"));//제작진
                if (A.IndexOf("민") == 2)
                    Console.WriteLine(A.Replace("민", " 사람"));//거주민
                if (A.IndexOf("생") == 2)
                    Console.WriteLine(A.Replace("생", " 사람"));//대학생
                if (A.IndexOf("객") == 2)
                    Console.WriteLine(A.Replace("객", " 사람"));//등산객
                if (A.IndexOf("이") == 2)
                    Console.WriteLine(A.Replace("이", " 사람"));//어린이
                if (A.IndexOf("광") == 2)
                    Console.WriteLine(A.Replace("광", " 사람"));//영화광
                if (A.IndexOf("꾼") == 2)
                    Console.WriteLine(A.Replace("꾼", " 사람"));//구경꾼
                if (A.IndexOf("쟁이") == 2)
                    Console.WriteLine(A.Replace("쟁이", " 사람"));//거짓말쟁이
                if (A.IndexOf("투성이") == 2)
                    Console.WriteLine(A.Replace("투성이", " 사람"));//피투성이
                if (A.IndexOf("시") == 0)
                    Console.WriteLine(A.Replace("시", " 사람"));//시어머니
                if (A.IndexOf("친") == 0)
                    Console.WriteLine(A.Replace("친", " 사람"));//친어머니
                if (A.IndexOf("외") == 0)
                    Console.WriteLine(A.Replace("외", " 사람"));//외손자
                Console.WriteLine();
            }
        }
    }
}
