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
                                   .Replace("[", " ")
                                   .Replace("]", " ")
                                   .Replace("/", " ")

                                   //ㄱ
                                   .Replace("가 ", " ")
                                   .Replace("갈 ", "가다 ")
                                   .Replace("같은 ", "같다 ")
                                   .Replace("게 ", "다 ")
                                   .Replace("고 ", "다 ")
                                   .Replace("고자 ", "다 ") //"가르치고자"에서 "고자"를 "다"로 변형시켰다.
                                   .Replace("과 ", " ")
                                   //.Replace("그러면 ", "그러하다 ")
                                   .Replace("까지 ", " ")
                                   //ㄴ
                                   .Replace("나 ", " ")
                                   .Replace("는 ", "다 ")
                                   .Replace("는데 ", "다 ")
                                   .Replace("닌 ", "니다 ")
                                   //ㄷ
                                   .Replace("대한 ", "대하다 ")
                                   .Replace("도 ", " ")
                                   .Replace("되 ", " ") //"활용되나"에서 "나"를 위에서 탈락시켰고 "되"를 탈락시킨다.
                                   .Replace("되어 ", "되다 ")
                                   .Replace("된 ", "되다 ")
                                   .Replace("된다 ", "되다 ") //"된다", ㄴ을 탈락시킨다.
                                   .Replace("듯 ", "다 ") //"않듯"에서 어미를 변형시켰다.
                                   //ㄹ
                                   .Replace("라도 ", " ")
                                   .Replace("려본 ", "리다 ") //"건드러면"에서 어두인 "드"가 아니라 어미인 "려본"을 수정했다.
                                   .Replace("려지다 ", "리다 ")
                                   .Replace("려진다 ", "리다 ")
                                   .Replace("로 ", " ")
                                   .Replace("룬다 ", "루다 ")
                                   .Replace("를 ", " ")
                                   .Replace("리지 ", "리다 ")
                                   .Replace("린 ", " ")
                                   //ㅁ
                                   .Replace("만 ", " ")//"이론만"에서 "만"을 탈락시킨다.
                                   .Replace("많 ", "많다 ")//"많은"에서 위에서 "은"을 소거시키므로 "많"을 "많다"로 바꾼다.
                                   .Replace("많이 ", "많다 ") //"많이", 밑에서 "이"를 소거시키므로 "많이"를 수정시킨다.
                                   .Replace("며 ", "다 ") // "힘들며"를 "힘들다"로 바꾼다.
                                   .Replace("먼 ", "멀다 ")
                                   .Replace("면 ", "다 그러면 ")
                                   .Replace("및 ", " ")
                                   //ㅂ
                                   .Replace("반다 ", " ") // "반면", 위에서 "면"을 "다 그러면"으로 수정시키고 남은 "반다"를 소거한다.
                                   .Replace("본다 ", "보다 ") // "본다"에서 ㄴ을 탈락시켰다.
                                   .Replace("볼 ", "보다 ")
                                   //ㅅ
                                   .Replace("싶다다 ", "싶다 ")
                                   //"싶다면"에서 "면"을 위에서 "다"로 변경시켰으므로
                                   //존재하지 않는 "싶다다" 라는 단어를 수정해야 하는데
                                   //프로그램 순차상 "다다"는 소거 수정시킬 수 없으므로
                                   //어두를 포함해서 "싶다다"를 소거 수정시킨다.

                                   //ㅇ
                                   .Replace("아내다 ", "다 ")
                                   .Replace("야 ", "다 ")
                                   .Replace("어나다 ", "다 ")
                                   .Replace("어나긴 ", "다 ") //"늘어나긴"에서 어두 "늘"을 제외하고 수정했다.
                                   .Replace("어져 ", "어지다 ")
                                   .Replace("에 ", " ")
                                   .Replace("에다 ", " ") //"최근에는", 앞에서 "는"을 소거시켰으므로 "에다"를 다시 소거한다.
                                   .Replace("에도 ", " ")
                                   .Replace("에만 ", " ")
                                   .Replace("에서 ", " ")
                                   .Replace("에서도 ", " ")
                                   .Replace("에서다 ", " ")
                                   .Replace("와 ", " ")
                                   .Replace("운다 ", "우다 ")
                                   .Replace("워두자 ", "우다 ")//"배워두자"에서 "워두자"를 "두자"로 바꾼다.
                                   .Replace("으 ", " ")
                                   .Replace("으다 ", "다 ")
                                   //"많으면"에서 "면"을 "많으다 그러면"으로 바꾸고 "많으다"를 "많다"로 바꾸었다. 
                                   .Replace("으로 ", " ")
                                   .Replace("은 ", " ")
                                   .Replace("을 ", " ")
                                   .Replace("의 ", " ")
                                   .Replace("이 ", " ")
                                   .Replace("이고 ", " ")
                                   .Replace("이나 ", " ")
                                   .Replace("이다 ", " ")
                                   .Replace("이며 ", "이다 ")
                                   .Replace("이므 ", "이다 ")
                                   .Replace("인데 ", "이다 ")
                                   .Replace("인데 ", "이다 ")
                                   .Replace("있어 ", "있다 ")
                                   .Replace("있어서 ", "있다 ")
                                   .Replace("있으며 ", "있다 ")
                                   .Replace("있지 ", "있다 ")
                                   //.Replace("인 ", " ") "디자인"이라는 글자 때문에 지운다.
                                   //ㅈ
                                   .Replace("적 ", " ")
                                   .Replace("적인 ", " ")
                                   .Replace("지 ", "다 ") //"많지"에서 어미를 소거했다.
                                   .Replace("지느냐 ", "지다 ")
                                   .Replace("지만 ", "이다 ")
                                   .Replace("진 ", "다 ") // "많진"에서 어미 "진'을 수정했다.
                                   .Replace("진다다 ", "지다 ")
                                   .Replace("질수록 ", "지다 ")
                                   //ㅊ
                                   //ㅌ
                                   //ㅍ
                                   //ㅎ
                                   .Replace("하고 ", " ")
                                   .Replace("하거나 ", "하다 ")
                                   .Replace("하기 ", "하다 ")
                                   .Replace("하기도 ", "하다 ")
                                   .Replace("하는 ", "하다 ")
                                   .Replace("하다거나 ", "하다 ")
                                   .Replace("하며 ", "하다 ")
                                   .Replace("하면 ", "하다 그러면 ")
                                   .Replace("하므 ", "하다 ")//"열악하므로"에서 "로"를 위에서 소거시켰으므로 "하므"를 변형시킨다.
                                   .Replace("하여 ", "하다 ")
                                   .Replace("하이다 ", "하지만 ")
                                   //"하지만"에서 "지만"을 "이다"로 바꾸었으므로 다시 "하이다"를 "하지만"으로 바꾼다. 
                                   .Replace("하지 ", "하다 ")
                                   .Replace("한 ", "하다 ")
                                   .Replace("한다다 ", "하다 ")
                                   //"한다면"에서 "면"을 "다"로 수정시켰고 그다음 "한다다"를 "하다"로 수정시켰다.
                                   .Replace("한다 ", "하다 ")
                                   .Replace("할 ", "하다 ")
                                   .Replace("할지 ", "하다 ")
                                   .Replace("해 ", "하다 ")
                                   .Replace("해다 ", "하다 ")
                                   .Replace("해보다 ", "하다 ") //"해보는"에서 "는"을 위에서 "다"로 바꾸므로 "하다"로 바꾼다.
                                   .Replace("해서 ", "하다 ")
                                   .Replace("해서는 ", "하다 ")
                                   .Replace("했다 ", "하다 ")
                                   .Replace("혀보다 ", "히다 ")
                                   //"넓혀보면"에서 위에서 "넓혀보다 그러면"으로 바꾸고
                                   //"넓혀보다"를 "넓히다"로 바꾸고 아래에서 "히다"를 "다"로 바꾼다.
                                   .Replace("혀있다 ", "히다 ") //"얽혀있다."를 "얽히다"로 바꾼다.
                                   .Replace("히 ", "하다 ")
                                   .Replace("히다 ", "다 ")

                                   );
                Console.WriteLine();
            }
        }
    }
}
