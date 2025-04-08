using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
