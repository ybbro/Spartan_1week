using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class ProfileTitle : MonoBehaviour
{
    public Image[] teamImages;
    public MemberInfo_Panel memberInfo_Panel;

    void Start()
    {
        // 팀원이 제시한 이미지 중 하나를 랜덤으로 보여주기
        for (int i = 0; i < teamImages.Length; i++)
        {
            int randomNum = Random.Range((i * 10 + 1), (i * 10 + 11));
            teamImages[i].sprite = Resources.Load<Sprite>($"{randomNum}");
        }
    }

    // 타이틀로 돌아가는 버튼 : 다른 팀원님이 통합으로 만들고 관리
    //public void BackToTitle_Button()
    //{
    //    SceneManager.LoadScene("StartScene"); 
    //}

    // 선택한 팀원 이미지에 따라 알맞는 정보 출현
    public void PressMemberButton(int _memberIndex)
    {
        memberInfo_Panel.InfoTextChange(_memberIndex);
        memberInfo_Panel.gameObject.SetActive(true);
    }
}
