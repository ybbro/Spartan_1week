using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public int stageNum;
    public Button button;

    public void Start()
    {
        // 다음 스테이지 버튼이 해금되지 않는 이슈 해결 !
        // 기존 : int bestStage = PlayerPrefs.GetInt("bestStage",1);
        
        // 문제 발생 이유
        // 스테이지 클리어 때 "bestStage" 에는 클리어한 최고 스테이지를 저장. 예) 1스테이지 클리어 시 1 저장
        // 그러면 기존 식에서는 int bestStage = 1 의 값이 들어옵니다.
        
        // 아래의 if문에서 if(stageNum > 1) >> 2스테이지부터 버튼 비활성화
        // 1스테이지를 클리어 하였더라도 2스테이지 버튼이 활성화되지 않게 됩니다.

        // 변경 : 클리어한 최고 스테이지의 다음 스테이지를 지칭하게끔
        // 1스테이지 클리어 >> +1을 통해 최고 클리어 다음 스테이지 값인 2
        // if(stageNum > 2) >> 3스테이지 버튼부터 비활성화 >> 1, 2 스테이지 버튼이 활성화
        int nextStage = PlayerPrefs.GetInt("bestStage", 0) + 1;

        if (stageNum > nextStage)
        {
            button.interactable = false; // 버튼 기능 비활성화
        }
    }
    public void SelectStage()
    {
        PlayerPrefs.SetInt("stage", stageNum);
        SceneManager.LoadScene("MainScene");
    }
    public void NextStage()
    {
        stageNum++;
        PlayerPrefs.SetInt("stage", stageNum);
        SceneManager.LoadScene("MainScene");
    }
}
