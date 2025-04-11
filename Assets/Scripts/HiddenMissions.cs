using UnityEngine;
using UnityEngine.UI;

public class HiddenMissions : MonoBehaviour
{
    public Text myText;
    int stage;

    string[] mission = new string[4]
        {
            "동일한 카드를 3번 이상 뒤집지 않기",
            "40초 내로 4개의 짝을 맞춰라!",
            "카드 연속으로 4회 맞추기",
            "카드 짝 300회 맞추기"
        };

    string success = "히든 미션 성공!";

    // Start is called before the first frame update
    void Start()
    {
        stage = PlayerPrefs.GetInt("stage");
        missionTextChange();
    }

    void Update()
    {
        if (stage == 4)
        {
            if (GameManager.Instance.cardCount == 24 && GameManager.Instance.time > 40.0f)
            {
                PlayerPrefs.SetInt("Archive1", 1);
                missionTextChange();
            }
        }
    }

    public void missionTextChange()
    {
        myText.text = "";
        if (stage == 2)
        {
            if (PlayerPrefs.HasKey("Archive0"))
                myText.text += success;
            else
                myText.text += mission[0];
        }
        if (stage == 4)
        {
            if (PlayerPrefs.HasKey("Archive1"))
                myText.text += success;
            else
                myText.text += mission[1];
        }
        if (stage == 6)
        {
            if (PlayerPrefs.HasKey("Archive2"))
                myText.text += success;
            else
                myText.text += mission[2];
        }

        Archive3_Text();
    }

    void Archive3_Text()
    {
        // 업적이 달성되지 않았다면
        if (!PlayerPrefs.HasKey("Archive3"))
        {
            // 다른 히든 업적이 있을 경우 한 줄을 띄우고
            if (myText.text != "")
                myText.text += "\n";

            // 업적 설명 (수행횟수/300) 
            myText.text += (mission[3] + " (" + PlayerPrefs.GetInt("matchCountTotal") + "/300)");

            // 각종 키 명칭,300도 변수로 바꿔놓고 싶었지만 시간 부족
        }
    }
}
