using System;
using System.IO;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace App11
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e) //저장버튼 누르면
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename)) //문자열이 널인지 공백인지 확인한다.
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();
        }

        async void OnCalc1ButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }

            else
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                StreamWriter sw = new StreamWriter(filename, true);
                string[] arr = note.Text.Split(new string[]{

                    ". ",  // 순차처리하므로 ". "를 앞에해두어야 한다.
                    ".",
                    ", ",
                    ",",
                    "? ",
                    "?",
                    "! ",
                    "!",
                    "·", // 법률문서에 사용되는 기호
                    " "

                        }, StringSplitOptions.None);


                foreach (string B in arr) //조사탈락_동사명사화_1.cs에서 연계하였다.
                {
                        sw.WriteLine("{0}", B
                                    //ㄱ
                                    .Replace("가", "")
                                   .Replace("갈", "가다")
                                   .Replace("같은", "같다")
                                   .Replace("게", "다 그렇게")//"공부하게"에서 "공부하다"와 "그렇게"를 해체시켰다.
                                   .Replace("겠다", "다")
                                   .Replace("고", "다 그리고")//"받고"에서 "받다"와 "그리고"를 해체시켰다.
                                   .Replace("고자", "다") //"가르치고자"에서 "고자"를 "다"로 변형시켰다.
                                   .Replace("과", "")
                                   //.Replace("그러면 ", "그러하다 ")
                                   .Replace("기", "다")//"잦기"를 "잦다"로 바꾼다.
                                   .Replace("까지", "")
                                   //ㄴ
                                   .Replace("나", "")
                                   .Replace("는", "다")
                                   .Replace("는데", "다")
                                   .Replace("닌", "니다")
                                   //ㄷ
                                   .Replace("대한", "대하다")
                                   .Replace("도", "")
                                   .Replace("되", "") //"활용되나"에서 "나"를 위에서 탈락시켰고 "되"를 탈락시킨다.
                                   .Replace("되어", "되다")
                                   .Replace("된", "되다")
                                   .Replace("된다", "되다") //"된다", ㄴ을 탈락시킨다.
                                   .Replace("될", "되다")
                                   .Replace("든", "들다")//"힘든"을 "힘들다"로 바꾸었다.
                                   .Replace("든다던", "들다") //"만든다던가"에서 "가"를 위에서 처리하고 "든다던"을 처리했다.
                                   .Replace("듯", "다") //"않듯"에서 어미를 변형시켰다.
                                                        //ㄹ
                                   .Replace("라도", "")
                                   .Replace("려본", "리다") //"건드러면"에서 어두인 "드"가 아니라 어미인 "려본"을 수정했다.
                                   .Replace("려지다", "리다")
                                   .Replace("려진다", "리다")
                                   .Replace("로", "")
                                   .Replace("룬다", "루다")
                                   .Replace("를", "")
                                   .Replace("리지", "리다")
                                   .Replace("린", "")
                                   //ㅁ
                                   .Replace("만", "")//"이론만"에서 "만"을 탈락시킨다.
                                   .Replace("많", "많다")//"많은"에서 위에서 "은"을 소거시키므로 "많"을 "많다"로 바꾼다.
                                   .Replace("많이", "많다") //"많이", 밑에서 "이"를 소거시키므로 "많이"를 수정시킨다.
                                   .Replace("며", "다") // "힘들며"를 "힘들다"로 바꾼다.
                                   .Replace("먼", "멀다")
                                   .Replace("면", "다 그러면")
                                   .Replace("및", "")
                                   //ㅂ
                                   .Replace("반다", "") // "반면", 위에서 "면"을 "다 그러면"으로 수정시키고 남은 "반다"를 소거한다.
                                   .Replace("본다", "보다") // "본다"에서 ㄴ을 탈락시켰다.
                                   .Replace("볼", "보다")
                                   //ㅅ
                                   .Replace("싶다다", "싶다")
                                   //"싶다면"에서 "면"을 위에서 "다"로 변경시켰으므로
                                   //존재하지 않는 "싶다다" 라는 단어를 수정해야 하는데
                                   //프로그램 순차상 "다다"는 소거 수정시킬 수 없으므로
                                   //어두를 포함해서 "싶다다"를 소거 수정시킨다.

                                   //ㅇ
                                   .Replace("아내다", "다")
                                   .Replace("야", "다")
                                   .Replace("어", "다")//"맞추어"를 "맞추다"로 변형시켰다.
                                   .Replace("어나다", "다")
                                   .Replace("어나긴", "다") //"늘어나긴"에서 어두 "늘"을 제외하고 수정했다.
                                   .Replace("어내다", "다")//"얻어내다"를 "얻다"로 바꾸었다.
                                   .Replace("어져", "어지다")
                                   .Replace("에", "")
                                   .Replace("에다", "") //"최근에는", 앞에서 "는"을 소거시켰으므로 "에다"를 다시 소거한다.
                                   .Replace("에도", "")
                                   .Replace("에만", "")
                                   .Replace("에서", "")
                                   .Replace("에서도", "")
                                   .Replace("에서다", "")
                                   .Replace("와", "")
                                   .Replace("운다", "우다")
                                   .Replace("워두자", "우다")//"배워두자"에서 "워두자"를 "두자"로 바꾼다.
                                   .Replace("웠던", "우다")//"배웠던"에서 "배우다"로 시제를 현재형으로 바꾸었다.
                                   .Replace("으", "")
                                   .Replace("으다", "다")
                                   //"많으면"에서 "면"을 "많으다 그러면"으로 바꾸고 "많으다"를 "많다"로 바꾸었다. 
                                   .Replace("으로", "")
                                   .Replace("은", "")
                                   //"좋은"과 "사람은" 2가지 다른 어휘가 생성되서 처리에 문제가 생긴다.
                                   .Replace("을", "")
                                   .Replace("의", "")
                                   .Replace("이", "")
                                   .Replace("이고", "")
                                   .Replace("이기", "이다")
                                   .Replace("이나", "")
                                   .Replace("이니", "이다")
                                   .Replace("이다", "")
                                   .Replace("이며", "이다")
                                   .Replace("이므", "이다")
                                   .Replace("인데", "이다")
                                   .Replace("인데", "이다")
                                   .Replace("있어", "있다")
                                   .Replace("있어서", "있다")
                                   .Replace("있으며", "있다")
                                   .Replace("있지", "있다")
                                   //.Replace("인 ", " ") "디자인"이라는 글자 때문에 지운다.
                                   //ㅈ
                                   .Replace("적", "")
                                   .Replace("적인", "")
                                   .Replace("지", "다") //"많지"에서 어미를 소거했다.
                                   .Replace("지느냐", "지다")
                                   .Replace("지만", "이다")
                                   //"적지만"은 "만"을 소거하고 "지"를 "다"로 수정시켜서 "지만"은 "이다"가 안된다.
                                   .Replace("진", "다") // "많진"에서 어미 "진'을 수정했다.
                                   .Replace("진다다", "지다")
                                   .Replace("질수록", "지다")
                                   //ㅊ
                                   .Replace("쳐서", "지다")
                                   //ㅌ
                                   //ㅍ
                                   //ㅎ
                                   .Replace("하고", "")
                                   .Replace("하거나", "하다")
                                   .Replace("하기", "하다")
                                   .Replace("하기도", "하다")
                                   .Replace("하는", "하다")
                                   .Replace("하다", "하다")
                                   //"하다보면"에서 "하다보다 그러면"으로 나누어지므로 "하다"를 "하다 "로 수정한다.
                                   .Replace("하다거나", "하다")
                                   .Replace("하려다", "하다")
                                   .Replace("하며", "하다")
                                   .Replace("하면", "하다 그러면")
                                   .Replace("하면서", "하다 그러면서")
                                   .Replace("하므", "하다")//"열악하므로"에서 "로"를 위에서 소거시켰으므로 "하므"를 변형시킨다.
                                   .Replace("하여", "하다")
                                   .Replace("하였다", "하다")//시제는 과거형으로 유지하지 않고 현재형으로 바꾸었다.
                                   .Replace("하이다", "하지만")
                                   //"하지만"에서 "지만"을 "이다"로 바꾸었으므로 다시 "하이다"를 "하지만"으로 바꾼다. 
                                   .Replace("하지", "하다")
                                   .Replace("한", "하다")
                                   .Replace("한다다", "하다")
                                   //"한다면"에서 "면"을 "다"로 수정시켰고 그다음 "한다다"를 "하다"로 수정시켰다.
                                   .Replace("한다", "하다")
                                   .Replace("할", "하다")
                                   .Replace("할지", "하다")
                                   .Replace("해", "하다")
                                   .Replace("해놓자", "하다")
                                   .Replace("해다", "하다")
                                   .Replace("해보다", "하다") //"해보는"에서 "는"을 위에서 "다"로 바꾸므로 "하다"로 바꾼다.
                                   .Replace("해서", "하다")
                                   .Replace("해서는", "하다")
                                   .Replace("해지다", "하다")//"해지고"에서 "고"를 위에서 "다"로 처리했으므로 "해지다"를 "하다"로 바꾼다.
                                   .Replace("했느냐", "하다")
                                   .Replace("했다", "하다")
                                   .Replace("했더라", "하다")
                                   //"했더라도" 이지만 앞에서 "도"를 소거시켰으므로 "했더라"만 다시 소거시킨다.
                                   .Replace("혀보다", "히다")
                                   //"넓혀보면"에서 위에서 "넓혀보다 그러면"으로 바꾸고
                                   //"넓혀보다"를 "넓히다"로 바꾸고 아래에서 "히다"를 "다"로 바꾼다.
                                   .Replace("혀있다", "히다") //"얽혀있다."를 "얽히다"로 바꾼다.
                                   .Replace("히", "하다")
                                   .Replace("히다", "다")

                                   );
                }

                sw.Close();

            }

            await Navigation.PopAsync();
        }

        async void OnCalc2ButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }

            else
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                StreamWriter sw = new StreamWriter(filename, true);
                string[] arr = note.Text.Split(new string[]{

                    " "

                        }, StringSplitOptions.None);

                foreach (string B in arr)
                {
                    sw.WriteLine("{0}", B
                               .Replace("공간", "수학")
                               .Replace("논리", "수학")
                               .Replace("수량", "수학")
                               .Replace("수리논리학", "수학")
                               );
 
                }
                sw.Close();

            }

            await Navigation.PopAsync();
        }

       
        async void OnDeleteButtonClicked(object sender, EventArgs e) // 삭제버튼
        {
            var note = (Note)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Navigation.PopAsync();
        }
    }
}
