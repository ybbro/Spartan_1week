using UnityEngine;

public class EndingManage : MonoBehaviour
{
    bool isClear;

    public Transform Clear_Buttons, Fail_Buttons;


    void Start()
    {
        // 성공/실패에 따라 bgm, 조작 가능한 버튼 변경
        //isClear = PlayerPrefs.get << 여기에 스테이지 성공 / 실패에 따라 파라미터 넣어주기
        if (isClear)
        {
            Clear_Buttons.gameObject.SetActive(true);
            Fail_Buttons.gameObject.SetActive(false);
            if (AudioManager.Instance)
                AudioManager.Instance.ChangeBGM(AudioManager.Instance.clear_bgm);
        }
        else
        {
            Clear_Buttons.gameObject.SetActive(false);
            Fail_Buttons.gameObject.SetActive(true);
            if (AudioManager.Instance)
                AudioManager.Instance.ChangeBGM(AudioManager.Instance.fail_bgm);
        }
    }
}
