using UnityEngine;
using UnityEngine.UI;

public class MemberInfo_Panel : MonoBehaviour
{
    public Text infoText; // 팀원 소개 문자열을 표시할 텍스트 컴포넌트
    public AudioSource audioSource; // 팀원 소개 패널이 등장/사라질 때 책장 넘기는 소리 재생할 오디오 컴포넌트

    // 팀원들의 소개를 담은 문자열의 배열
    string[] memberInfos = new string[4]
    {
        "이름: 곽미주\n" +
        "특징: 에러가 있었는데요. 없어졌습니다. 창의적인 방법으로 난해한 에러를 분쇄!\n\n" +
        "1. 가장 오래 플레이 한 게임: 스타크래프트1\n\n" +
        "2. 좋아하는 게임: 수집형, RPG 장르\n\n" +
        "3. 최근 플레이 중인 게임: 명조, 원신",

        "이름: 안홍현\n" +
        "특징: 게임에 대한 뛰어난 인사이트, 넓은 지식. 진행에 돌파구를 뚫어주는 든든한 팀원\n\n" +
        "1. 가장 오래 플레이 한 게임: Deep Rock Galactic, 젤다의 전설 -왕국의 눈물-, 드래곤 네스트, 킹스레이드\n\n" +
        "2. 좋아하는 게임: 장르를 가리지 않고 다양한 게임을 즐김. 공포 장르를 좋아한다\n\n" +
        "3. 최근 즐겨하는 게임: 킹덤컴2 딜리버런스, 몬스터헌터 와일즈",

        "이름: 이서형\n" +
        "특징: 팀 내 유일한 컴퓨터 공학 전공, 이 남자 알고리즘이 대단하다! 지뢰찾기 고수\n\n" +
        "1. 가장 오래 플레이 한 게임: 팀 포트리스2\n\n" +
        "2. 좋아하는 게임: 사이버 펑크 2077, 산데비스탄을 만들어 보는 것이 목표 중 하나\n\n" +
        "3. 최근 플레이 중인 게임: 폴아웃76, 토탈워 워해머",

        "이름: 박유빈\n" +
        "특징: 독학을 적지 않은 기간 진행했기에 요상한 기술을 여럿 습득. 아마도 팀장\n\n" +
        "1. 가장 오래 플레이 한 게임: 서머너즈워\n\n" +
        "2. 좋아하는 게임: 장르를 가리지 않지만 특히 액션 게임들을 선호\n\n"+
        "3. 최근 플레이 중인 게임: 랑그릿사 모바일, 트릭컬, 던전 앤 파이터",
    };

    private void OnEnable()
    {
        audioSource.Play();
    }
    private void OnDisable()
    {
        audioSource.Play();
    }

    public void InfoTextChange(int memberIndex)
    {
        infoText.text = memberInfos[memberIndex];
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
