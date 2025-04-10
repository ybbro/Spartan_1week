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


    public int cardCount = 0;
    float time;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        int stage = PlayerPrefs.GetInt("stage");
        stageTxt.text = stage.ToString();
        time = stage * 20.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (timeTxt.text == 0.0f.ToString("N2"))
        {
            Time.timeScale = 0.0f;
            //overTxt.SetActive(true);
            // 여기에 실패 씬으로의 전환 !!!
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
                Time.timeScale = 0.0f;
                //endTxt.SetActive(true);
                // 여기에 성공 씬으로의 전환 !!!
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
}
