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

        //Time.timeScale = 1;
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
        // 시작하기! 버튼의 경우, 최고 클리어 스테이지 다음 스테이지를 불러오게끔 변경
        int nextStage = PlayerPrefs.GetInt("bestStage", 0) + 1;
        PlayerPrefs.SetInt("stage", nextStage);
        StartCoroutine(PlaySoundAndLoadScene("MainScene"));
    }
    public void End()
    {
        StartCoroutine(PlaySoundAndLoadScene("EndingScene"));
    }
    public void Retry()
    {
        //PlayerPrefs.GetInt("stage"); // 이미 "stage"에 이전에 실패한 스테이지의 값이 들어 있습니다.
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
            yield return new WaitForSecondsRealtime(delayTime);  // delayTime 만큼 대기
        }

        SceneManager.LoadScene(sceneName);
    }
}