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
        int bestStage = PlayerPrefs.GetInt("bestStage", 1);

        if (stageNum > bestStage)
        {
            button.interactable = false; // 비활성화
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
