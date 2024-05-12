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
                    //띄어쓰기 혹은 기호를 처리해야 단나눔이 되어 단어들이 처리된다.
                    //안그러면 단어만 남는게 아닌 문장 통채로 남게된다.
                    " ",
                    ".",
                    ",",
                    "!",
                    "?",
                    "'",
                    "(",
                    ")",
                    "[",
                    "]",
                    "/",
                    ":",
                    "#"

                        }, StringSplitOptions.None);


                foreach (string B in arr)
                //다중if의 구조가 방대해지면 버려지는 어휘가 없을 것이다.
                //시작자 중간자 끝자를 고려하기 위하여 indexof를 적용시켰다.
                // >=0은 시작자에 쓰며 >=1은 끝자에 쓴다.

                //캡슐화_동사명사화_2에서 "사람과 "와 같이 조사+띄어쓰기로 끝자처리를 하였으나
                //다중if를 쓰면 보다 정확하게 처리될 것이라 예상하며 시작자인지 끝자인지
                //코드의 가독성에서도 다중if가 유리할 것이다.

                //다중if에서 if if로쓰면 동시처리되고 if else if로 해야 순차처리된다.
                //예를 들면 "생명이다." 라는 문장은
                //if if 일 때 indexof에 "다"와 "이" 2번 있어서 "생명이", "생명이다"로 2번 처리되며
                //if else if로 하면 "다"에서 "생명이다"로 한번만 처리되고 "이"는 생략된다.

                //if문의 순서상 시작자를 먼저 처리하고 조사를 끝자로 나중에 처리한다.

                {

                    //시작자

                    //"거느린"을 "거느리ㄴ"으로 자모해체도 하였다.
                    //자모를 해체해두면 나중에 어휘를 중간에 추가삽입할 때 편리할 것이다.

                    //동사명사화이므로 동사가 탈락변형되거나 조사가 탈락된다.
                    //즉 동사부분과 조사부분만 처리하면 동사명사화가 된다.

                    //다중if를 시작자로할지 끝자로할지 고민을 하였다.
                    //예를들면 "내렸다"는 "내렸"도 되고 "렸다"도 된다.
                    //그럴때 시작자로 처리하도록 임시로 지정하였다.

                    if (B.IndexOf("거느") >= 0)
                        //시작자를 "거느"로 할지 "거"로할지 고민할 때 "거느"가 맞다고 본다.
                        //"거"로하면 걸리는게 많아서 안된다.
                        sw.WriteLine(B
                            .Replace("거느린", "거느리ㄴ")
                            .Replace("거느리ㄴ", "거느리다")
                            );
                    else if (B.IndexOf("내렸") >= 0)
                        sw.WriteLine(B
                            .Replace("내렸다", "내려ㅆ다")
                            .Replace("내려ㅆ다", "내려다")
                            .Replace("내려다", "내리다")
                            );
                    else if (B.IndexOf("낼") >= 0)
                        sw.WriteLine(B
                            .Replace("낼", "내ㄹ다")
                            .Replace("내ㄹ다", "내다")
                            );
                    else if (B.IndexOf("달라") >= 0)
                        sw.WriteLine(B
                            .Replace("달라진다", "달라지ㄴ다")
                            .Replace("달라지ㄴ다", "달라지다")
                            );
                    else if (B.IndexOf("달리") >= 0)
                        sw.WriteLine(B
                            .Replace("달리", "다르다")
                            );
                    else if (B.IndexOf("막혀") >= 0)
                        sw.WriteLine(B
                            .Replace("막혀", "막히다")
                            );
                    else if (B.IndexOf("막히") >= 0)
                        sw.WriteLine(B
                            .Replace("막히지", "막히다")
                            .Replace("막히다", "막다")
                            );
                    else if (B.IndexOf("많") >= 0)
                        sw.WriteLine(B
                            .Replace("많기", "많다")
                            );
                    else if (B.IndexOf("않") >= 0)
                        sw.WriteLine(B
                            .Replace("않거나", "않다")
                            );
                    else if (B.IndexOf("없") >= 0)
                        sw.WriteLine(B
                            .Replace("없는건", "없는거ㄴ")
                            .Replace("없는거ㄴ", "없는거")
                            .Replace("없는거", "없는")
                            .Replace("없는", "없다")
                            );
                    else if (B.IndexOf("의해") >= 0)
                        sw.WriteLine(B
                            .Replace("의해", "의하다")
                            );

                    //끝자
                    //else if (B.IndexOf("기") >= 1)
                    //"많기"를 처리하지만 "조음기관"도 처리되므로 주석처리한다.
                    //    sw.WriteLine(B
                    //        .Replace("기", "다")
                    //        );
                    else if (B.IndexOf("다") >= 1)
                        //끝자에서 "-다"를 처리해야 하므로 "다음" 이 단어는 소거되도록 값을 1 이상으로 한다.
                        sw.WriteLine(B
                            .Replace("었다", "다")
                            .Replace("이다", "")
                            );
                    else if (B.IndexOf("란") >= 1)
                        sw.WriteLine(B
                            .Replace("란", "")
                            );
                    else if (B.IndexOf("만") >= 1)
                        sw.WriteLine(B
                            .Replace("만", "")
                            );
                    else if (B.IndexOf("에") >= 1)
                        sw.WriteLine(B
                            .Replace("에", "")
                            );
                    else if (B.IndexOf("의") >= 0)
                        sw.WriteLine(B
                            .Replace("의", "")
                            );
                    else if (B.IndexOf("한") >= 1)
                        sw.WriteLine(B
                            .Replace("한게", "하ㄴ게")
                            .Replace("하ㄴ게", "하ㄴ")
                            .Replace("한", "하ㄴ")
                            .Replace("하ㄴ", "하다")
                            );

                    //조사
                    //indexof는 자모순서로 배열하면 안된다. "돈과나다"라는 단어는 "과"먼저 처리되기 때문이다.
                    //언어규칙은 부정확하지만 동사를 우선 조사를 나중에 처리한다.
                    //조사 앞에는 중간자가 없고 뒤에는 항상 띄어쓰기가 오므로 조사 후처리가 정확하다고 본다.

                    else if (B.IndexOf("가") >= 1)
                        sw.WriteLine(B
                            .Replace("가", "")
                            );
                    else if (B.IndexOf("과") >= 1)
                        //"사과"라는 단어는 조사로 처리될 수 밖에 없다.
                        sw.WriteLine(B
                            .Replace("과", "")
                            );
                    else if (B.IndexOf("까지") >= 1)
                        sw.WriteLine(B
                            .Replace("까지", "")
                            );
                    else if (B.IndexOf("는") >= 1)
                        sw.WriteLine(B
                            .Replace("라는", "는")
                            .Replace("에서는", "는")
                            //"에서는"은 끝자가 "는"이므로 "에서"가 아니라 "는"에서 처리한다.
                            .Replace("는", "다")
                            );
                    else if (B.IndexOf("로") >= 1)
                        sw.WriteLine(B
                            .Replace("로", "")
                            );
                    else if (B.IndexOf("를") >= 1)
                        sw.WriteLine(B
                            .Replace("를", "")
                            );
                    else if (B.IndexOf("부터") >= 1)
                        sw.WriteLine(B
                            .Replace("부터", "")
                            );
                    else if (B.IndexOf("에게") >= 1)
                        sw.WriteLine(B
                            .Replace("에게", "")
                            );
                    else if (B.IndexOf("에서") >= 1)
                        sw.WriteLine(B
                            .Replace("에서", "")
                            );
                    else if (B.IndexOf("와") >= 1)
                        sw.WriteLine(B
                            .Replace("와", "")
                            );
                    else if (B.IndexOf("이") >= 1)
                        sw.WriteLine(B
                            .Replace("이", "")
                            );
                    else if (B.IndexOf("은") >= 1)
                        sw.WriteLine(B
                            .Replace("은", "")
                            );
                    else if (B.IndexOf("을") >= 1)
                        sw.WriteLine(B
                            .Replace("을", "")
                            );
                    else if (B.IndexOf("적인") >= 1)
                        sw.WriteLine(B
                            .Replace("적인", "이다")
                            );
                    else if (B.IndexOf("조차") >= 1)
                        sw.WriteLine(B
                            .Replace("조차", "")
                            );

                    //접속사
                    else if (B.IndexOf("그리고") >= 1)
                        sw.WriteLine(B
                            .Replace("그리고", "")
                            );
                    else if (B.IndexOf("그런데") >= 1)
                        sw.WriteLine(B
                            .Replace("그런데", "")
                            );
                    else if (B.IndexOf("그러나") >= 1)
                        sw.WriteLine(B
                            .Replace("그러나", "")
                            );
                    else if (B.IndexOf("그래도") >= 1)
                        sw.WriteLine(B
                            .Replace("그래도", "")
                            );
                    else if (B.IndexOf("그래서") >= 1)
                        sw.WriteLine(B
                            .Replace("그래서", "")
                            );
                    else if (B.IndexOf("또는") >= 1)
                        sw.WriteLine(B
                            .Replace("또는", "")
                            );
                    else if (B.IndexOf("게다가") >= 1)
                        sw.WriteLine(B
                            .Replace("게다가", "")
                            );
                    else if (B.IndexOf("따라서") >= 1)
                        sw.WriteLine(B
                            .Replace("따라서", "")
                            );
                    else if (B.IndexOf("때문에") >= 1)
                        sw.WriteLine(B
                            .Replace("때문에", "")
                            );
                    else if (B.IndexOf("아니면") >= 1)
                        sw.WriteLine(B
                            .Replace("아니면", "")
                            );
                    else if (B.IndexOf("왜냐하면") >= 1)
                        sw.WriteLine(B
                            .Replace("왜냐하면", "")
                            );
                    else if (B.IndexOf("하지만") >= 1)
                        sw.WriteLine(B
                            .Replace("하지만", "")
                            );
                    else if (B.IndexOf("오히려") >= 1)
                        sw.WriteLine(B
                            .Replace("오히려", "")
                            );
                    else if (B.IndexOf("비록") >= 1)
                        sw.WriteLine(B
                            .Replace("비록", "")
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

                               //학술어휘는 명사밖에 없다.

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
                               .Replace("생화학", "[생화학]")
                               .Replace("수학", "[수학]")
                               .Replace("식품학", "[식품학]")
                               .Replace("신문방송학", "[신문방송학]")
                               .Replace("신학", "[신학]")
                               .Replace("심리학", "[심리학]")
                               .Replace("언어학", "[언어학]")
                               .Replace("음악학", "[음악학]")
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
                               .Replace("DNA", "[의학]")
                               .Replace("GTX", "[부동산학]")
                               .Replace("MBN", "[신문방송학]")
                               .Replace("Microsoft", "[경영학]")
                               .Replace("PC", "[컴퓨터공학]")
                               .Replace("pH", "[화학]")
                               .Replace("physics", "[물리학]")
                               .Replace("tensor", "[수학]")
                               .Replace("VC", "[경영학]")
                               .Replace("windows", "[컴퓨터공학]")

                               //숫자
                               .Replace("3D프린터", "[기계공학]")

                               //ㄱ
                               .Replace("가격", "[경제학]")
                               .Replace("간식", "[식품학]")
                               .Replace("감사", "[철학]")
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
                               .Replace("광자", "[물리학]")
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
                               .Replace("근로자", "[사회학]")
                               .Replace("금속", "[화학]")
                               .Replace("금융", "[금융학]")
                               .Replace("급락", "[수학]")
                               .Replace("기업", "[경영학]")
                               .Replace("기자회견", "[사회학]")
                               .Replace("기체", "[화학]")
                               .Replace("기하학", "[수학]")

                               //ㄴ
                               .Replace("노동자", "[사회학]")
                               .Replace("노병", "[군사학]")
                               .Replace("논리", "[수학]")
                               .Replace("뉴런", "[의학]")
                               .Replace("뉴스", "[사회학]")
                               .Replace("뉴턴", "[물리학] [수학]")

                               //ㄷ
                               .Replace("단백질", "[생화학]")
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
                               .Replace("모음", "[언어학]")
                               .Replace("몸", "[의학]")
                               .Replace("무리수", "[수학]")
                               .Replace("무릎", "[해부학]")
                               .Replace("무한", "[수학]")
                               .Replace("무한대", "[수학]")
                               .Replace("무한소", "[수학]")
                               .Replace("문화", "[인문학]")
                               .Replace("물고기", "[생물학]")
                               .Replace("물리", "[물리학]")
                               .Replace("물질", "[화학]")
                               .Replace("물체", "[물리학]")
                               .Replace("미분", "[수학]")
                               //.Replace("미분방정식", "[수학]")
                               //"미분"이라는 단어가 앞서 먼저 나왔으므로 "미분방정식"은 지우도록 한다.
                               .Replace("미적분", "[수학]")

                               //ㅂ
                               .Replace("바다", "[해양학]")
                               .Replace("박근혜", "[정치학]")
                               .Replace("발작", "[의학]")
                               .Replace("방사선", "[물리학]")
                               .Replace("방영", "[신문방송학]")
                               .Replace("방정식", "[수학]")
                               .Replace("방청석", "[정치학]") //방청석은 의회용어이다.
                               .Replace("버핏", "[경영학]")
                               .Replace("벌레", "[생물학]")
                               .Replace("범주론", "[수학]")
                               .Replace("벡터", "[수학]")
                               .Replace("벤처캐피털", "[경영학]")
                               .Replace("병원", "[의학]")
                               .Replace("복지", "[사회학]")
                               .Replace("부분집합", "[수학]")
                               .Replace("부촌", "[부동산학]")
                               .Replace("분자", "[화학]")
                               .Replace("비금속", "[화학]")
                               .Replace("빵", "[식품학]")

                               //ㅅ
                               .Replace("사모투자펀드", "[경영학]")
                               .Replace("사물", "[물리학]")
                               .Replace("사업", "[경영학]")
                               .Replace("사단장", "[군사학]")
                               .Replace("사회", "[사회학]")
                               .Replace("산성", "[화학]")
                               .Replace("산수", "[수학]")
                               .Replace("산화", "[화학]")
                               .Replace("상대성이론", "[물리학]")
                               .Replace("상업", "[부동산학]")
                               .Replace("샐러드", "[식품학]")
                               .Replace("생명", "[생물학]")
                               .Replace("생물", "[생물학]")
                               .Replace("생선", "[생물학]")
                               .Replace("선형", "[수학]")
                               .Replace("성리학", "[철학]")
                               .Replace("세계", "[사회학]")
                               .Replace("소니", "[경영학]")
                               .Replace("소리", "[물리학]")
                               .Replace("소아암", "[의학]")
                               .Replace("송금", "[금융학]")
                               .Replace("수량", "[수학]")
                               .Replace("수리", "[수학]")
                               .Replace("수리논리학", "[수학]")
                               .Replace("수식", "[수학]")
                               .Replace("수업", "[교육학]")
                               .Replace("술", "[식품학]")
                               .Replace("숫자", "[수학]")
                               .Replace("스타벅스", "[경영학]")
                               .Replace("스타트업", "[경영학]")
                               .Replace("스테이크", "[식품학]")
                               .Replace("시각", "[생물학]")
                               .Replace("시간", "[물리학]")
                               .Replace("시력", "[의학]")
                               .Replace("시약", "[화학]")
                               .Replace("시장", "[경제학]")
                               .Replace("시청률", "[신문방송학]")
                               .Replace("시청자", "[신문방송학]")
                               .Replace("식사", "[사회학]")
                               .Replace("신경계", "[의학]")
                               .Replace("신경세포", "[의학]")
                               .Replace("신경", "[의학]")
                               .Replace("신체", "[의학]")
                               .Replace("실수", "[수학]")
                               .Replace("실재론", "[철학]")

                               //ㅇ
                               .Replace("아리스토텔레스", "[수학]")
                               .Replace("아인슈타인", "[물리학]")
                               .Replace("아웃룩", "[컴퓨터공학]")
                               .Replace("아웃백", "[경영학]")
                               .Replace("안주", "[식품학]")
                               .Replace("알데하이드", "[화학]")
                               .Replace("알코올", "[화학]")
                               .Replace("약물", "[의학]")
                               .Replace("양서류", "[생물학]")
                               .Replace("양성자", "[물리학]")
                               .Replace("양자", "[물리학]")
                               .Replace("어류", "[생물학]")
                               .Replace("어린이날", "[사회학]")
                               .Replace("언어", "[언어학]")
                               .Replace("업무", "[사회학]")
                               .Replace("엑셀", "[컴퓨터공학]")
                               .Replace("엔터테인먼트", "[경영학]")
                               .Replace("연역", "[언어학] [수학]")
                               .Replace("열역학", "[물리학]")
                               .Replace("염기성", "[화학]")
                               .Replace("염기", "[화학]")
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
                               .Replace("원자", "[화학]")
                               .Replace("유리수", "[수학]")
                               .Replace("유전병", "[의학]")
                               .Replace("유치원생", "[교육학]") //"유치원생"은 "[교육학]생"이 되므로 유치원생을 유치원보다 상위로 둔다.
                               .Replace("유치원", "[교육학]")
                               .Replace("유클리드", "[수학]")
                               .Replace("육종암", "[의학]")
                               .Replace("윤석열", "[정치학]")
                               .Replace("위상", "[수학]")
                               .Replace("윈도우", "[컴퓨터공학]")
                               .Replace("은행", "[금융학]")
                               .Replace("음식점", "[경영학]")
                               .Replace("음악", "[음악학]")
                               .Replace("음원", "[음악학]")
                               .Replace("응급실", "[의학]")
                               .Replace("의대", "[의학]")
                               .Replace("의료", "[의학]")
                               //.Replace("이공", "[수학] [물리학]")
                               .Replace("이과", "[물리학] [수학]")
                               .Replace("이빨", "[해부학]")
                               .Replace("인공지능", "[컴퓨터공학]")
                               .Replace("인사혁신처", "[정치학]")
                               .Replace("인수", "[경영학]")
                               .Replace("인스타그램", "[경영학]")
                               .Replace("임상시험", "[의학]")
                               //.Replace("입", "[해부학]") //입이라는 단어는 해부학 말고 자주 쓰일듯 하므로 주석처리한다.
                               .Replace("입시", "[교육학]")
                               .Replace("입자", "[물리학]") //입자는 화학이라 보지만 입자물리학 떄문에 물리학으로 한다.
                                                       //.Replace("일", "[물리학]")
                                                       //물리학에서 일이라는 단어보다 날짜에서 일이라는 단어가 더 자주 쓰이므로
                                                       //물리학에서 일이라는 단어는 주석처리 한다.

                               //ㅈ
                               .Replace("자연", "[물리학]")
                               .Replace("자음", "[언어학]")
                               .Replace("전기", "[물리학]")
                               .Replace("전자기학", "[물리학]")
                               .Replace("전자", "[물리학]")
                               .Replace("전하", "[물리학]")
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
                               .Replace("중성자", "[물리학]")
                               .Replace("중성", "[화학]")
                               .Replace("중학교", "[교육학]")
                               .Replace("중학생", "[교육학]")
                               .Replace("지방산", "[생화학]")
                               .Replace("지질", "[생화학]")
                               .Replace("진단", "[의학]")
                               .Replace("진료", "[의학]")
                               .Replace("집합", "[수학]")
                               .Replace("집합론", "[수학]")

                               //ㅊ
                               .Replace("차원", "[수학]")
                               .Replace("창업주", "[경영학]")
                               .Replace("척추", "[해부학]")
                               .Replace("천체", "[천문학]")
                               .Replace("청력", "[의학]")
                               .Replace("체인점", "[경영학]")
                               .Replace("초끈이론", "[물리학]")
                               .Replace("초등학교", "[교육학]")
                               .Replace("초등학생", "[교육학]")
                               .Replace("추상", "[수학]")
                               .Replace("측도", "[수학]")
                               .Replace("치료제", "[의학]")
                               .Replace("치매", "[의학]")

                               //ㅌ
                               .Replace("탄수화물", "[생화학]")
                               .Replace("턱", "[해부학]")
                               .Replace("텐서", "[수학]")
                               .Replace("통계", "[수학]")
                               .Replace("통신", "[통신공학]") //통신공학으로 학문분류 맞추어도 되는지 모르겠다.
                               .Replace("통증", "[의학]")
                               .Replace("투자", "[경영학]")
                               .Replace("특검법", "[정치학]")

                               //ㅍ
                               .Replace("파스타", "[식품학]")
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
                               .Replace("카복실산", "[화학]")
                               .Replace("카페", "[인문학]")
                               .Replace("커피", "[식품학]")
                               .Replace("컴퓨터", "[컴퓨터공학]")
                               //위에서 [컴퓨터공학]으로 처리하면 컴퓨터 단어 때문에 [[컴퓨터공학]공학]으로 이중처리되며
                               //컴퓨터라는 단어보다 [컴퓨터공학]이라는 소분류가 더 많으므로 컴퓨터는 주석처리한다.
                               //그러나 이중처리되도 추후 프로그램 구조상 문제없게 설계하면 되므로 이중처리되도 그냥 한다.
                               .Replace("케톤", "[화학]")
                               .Replace("콘서트", "[음악학]")
                               .Replace("쿼크", "[물리학]")
                               .Replace("크로뮴", "[화학]")
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
                               .Replace("행복", "[철학]")
                               .Replace("행정", "[행정학]")
                               .Replace("현재", "[물리학]") //현재 라는 단어는 사람들이 물리학으로 쓰지는 않는다.
                               .Replace("형이상학", "[수학]")
                               .Replace("혜성", "[천문학]")
                               .Replace("혼란", "[철학]")
                               .Replace("확률", "[수학]")
                               .Replace("환자", "[의학]")
                               .Replace("효소", "[생화학]")
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
