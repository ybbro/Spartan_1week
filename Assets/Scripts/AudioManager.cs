using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;

    // 새로 추가한 사운드 클립들을 오디오 매니저에서 관리
    // 배경음들은 외부 스크립트에서 아래 주석 구문을 통해 호출 가능
    // AudioManager.Instance.ChangeBGM(AudioManager.Instance.클립이름);
    [Space, Header("배경음악들")]
    public AudioClip play_bgm;
    public AudioClip urgent_bgm, clear_bgm, fail_bgm;

    // 효과음들은 외부 스크립트에서 아래 주석 구문을 통해 호출 가능
    // AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.클립이름);
    [Space, Header("효과음들")]
    public AudioClip correct_sfx;
    public AudioClip wrong_sfx, flip_sfx;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    public void ChangeBGM(AudioClip bgmClip)
    {
        // 성공/실패 bgm은 한번만 재생하기에 루프 false
        // 나머지 bgm은 반복 재생하기에 루프 true
        if(bgmClip == clear_bgm || bgmClip == fail_bgm)
        {
            audioSource.loop = false;
        }
        else
        {
            audioSource.loop = true;
        }

        // 바꾸려는 클립으로 교체
        audioSource.clip = bgmClip;
        // 재생
        audioSource.Play();
    }
}
