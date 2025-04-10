using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//using Unity.VisualScripting;

public class MainButton : MonoBehaviour
{
    public GameObject stageSelect;
    public GameObject stageBtn;

    public AudioSource audioSource;
    public AudioClip clip;
    public float delayTime = 0.3f;
    public int stageNum;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Title()
    {
        StartCoroutine(PlaySoundAndLoadScene("TitleScene"));
    }

    public void Profile()
    {
        StartCoroutine(PlaySoundAndLoadScene("ProfileTitleScene"));
    }
    public void Play()
    {
        StartCoroutine(PlaySoundAndLoadScene("MainScene"));
    }
    public void End()
    {
        StartCoroutine(PlaySoundAndLoadScene("EndingScene"));
    }
    public void Retry()
    {
        PlayerPrefs.SetInt("bestStage", stageNum); // 가장 높은 스테이지를 불러옴
        StartCoroutine(PlaySoundAndLoadScene("MainScene"));
    }
    public void StageSelect()
    {
        audioSource.PlayOneShot(clip);
        stageSelect.SetActive(true);
    }
    public void Exit()
    {
        stageSelect.SetActive(false);
    }

    IEnumerator PlaySoundAndLoadScene(string sceneName)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(delayTime);  // delayTime 만큼 대기
        }

        SceneManager.LoadScene(sceneName);
    }
}