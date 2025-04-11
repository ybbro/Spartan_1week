using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2Hidden : MonoBehaviour
{
    public GameObject hidden;
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        int stage = PlayerPrefs.GetInt("stage");
        if (stage == 2)
        {
            hidden.SetActive(true);
            myText.text = "20초 내로 4개의 짝을 맞춰라!";
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (GameManager.Instance.cardCount == 8 && GameManager.Instance.time > 20.0f)
        {
            myText.text = "히든 미션 성공!";
            PlayerPrefs.SetInt("Archive2", 1);
        }
    }
}
