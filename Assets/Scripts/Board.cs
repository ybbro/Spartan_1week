using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Overlays;

public class Board : MonoBehaviour
{
    public GameObject card;
    int deckLength;
    float w = 1.0f, h = 1.0f, wgap, hgap;
    Vector3[] cardVector;
    Vector2 deckPosition = new Vector2(0, -3.5f);

    void Start()
    {
        int stage = PlayerPrefs.GetInt("stage");
        int[] deck = new int[stage * 8];
        cardVector = new Vector3[stage * 8];

        //이번 게임에 나올 카드 고르기
        for (int i = 0; i < deck.Length; i += 2)
        {
            deck[i] = Random.Range((i / (stage * 2)) * 10, ((i / (stage * 2)) * 10 + 10));
            deck[i + 1] = deck[i];
        }

        deck = deck.OrderBy(x => Random.Range(0, deck.Length)).ToArray();

        //카드 배치 가로, 세로 카드의 수, 간격 계산
        deckLength = deck.Length;
        int c = 0;
        bool b = false;
        int[] compo = new int[deckLength];

        while (b == false)
        {
            if(deckLength %2 == 0)
            {
                compo[c] = 2;
                deckLength = deckLength / 2;
                c++;
            }
            else
            {
                compo[c] = deckLength;
                break;
            }
        }

        for (int i = c; i >= 0; i--)
        {
            if (h < w)
            {
                h *= compo[i];
            }
            else
            {
                w *= compo[i];
            }
        }

        if (h < w)
        {
            float temp = w;
            w = h;
            h = temp;
        }

        wgap = (6.0f - (w)) / (w + 1.0f);
        hgap = (6.0f - (h)) / (h + 1.0f);
        deckLength = deck.Length;
        bool last = false;
        //자리 지정
        for (int i = 0; i < deckLength; i++)
        {
            GameObject go = Instantiate(card, this.transform);
            float x = -3.0f + (wgap + 0.5f) + (i % (int)w) * (wgap + 1.0f);   // 가로 w
            float y = -3.5f + (hgap + 0.5f) + (int)(i / (int)w) * (hgap + 1.0f);   // 세로 h
            go.transform.position = deckPosition;
            float delay = i * 0.03f;
            //go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(deck[i], new Vector3(x, y, 0), delay);
        }

        GameManager.Instance.cardCount = deck.Length;
    }

    void Update()
    {
        
    }
}
