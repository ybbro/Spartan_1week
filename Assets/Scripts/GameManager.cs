using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public Text stageTxt;
    public GameObject endTxt;
    public GameObject overTxt;

    AudioSource audioSource;
    public AudioClip clip;

    string BS = "bestStage";

    public int cardCount = 0;
    [SerializeField] float time;

    // 출시 전에는 false로 변경할 것!
    bool isCheatEnabled = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //PlayerPrefs.SetInt("stage", 4);    //스테이지 선택(테스트용)
    }

    void Start()
    {
        int stage = PlayerPrefs.GetInt("stage");
        stageTxt.text = stage.ToString();
        time = stage * 20.0f;

        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        int a = PlayerPrefs.GetInt("stage");
        stageTxt.text = a.ToString();

        AudioManager.Instance.ChangeBGM(AudioManager.Instance.play_bgm);
    }

    void Update()
    {
        if (isCheatEnabled)
        {
            // 테스트를 위한 치트
            if (Input.GetKeyDown(KeyCode.Alpha2)) // 2번 누르면 실패
                time = 0;
            else if (Input.GetKeyDown(KeyCode.Alpha1)) // 1번 누르면 바로 성공
                StageClear();
        }

        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time < 0)
        {
            time = 0;
            timeTxt.text = time.ToString("N2");
            Time.timeScale = 0.0f;
            //overTxt.SetActive(true);
            // 여기에 실패 씬으로의 전환
            SceneManager.LoadScene("EndingScene");
            PlayerPrefs.SetInt("isClear", 0);
        }
    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount <= 0)
            {
                StageClear();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard(); 
        }

        firstCard = null;
        secondCard = null;
    }

    void StageClear()
    {
        Time.timeScale = 0.0f;
        //endTxt.SetActive(true);

        int stage = int.Parse(stageTxt.text);
        if (PlayerPrefs.HasKey(BS))
        {
            int stageBest = PlayerPrefs.GetInt(BS);

            if (stage > stageBest)
            {
                PlayerPrefs.SetInt(BS, stage);
            }
            else
            {
                stage = stageBest;
            }
        }
        else { PlayerPrefs.SetInt(BS, stage); }
        // 여기에 성공 씬으로의 전환
        SceneManager.LoadScene("EndingScene");
        // 보통 프로그래밍에서 0이 거짓, 1이 참
        PlayerPrefs.SetInt("isClear", 1);
    }
}
