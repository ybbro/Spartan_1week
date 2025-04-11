using UnityEngine;

public class Archive3 : MonoBehaviour
{
    string matchCountTotal = "matchCountTotal";
    void Start()
    {
        // 처음 켜는 것이라면 카운트 데이터 생성
        if(!PlayerPrefs.HasKey(matchCountTotal))
            PlayerPrefs.SetInt(matchCountTotal, 0);
    }

    // !!! 프로젝트 머지 후 GameManager.cs >> Matched() >> 카드 맞췄을 때 호출하게끔 변경
    public void matchCountPlus()
    {
        int successStadard = 300; // 해당 수만큼 짝을 맞추면 업적 달성
        int plusCount = (PlayerPrefs.GetInt(matchCountTotal) + 1); // 맞춘 짝의 횟수 누적으로 1 증가
        PlayerPrefs.SetInt(matchCountTotal, plusCount); // 1증가한 짝 맞춘 횟수를 저장

        // 업적을 달성하면 약속한 값 넣어주기
        if (plusCount >= successStadard)
            PlayerPrefs.SetInt("Archive3", 1);
    }
}
