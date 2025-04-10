using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    float w, h = 1.0f, wgap, hgap;

    void Start()
    {
        int stage = PlayerPrefs.GetInt("stage");
        int[] deck = new int[stage * 8];

        //이번 게임에 나올 카드 고르기
        for (int i = 0; i < deck.Length; i += 2)
        {
            deck[i] = Random.Range((i / (stage * 2)) * 10, ((i / (stage * 2)) * 10 + 10));
            deck[i + 1] = deck[i];
        }

        deck = deck.OrderBy(x => Random.Range(0, deck.Length)).ToArray();

        //카드 배치 가로, 세로 카드의 수, 간격 계산
        
        for(int i = 0; i < (stage / 2); i++)
        {
            h *= 2;
        }
        h *= 2;
        w = deck.Length / h;

        if (h < w)
        {
            float temp = w;
            w = h;
            h = temp;
        }

        wgap = (6.0f - (w)) / (w + 1.0f);
        hgap = (6.0f - (h)) / (h + 1.0f);

        //자리 지정
        for (int i = 0; i < deck.Length; i++)
        {
            GameObject go = Instantiate(card, this.transform);
            
            float x = -3.0f + (wgap + 0.5f) + (i % (int)w) * (wgap + 1.0f);   // 가로 w
            float y = -3.5f + (hgap + 0.5f) + (int)(i / (int)w) * (hgap + 1.0f);   // 세로 h

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(deck[i]);
        }

        GameManager.Instance.cardCount = deck.Length;
        GameManager.Instance.cardCount = stage;
    }

}
