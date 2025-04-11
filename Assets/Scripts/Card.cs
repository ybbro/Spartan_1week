using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class Card : MonoBehaviour
{
    public string idx;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;

    //AudioSource audioSource;
    //public AudioClip clip;

    float delay, timer = 0;
    Vector3 cardVector;

    int cardCountNumber = 0;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (timer > delay)
        {
            transform.position = Vector3.MoveTowards(transform.position, cardVector, Time.deltaTime * 10);
        }
        else { timer += Time.deltaTime; }
    }

    public void Setting(int number, Vector3 vector3, float delay)
    {
        idx = (number+1).ToString();
        frontImage.sprite = Resources.Load<Sprite>(idx);
        cardVector = vector3;
        this.delay = delay;
    }

    public void OpenCard()
    {
        if(GameManager.Instance.secondCard != null) return;
        //audioSource.PlayOneShot(clip);
        AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.flip_sfx);
        anim.SetBool("IsOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if(GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }

        int level = PlayerPrefs.GetInt("stage");

        if (level == 2)
        {
            CardFlipCount();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }

    public void CloseCardInvoke()
    {
        anim.SetBool("IsOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

    public void CardFlipCount()
    {
        if (anim.GetBool("IsOpen"))
        {
            cardCountNumber++;
            if(cardCountNumber >= 3)
            {
                GameManager.Instance.isArchive1Clear = false;
                GameManager.Instance.hiddenMissions.SetFail(); // 미션 실패 텍스트로 변경
            }
        }
    }
}
