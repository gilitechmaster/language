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

                    "ㄱ" //임의의 문자가 없으면 띄어쓰기 기준으로 단나눔이 되어버린다.

                        }, StringSplitOptions.None);


                foreach (string B in arr) //조사탈락_동사명사화_1.cs에서 연계하였다.
                {
                        sw.WriteLine("{0}", B

                                   //기호
                                   //.Replace(".", "") //마침표 뒤에는 띄어쓰기가 오므로 빈칸으로 한다.
                                   .Replace(".", " ") //위와 같은 사항이 있으나 맨마지막 문장이 처리가 안되므로 빈칸으로 한다.
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
                                   .Replace(":", "")
                                   .Replace("#", "")

                                   //ㄱ
                                   .Replace("가 ", " ")
                                   .Replace("갈 ", "가다 ")
                                   .Replace("같은 ", "같다 ")
                                   .Replace("거운 ", "겁다 ") //"뜨거운"을 "뜨겁다"로 동사화
                                   .Replace("게 ", "다 그렇게 ")
                                   //"공부하게"에서 "공부하다"와 "그렇게"를 해체시켰다.
                                   //"가게 했다." 라면 "가다 그렇게했다"가 되므로 "다 그렇게 "라고
                                   //접속서술어, "그렇게" 뒤에 띄어쓰기를 해야만 한다.
                                   .Replace("겠지만 ", "겠다 ")
                                   .Replace("겠다 ", "다 ")
                                   .Replace("겨진다 ", "겨지다 ")
                                   .Replace("겨지다 ", "기다 ")
                                   .Replace("겼다 ", "기다 ")
                                   .Replace("고 ", "다 그리고 ")//"받고"에서 "받다"와 "그리고"를 해체시켰다.
                                   .Replace("고자 ", "다 ") //"가르치고자"에서 "고자"를 "다"로 변형시켰다.
                                   .Replace("과 ", " ")
                                   //.Replace("그러면 ", "그러하다 ")
                                   .Replace("기다 ", "기 ")
                                   .Replace("기 ", "다 ")//"잦기"를 "잦다"로 바꾼다.
                                   .Replace("까지 ", " ")
                                   .Replace("꼈다 ", "끼다 ")
                                   //ㄴ
                                   .Replace("나 ", " ")
                                   .Replace("는 ", "다 ")
                                   .Replace("는데 ", "다 ")
                                   .Replace("닌 ", "니다 ")
                                   //ㄷ
                                   .Replace("대한 ", "대하다 ")
                                   .Replace("도 ", " ")
                                   .Replace("됐다 ", "돼다 ")
                                   .Replace("되 ", " ") //"활용되나"에서 "나"를 위에서 탈락시켰고 "되"를 탈락시킨다.
                                   .Replace("되면서 ", "되다 ")
                                   .Replace("되어 ", "되다 ")
                                   .Replace("되자 ", "되다 ")
                                   .Replace("된 ", "되다 ")
                                   .Replace("된다 ", "되다 ") //"된다", ㄴ을 탈락시킨다.
                                   .Replace("될 ", "되다 ")
                                   .Replace("든 ", "들다 ")//"힘든"을 "힘들다"로 바꾸었다.
                                   .Replace("든다던 ", "들다 ") //"만든다던가"에서 "가"를 위에서 처리하고 "든다던"을 처리했다.
                                   .Replace("듯 ", "다 ") //"않듯"에서 어미를 변형시켰다.
                                   //ㄹ
                                   .Replace("라도 ", " ")
                                   .Replace("려운 ", "렵다 ")//"어려운"을 "어렵다"로 바꾼다.
                                   .Replace("려라 ", "리다 ")
                                   .Replace("려본 ", "리다 ") //"건드러면"에서 어두인 "드"가 아니라 어미인 "려본"을 수정했다.
                                   .Replace("려지다 ", "리다 ")
                                   .Replace("려진다 ", "리다 ")
                                   .Replace("로 ", " ")
                                   .Replace("룬다 ", "루다 ")
                                   .Replace("른다 ", "른 ")
                                   .Replace("른 ", "르다 ") //"따른"을 "따르다"로 바꾸는데 "어른"도 바뀌므로 어두부터 바꾸는게 맞나 싶다.
                                   .Replace("를 ", " ")
                                   .Replace("리지 ", "리다 ")
                                   .Replace("리다 ", "다 ")
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
                                   .Replace("부터 ", " ")
                                   //ㅅ
                                   .Replace("시키다 ", "하다 ")
                                   .Replace("싶다다 ", "싶다 ")
                                   //"싶다면"에서 "면"을 위에서 "다"로 변경시켰으므로
                                   //존재하지 않는 "싶다다" 라는 단어를 수정해야 하는데
                                   //프로그램 순차상 "다다"는 소거 수정시킬 수 없으므로
                                   //어두를 포함해서 "싶다다"를 소거 수정시킨다.

                                   //ㅇ
                                   .Replace("아내다 ", "다 ")
                                   .Replace("았다 ", "다 ")
                                   .Replace("야 ", "다 ")
                                   .Replace("어 ", "다 ")//"맞추어"를 "맞추다"로 변형시켰다.
                                   .Replace("어나다 ", "다 ")
                                   .Replace("어나긴 ", "다 ") //"늘어나긴"에서 어두 "늘"을 제외하고 수정했다.
                                   .Replace("어내다 ", "다 ")//"얻어내다"를 "얻다"로 바꾸었다.
                                   .Replace("어져 ", "어지다 ")
                                   .Replace("어지다 ", "다 ")
                                   .Replace("에 ", " ")
                                   .Replace("에다 ", " ") //"최근에는", 앞에서 "는"을 소거시켰으므로 "에다"를 다시 소거한다.
                                   .Replace("에도 ", " ")
                                   .Replace("에만 ", " ")
                                   .Replace("에서 ", " ")
                                   .Replace("에서도 ", " ")
                                   .Replace("에서다 ", " ")
                                   .Replace("올랐다 ", "오르다 ")
                                   .Replace("와 ", " ")
                                   .Replace("우기 ", "우다 ")
                                   .Replace("운다 ", "우다 ")
                                   .Replace("워두자 ", "우다 ")//"배워두자"에서 "워두자"를 "두자"로 바꾼다.
                                   .Replace("웠던 ", "우다 ")//"배웠던"에서 "배우다"로 시제를 현재형으로 바꾸었다.
                                   .Replace("으 ", " ")
                                   .Replace("으다 ", "다 ")
                                   //"많으면"에서 "면"을 "많으다 그러면"으로 바꾸고 "많으다"를 "많다"로 바꾸었다. 
                                   .Replace("으로 ", " ")
                                   .Replace("은 ", " ")
                                   //"좋은"과 "사람은" 2가지 다른 어휘가 생성되서 처리에 문제가 생긴다.
                                   .Replace("을 ", " ")
                                   .Replace("의 ", " ")
                                   .Replace("이 ", " ")
                                   .Replace("이고 ", " ")
                                   .Replace("이기 ", "이다 ")
                                   .Replace("이나 ", " ")
                                   .Replace("이니 ", "이다 ")
                                   .Replace("이다 ", " ")
                                   .Replace("이며 ", "이다 ")
                                   .Replace("이므 ", "이다 ")
                                   .Replace("이었다 ", "이다 ")
                                   .Replace("인데 ", "이다 ")
                                   .Replace("인 ", "이다 ")
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
                                   //"적지만"은 "만"을 소거하고 "지"를 "다"로 수정시켜서 "지만"은 "이다"가 안된다.
                                   .Replace("진 ", "다 ") // "많진"에서 어미 "진'을 수정했다.
                                   .Replace("진다다 ", "지다 ")
                                   .Replace("질수록 ", "지다 ")
                                   //ㅊ
                                   .Replace("쳐서 ", "지다 ")
                                   .Replace("쳐 ", "치다 ") //"다쳐"는 "다치다"로 바꾼다.
                                   //ㅌ
                                   //ㅍ
                                   .Replace("피던 ", "피다 ")
                                   //ㅎ
                                   .Replace("하고 ", " ")
                                   .Replace("하고자하다 ", "하다 ")
                                   .Replace("하거나 ", "하다 ")
                                   .Replace("하기 ", "하다 ")
                                   .Replace("하기도 ", "하다 ")
                                   .Replace("하는 ", "하다 ")
                                   .Replace("하다 ", "하다 ")
                                   //"하다보면"에서 "하다보다 그러면"으로 나누어지므로 "하다"를 "하다 "로 수정한다.
                                   .Replace("하다거나 ", "하다 ")
                                   .Replace("하려다 ", "하다 ")
                                   .Replace("하며 ", "하다 ")
                                   .Replace("하면 ", "하다 그러면 ")
                                   .Replace("하면서 ", "하다 그러면서 ")
                                   .Replace("하므 ", "하다 ")//"열악하므로"에서 "로"를 위에서 소거시켰으므로 "하므"를 변형시킨다.
                                   .Replace("하여 ", "하다 ")
                                   .Replace("하였다 ", "하다 ")//시제는 과거형으로 유지하지 않고 현재형으로 바꾸었다.
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
                                   .Replace("해놓자 ", "하다 ")
                                   .Replace("해나가다 ", "하다 ")
                                   .Replace("해다 ", "하다 ")
                                   .Replace("해보다 ", "하다 ") //"해보는"에서 "는"을 위에서 "다"로 바꾸므로 "하다"로 바꾼다.
                                   .Replace("해서 ", "하다 ")
                                   .Replace("해서는 ", "하다 ")
                                   .Replace("해주다 ", "하다 ")
                                   .Replace("해지다 ", "하다 ")//"해지고"에서 "고"를 위에서 "다"로 처리했으므로 "해지다"를 "하다"로 바꾼다.
                                   .Replace("했느냐 ", "하다 ")
                                   .Replace("했다 ", "하다 ")
                                   .Replace("했더라 ", "하다 ")
                                   //"했더라도" 이지만 앞에서 "도"를 소거시켰으므로 "했더라"만 다시 소거시킨다.
                                   .Replace("혀보다 ", "히다 ")
                                   //"넓혀보면"에서 위에서 "넓혀보다 그러면"으로 바꾸고
                                   //"넓혀보다"를 "넓히다"로 바꾸고 아래에서 "히다"를 "다"로 바꾼다.
                                   .Replace("혀있다 ", "히다 ") //"얽혀있다."를 "얽히다"로 바꾼다.
                                   .Replace("히 ", "하다 ")
                                   .Replace("히다 ", "다 ")


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

                    " " //split으로 조건부 단나눔을 안해야 아래 replace가 작동한다.

                        }, StringSplitOptions.None);

                foreach (string B in arr)
                    // 캡슐화의 기본은 백과사전을 기본으로 한다.
                    //캡슐화는 말뭉치로 해석할 수 있다.
                {
                    sw.WriteLine("{0}", B
                               //아래 주석처럼 고찰할 내용이 있는 어휘는 어휘 뒤에 주석으로 의견을 달아두었다.

                               //한문장에 분류 1개만 나오더라도 다른 문장과 연결하면 전체 분류가 가능할 것이다.

                               //일 이라는 단어는 1일로 쓰이면 물리학이 아닌데 물리학으로 된다.
                               //그러므로 빈도수가 가장 높은 분류를 위주로 해석해야한다.
                               //즉 빈도수에서 1위인 학문으로 분류해둔다.
                               //내가 읽으면서 정리해도 빈도수 1위인 학문으로 글이 읽혀진다.

                               //캡슐화 어휘는 1만 단어면 충분할지 고민이 된다.

                               //대분류
                               //대분류를 상위처리해야 [[의학]] 이런 이중처리가 방지된다.
                               .Replace("건축학", "[건축학]")
                               .Replace("경영학", "[경영학]")
                               .Replace("경제학", "[경제학]")
                               //.Replace("과학", "[과학]") //과학은 물리학 생물학 화학으로 갈라지므로 제외한다.
                               //.Replace("공학", "[공학]") //공학은 컴퓨터공학 통신공학 토목공학 등으로 갈라지므로 제외한다.
                               .Replace("교육학", "[교육학]")
                               .Replace("군사학", "[군사학]")
                               .Replace("금융학", "[금융학]")
                               .Replace("기계공학", "[기계공학]")
                               .Replace("도시공학", "[도시공학]")
                               .Replace("물리학", "[물리학]")
                               .Replace("부동산학", "[부동산학]")
                               .Replace("사회학", "[사회학]")
                               .Replace("생물학", "[생물학]")
                               .Replace("수학", "[수학]")
                               .Replace("신문방송학", "[신문방송학]")
                               .Replace("신학", "[신학]")
                               .Replace("심리학", "[심리학]")
                               .Replace("의학", "[의학]")
                               .Replace("인문학", "[인문학]")
                               .Replace("정치학", "[정치학]")
                               .Replace("지질학", "[지질학]")
                               .Replace("천문학", "[천문학]")
                               .Replace("철학", "[철학]")
                               .Replace("토목공학", "[토목공학]")
                               .Replace("통신공학", "[통신공학]")
                               .Replace("컴퓨터공학", "[컴퓨터공학]")
                               .Replace("해부학", "[해부학]")
                               .Replace("해양학", "[해양학]")
                               .Replace("행정학", "[행정학]")
                               .Replace("화학", "[화학]")

                               //소분류

                               //알파벳
                               .Replace("AI", "[컴퓨터공학]")
                               .Replace("CEO", "[경영학]")
                               .Replace("GTX", "[부동산학]")
                               .Replace("MBN", "[신문방송학]")
                               .Replace("Microsoft", "[경영학]")
                               .Replace("PC", "[컴퓨터공학]")
                               .Replace("physics", "[물리학]")
                               .Replace("tensor", "[수학]")
                               .Replace("VC", "[경영학]")
                               .Replace("windows", "[컴퓨터공학]")

                               //숫자
                               .Replace("3D프린터", "[기계공학]")

                               //ㄱ
                               .Replace("가격", "[경제학]")
                               .Replace("감정", "[철학]")
                               .Replace("개발자", "[컴퓨터공학]")
                               .Replace("개체", "[컴퓨터공학] [수학]")
                               .Replace("거리", "[수학]")
                               .Replace("건설", "[토목공학]")
                               .Replace("건물", "[건축학]")
                               .Replace("건축", "[건축학]")
                               .Replace("검색", "[컴퓨터공학]")
                               .Replace("경영권", "[경영학]")
                               .Replace("경제", "[경제학]")
                               .Replace("고객", "[경영학]")
                               .Replace("고등학교", "[교육학]")
                               .Replace("고등학생", "[교육학]")
                               .Replace("고생대", "[지질학]")
                               .Replace("고전역학", "[물리학]")
                               //.Replace("과학자", "[과학]") //과학을 대분류에서 제외시켰으므로 과학자는 처리할 수 없다.
                               .Replace("계산이론", "[수학]")
                               .Replace("고온", "[물리학]")
                               .Replace("곡선", "[수학]")
                               .Replace("공간", "[물리학] [수학]")
                               .Replace("공리", "[수학]")
                               .Replace("공식", "[수학]")
                               .Replace("꼬리뼈", "[해부학]")
                               .Replace("교사", "[교육학]")
                               .Replace("교수", "[교육학]")
                               .Replace("교통", "[부동산학]")
                               .Replace("국회", "[정치학]")
                               .Replace("국민의힘", "[정치학]")
                               .Replace("군단장", "[군사학]")
                               .Replace("귀납", "[언어학] [수학]")
                               .Replace("그래픽", "[컴퓨터공학]")
                               .Replace("금융", "[금융학]")
                               .Replace("근로자", "[사회학]")
                               .Replace("급락", "[수학]")
                               .Replace("기업", "[경영학]")
                               .Replace("기자회견", "[사회학]")
                               .Replace("기하학", "[수학]")

                               //ㄴ
                               .Replace("노동자", "[사회학]")
                               .Replace("노병", "[군사학]")
                               .Replace("논리", "[수학]")
                               .Replace("뉴스", "[사회학]")
                               .Replace("뉴턴", "[물리학] [수학]")

                               //ㄷ
                               .Replace("대수", "[수학]")
                               .Replace("대치동", "[부동산학]")
                               .Replace("대통령", "[정치학]")
                               .Replace("데카르트", "[수학] [철학]") // 고유명사는 캡슐화가 쉬워지게 한다.
                               .Replace("디지털", "[컴퓨터공학]")
                               .Replace("도시", "[도시공학]")
                               .Replace("동역학", "[물리학]")
                               .Replace("등뼈", "[해부학]")

                               //ㄹ
                               .Replace("레스토랑", "[인문학]")
                               .Replace("링크드인", "[경영학]")

                               //ㅁ
                               .Replace("마르코프", "[수학]")
                               .Replace("마을", "[사회학]")
                               .Replace("마이크로소프트", "[경영학]")
                               .Replace("만물", "[물리학]")
                               .Replace("망원경", "[천문학]")
                               .Replace("매도세", "[경영학]")
                               .Replace("매출액", "[경영학]")
                               .Replace("매출", "[경영학]")
                               .Replace("미분", "[수학]")
                               //.Replace("미분방정식", "[수학]")
                               //"미분"이라는 단어가 앞서 먼저 나왔으므로 "미분방정식"은 지우도록 한다.
                               .Replace("무리수", "[수학]")
                               .Replace("미적분", "[수학]")
                               .Replace("무릎", "[해부학]")
                               .Replace("무한", "[수학]")
                               .Replace("무한대", "[수학]")
                               .Replace("무한소", "[수학]")
                               .Replace("문화", "[인문학]")
                               .Replace("물고기", "[생물학]")
                               .Replace("물리", "[물리학]")
                               .Replace("물질", "[화학]")

                               //ㅂ
                               .Replace("바다", "[해양학]")
                               .Replace("박근혜", "[정치학]")
                               .Replace("방영", "[신문방송학]")
                               .Replace("방정식", "[수학]")
                               .Replace("방청석", "[정치학]") //방청석은 의회용어이다.
                               .Replace("버핏", "[경영학]")
                               .Replace("벌레", "[생물학]")
                               .Replace("범주론", "[수학]")
                               .Replace("벡터", "[수학]")
                               .Replace("벤처캐피털", "[경영학]")
                               .Replace("병원", "[의학]")
                               .Replace("부분집합", "[수학]")
                               .Replace("부촌", "[부동산학]")

                               //ㅅ
                               .Replace("사모투자펀드", "[경영학]")
                               .Replace("사물", "[물리학]")
                               .Replace("사업", "[경영학]")
                               .Replace("사단장", "[군사학]")
                               .Replace("사회", "[사회학]")
                               .Replace("산수", "[수학]")
                               .Replace("상대성이론", "[물리학]")
                               .Replace("상업", "[부동산학]")
                               .Replace("생명", "[생물학]")
                               .Replace("생물", "[생물학]")
                               .Replace("생선", "[생물학]")
                               .Replace("선형", "[수학]")
                               .Replace("성리학", "[철학]")
                               .Replace("세계", "[사회학]")
                               .Replace("소리", "[물리학]")
                               .Replace("소니", "[경영학]")
                               .Replace("송금", "[금융학]")
                               .Replace("수량", "[수학]")
                               .Replace("수리", "[수학]")
                               .Replace("수리논리학", "[수학]")
                               .Replace("수식", "[수학]")
                               .Replace("수업", "[교육학]")
                               .Replace("숫자", "[수학]")
                               .Replace("스타벅스", "[경영학]")
                               .Replace("스타트업", "[경영학]")
                               .Replace("시각", "[생물학]")
                               .Replace("시간", "[물리학]")
                               .Replace("시장", "[경제학]")
                               .Replace("시청률", "[신문방송학]")
                               .Replace("시청자", "[신문방송학]")
                               .Replace("실수", "[수학]")
                               .Replace("실재론", "[철학]")

                               //ㅇ
                               .Replace("아리스토텔레스", "[수학]")
                               .Replace("아인슈타인", "[물리학]")
                               .Replace("아웃룩", "[컴퓨터공학]")
                               .Replace("양서류", "[생물학]")
                               .Replace("양자", "[물리학]")
                               .Replace("어류", "[생물학]")
                               .Replace("언어", "[언어학]")
                               .Replace("업무", "[사회학]")
                               .Replace("엑셀", "[컴퓨터공학]")
                               .Replace("연역", "[언어학] [수학]")
                               .Replace("열역학", "[물리학]")
                               .Replace("영상", "[디자인학]")
                               .Replace("영혼", "[신학]")
                               .Replace("예능", "[신문방송학]")
                               .Replace("예비역", "[군사학]")
                               .Replace("온도", "[물리학]")
                               .Replace("우주", "[물리학]")
                               .Replace("운동", "[물리학]")
                               .Replace("운영체제", "[컴퓨터공학]")
                               .Replace("워드", "[컴퓨터공학]")
                               .Replace("원노트", "[컴퓨터공학]")
                               .Replace("유리수", "[수학]")
                               .Replace("유치원생", "[교육학]") //"유치원생"은 "[교육학]생"이 되므로 유치원생을 유치원보다 상위로 둔다.
                               .Replace("유치원", "[교육학]")
                               .Replace("유클리드", "[수학]")
                               .Replace("육종암", "[의학]")
                               .Replace("윤석열", "[정치학]")
                               .Replace("위상", "[수학]")
                               .Replace("윈도우", "[컴퓨터공학]")
                               .Replace("은행", "[금융학]")
                               .Replace("응급실", "[의학]")
                               .Replace("의대", "[의학]")
                               .Replace("의료", "[의학]")
                               //.Replace("이공", "[수학] [물리학]")
                               .Replace("이과", "[물리학] [수학]")
                               .Replace("이빨", "[해부학]")
                               .Replace("인공지능", "[컴퓨터공학]")
                               .Replace("인사혁신처", "[정치학]")
                               .Replace("인수", "[경영학]")
                               //.Replace("입", "[해부학]") //입이라는 단어는 해부학 말고 자주 쓰일듯 하므로 주석처리한다.
                               .Replace("입시", "[교육학]")
                               //.Replace("일", "[물리학]")
                               //물리학에서 일이라는 단어보다 날짜에서 일이라는 단어가 더 자주 쓰이므로
                               //물리학에서 일이라는 단어는 주석처리 한다.

                               //ㅈ
                               .Replace("자연", "[물리학]")
                               .Replace("전자기학", "[물리학]")
                               .Replace("정권", "[정치학]")
                               .Replace("정부", "[정치학]")
                               .Replace("정수", "[수학]")//수에서 정수가 있으나, 핵심 요지에서 정수도 있다.
                               .Replace("정신", "[철학]")
                               .Replace("정책", "[정치학]")
                               .Replace("제도", "[사회학]")
                               .Replace("조건", "[수학]")
                               .Replace("주가", "[경영학]")
                               .Replace("주거", "[부동산학]")
                               .Replace("주주총회", "[경영학]")
                               .Replace("주주", "[경영학]")
                               .Replace("중학교", "[교육학]")
                               .Replace("중학생", "[교육학]")
                               .Replace("진단", "[의학]")
                               .Replace("진료", "[의학]")
                               .Replace("집합", "[수학]")
                               .Replace("집합론", "[수학]")

                               //ㅊ
                               .Replace("차원", "[수학]")
                               .Replace("창업주", "[경영학]")
                               .Replace("척추", "[해부학]")
                               .Replace("천체", "[천문학]")
                               .Replace("체인점", "[경영학]")
                               .Replace("초끈이론", "[물리학]")
                               .Replace("초등학교", "[교육학]")
                               .Replace("초등학생", "[교육학]")
                               .Replace("추상", "[수학]")
                               .Replace("측도", "[수학]")

                               //ㅌ
                               .Replace("턱", "[해부학]")
                               .Replace("텐서", "[수학]")
                               .Replace("통계", "[수학]")
                               .Replace("통신", "[통신공학]") //통신공학으로 학문분류 맞추어도 되는지 모르겠다.
                               .Replace("통증", "[의학]")
                               .Replace("투자", "[경영학]")
                               .Replace("특검법", "[정치학]")

                               //ㅍ
                               .Replace("파워포인트", "[컴퓨터공학]")
                               .Replace("파충류", "[생물학]")
                               .Replace("포유류", "[생물학]")
                               .Replace("표정", "[심리학]")
                               .Replace("푸앵카레", "[수학]")
                               .Replace("프로그래밍", "[컴퓨터공학]")
                               .Replace("프로그램", "[컴퓨터공학]") //프로그램은 컴퓨터공학, 신문방송학 2가지로 쓰인다.
                               .Replace("플라스틱", "[화학]")
                               .Replace("필라멘트", "[물리학] [화학]")

                               //ㅋ
                               .Replace("카페", "[인문학]")
                               .Replace("커피", "[식품학]")
                               .Replace("컴퓨터", "[컴퓨터공학]")
                               //위에서 [컴퓨터공학]으로 처리하면 컴퓨터 단어 때문에 [[컴퓨터공학]공학]으로 이중처리되며
                               //컴퓨터라는 단어보다 [컴퓨터공학]이라는 소분류가 더 많으므로 컴퓨터는 주석처리한다.
                               //그러나 이중처리되도 추후 프로그램 구조상 문제없게 설계하면 되므로 이중처리되도 그냥 한다.
                               .Replace("클라우드", "[컴퓨터공학]")

                               //ㅎ
                               .Replace("하락", "[수학]")
                               .Replace("학교", "[교육학]")
                               .Replace("학원", "[교육학]")
                               .Replace("한자", "[언어학]")
                               .Replace("함수", "[수학]")
                               .Replace("합병", "[경영학]")
                               .Replace("해석학", "[수학]")
                               .Replace("해병", "[군사학]")
                               .Replace("해병대", "[군사학]")
                               .Replace("행정", "[행정학]")
                               .Replace("현재", "[물리학]") //현재 라는 단어는 사람들이 물리학으로 쓰지는 않는다.
                               .Replace("형이상학", "[수학]")
                               .Replace("혜성", "[천문학]")
                               .Replace("혼란", "[철학]")
                               .Replace("확률", "[수학]")
                               .Replace("환자", "[의학]")
                               .Replace("희귀병", "[의학]")
                               .Replace("희귀암", "[의학]")
                               .Replace("힘", "[물리학]")
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
