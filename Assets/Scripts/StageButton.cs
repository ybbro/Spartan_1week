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
        if (button)
        {
            int nextStage = PlayerPrefs.GetInt("bestStage", 0) + 1;

            if (stageNum > nextStage)
            {
                button.interactable = false;
            }
        }
    }
    public void SelectStage()
    {
        PlayerPrefs.SetInt("stage", stageNum);
        SceneManager.LoadScene("MainScene");
    }
    public void NextStage()
    {
        int nextStage = PlayerPrefs.GetInt("stage") + 1;
        PlayerPrefs.SetInt("stage", nextStage);
        SceneManager.LoadScene("MainScene");
    }
}
