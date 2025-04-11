using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class ProfileTitle : MonoBehaviour
{
    public Image[] teamImages;
    public MemberInfo_Panel memberInfo_Panel;

    UnityEngine.UI.Button[] teamButtons;
    Image[] frameImages;
    Text[] memberNameTexts;

    string[] memberNames = new string[4] { "곽미주", "안홍현",  "이서형", "박유빈", };

    void Start()
    {
        int memberNum = teamImages.Length;
        teamButtons = new UnityEngine.UI.Button[memberNum];
        frameImages = new Image[memberNum];
        memberNameTexts = new Text[memberNum];

        // 모든 팀원님들에 대해
        for (int i = 0; i < memberNum; i++)
        {
            // 팀원님들이 구해온 이미지의 이름은 1~10, 11~20, 21~30, 31~40 각 10장
            // 각 팀원님이 제시한 이미지 중 하나를 랜덤으로 보여주기

            // 주의!
            // int randomNum = Random.Range(int min, int max)
            // 정수형 값을 랜덤으로 받을 때, min <= randomNum < max까지의 값이 나올 수 있습니다.
            
            // 따라서, max에 해당하는 값은 나오지 않기에
            // 1~10 까지의 랜덤값을 받아올 때 Random.Range(1, 11) 을 써야 합니다.

            int randomNum = Random.Range((i * 10 + 1), (i * 10 + 11));
            teamImages[i].sprite = Resources.Load<Sprite>($"{randomNum}");

            // 팀원님 이미지와 정보창 띄우는 버튼은 같은 오브젝트 내에 존재하기에 이렇게 할당할 수 있습니다.
            teamButtons[i] = teamImages[i].GetComponent<UnityEngine.UI.Button>();

            // 이미지 프레임 오브젝트는 팀원님 이미지의 0번째 자식 오브젝트이기에 GetChild(0)로 오브젝트에 접근
            // 이미지 컴포넌트를 가져와서 할당하였습니다.
            frameImages[i] = teamImages[i].transform.GetChild(0).GetComponent<Image>();

            // 팀원님 이름을 표시하는 텍스트 오브젝트는 이미지 오브젝트의 자식 오브젝트이기에 GetComponentInChildren을 사용하여 찾기
            memberNameTexts[i] = teamImages[i].transform.GetComponentInChildren<Text>();

            // 도전과제를 완료했다면 해당 팀원님 프로필 활성화
            if(PlayerPrefs.HasKey($"archive{i}"))
                InfoEnable(i);
        }
    }

    // 선택한 팀원님 이미지에 따라 알맞는 정보 출현
    public void PressMemberButton(int _memberIndex)
    {
        // 팀원님의 정보로 텍스트를 바꿔주고(여기까진 비활성화 상태라 유저에게 보이지 않습니다.)
        memberInfo_Panel.InfoTextChange(_memberIndex);

        // 유저에게 보여줄 수 있도록 패널 오브젝트 활성화
        memberInfo_Panel.gameObject.SetActive(true);
    }

    // 도전과제가 만들어지고, 이에 따라 팀원님 프로필 해금에 쓰일 구문
    public void InfoEnable(int _memberIndex)
    {
        // 정보 보기 버튼 활성화
        teamButtons[_memberIndex].interactable = true;

        // 프레임 이미지의 기본 색이 노란색이기에
        // 이미지 컴포넌트의 색상을 흰색으로 바꿔주면
        // 원래 색상인 노란색으로 바뀝니다.
        frameImages[_memberIndex].color = Color.white;

        // 팀원님 이름을 써주고 노란색으로 텍스트 색상 변경
        memberNameTexts[_memberIndex].text = memberNames[_memberIndex];
        memberNameTexts[_memberIndex].color = Color.yellow;
    }

    // 히든 버튼: 도전과제를 완료하지 않더라도 Unity 10기 7조 텍스트를 누르면 모든 팀원님 정보를 볼 수 있게끔
    public void ICanSeeAllMemberInfo()
    {
        for (int i = 0; i < teamImages.Length; i++)
        {
            InfoEnable(i);
        }
    }

    // 타이틀로 돌아가는 버튼 : 다른 팀원님이 씬 전환 관리
    //public void BackToTitle_Button()
    //{
    //    SceneManager.LoadScene("StartScene"); 
    //}
}
