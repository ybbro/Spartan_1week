using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2Hidden : MonoBehaviour
{
    // 텍스트로 미션이 어떤 것인지 알려줘서 좋음
    public GameObject hidden;
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        int stage = PlayerPrefs.GetInt("stage");
        if (stage == 2) // 스테이지 4에 들어가야 하지만 2로 되어 있음
        {
            hidden.SetActive(true);
            myText.text = "20초 내로 4개의 짝을 맞춰라!";
        }
    }

    void Update()
    { 
        // 2스테이지가 아니어도 해당 구문이 동작
        if (GameManager.Instance.cardCount == 8 && GameManager.Instance.time > 20.0f)
        {
            myText.text = "히든 미션 성공!";
            PlayerPrefs.SetInt("Archive2", 1); // Archive1에 들어가야 하는데 2로 잘못 기입
        }

        // 아마도 소통 실수
    }
}
