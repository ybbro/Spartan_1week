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
    string failure = "히든 미션 실패...";

    bool isMissionFail = false;

    const string matchCountTotal = "matchCountTotal";

    // Start is called before the first frame update
    void Start()
    {
        // 처음 켜는 것이라면 카운트 데이터 생성
        if (!PlayerPrefs.HasKey(matchCountTotal))
            PlayerPrefs.SetInt(matchCountTotal, 0);

        stage = PlayerPrefs.GetInt("stage");
        missionTextChange();
    }

    void Update()
    {
        if (stage == 4 && !PlayerPrefs.HasKey("Archive1"))
        {
            // 제한 시간 내 4짝 이상을 맞춘 상태라면 업적 달성하고 텍스트 변경
            if (GameManager.Instance.time > 40.0f)
            {
                if (GameManager.Instance.cardCount < 24)
                {
                    PlayerPrefs.SetInt("Archive1", 1);
                    missionTextChange();
                }
            }
            // 제한 시간 내 카드를 24장 내로 줄이지 못하였다면 실패 알림으로 변경
            else 
            {
                SetFail();
            }
        }

        // 6스테이지에서 히든 미션을 성공하지 못한 상태로
        else if(stage == 6 && !PlayerPrefs.HasKey("Archive2"))
        {
            // 카드가 4짝 미만으로 남고, 체인이 0일 때
            if (GameManager.Instance.cardCount < 8 && GameManager.Instance.GetChain() == 0)
            {
                // 미션을 성공할 수 없기에 실패 문구 알림
                SetFail();
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
            else if (isMissionFail)
                myText.text += failure;
            else
                myText.text += mission[0];
        }
        if (stage == 4)
        {
            if (PlayerPrefs.HasKey("Archive1"))
                myText.text += success;
            else if(isMissionFail)
                myText.text += failure;
            else
                myText.text += mission[1];
        }
        if (stage == 6)
        {
            if (PlayerPrefs.HasKey("Archive2"))
                myText.text += success;
            else if (isMissionFail)
                myText.text += failure;
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
        else
        {
            // 다른 히든 업적이 있을 경우 한 줄을 띄우고
            if (myText.text != "")
                myText.text += "\n";

            // 업적 설명 (수행횟수/300) 
            myText.text += (mission[3] + " (달성)");
        }
    }

    // 미션 실패 때 호출
    // 해당 스테이지에서의 히든 미션 문구를 실패로 변경하여 플레이어에게 알림
    public void SetFail()
    {
        isMissionFail = true;
        missionTextChange();
    }

    // 카드 짝을 맞췄을 때 1씩 증가하는 카운터를 저장
    // 업적 달성 횟수를 넘으면 달성
    public void matchCountPlus()
    {
        int successStadard = 300; // 해당 수만큼 짝을 맞추면 업적 달성
        int plusCount = (PlayerPrefs.GetInt(matchCountTotal) + 1); // 맞춘 짝의 횟수 누적으로 1 증가
        PlayerPrefs.SetInt(matchCountTotal, plusCount); // 1증가한 짝 맞춘 횟수를 저장

        // 업적을 달성하면 약속한 값 넣어주기
        if (plusCount >= successStadard)
        {
            PlayerPrefs.SetInt("Archive3", 1);
        }

        // 변화에 따른 텍스트 변경
        missionTextChange();
    }
}
