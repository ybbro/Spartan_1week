using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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
    float time = 30.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //PlayerPrefs.SetInt("stage", 3);    //스테이지 선택(테스트용)
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        int a = PlayerPrefs.GetInt("stage");
        stageTxt.text = a.ToString();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (timeTxt.text == 0.0f.ToString("N2"))
        {
            Time.timeScale = 0.0f;
            overTxt.SetActive(true);
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
            if (cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
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
