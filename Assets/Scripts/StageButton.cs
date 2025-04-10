using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public int stageNum;

    public void SelectStage()
    {
        PlayerPrefs.SetInt("stage", stageNum);
        SceneManager.LoadScene("MainScene");
    }
}
