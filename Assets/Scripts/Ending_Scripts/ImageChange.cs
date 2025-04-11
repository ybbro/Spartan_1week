using UnityEngine;
using UnityEngine.UI;

// 주기적으로 UI 이미지 변경
public class ImageChange : MonoBehaviour
{
    public Image image; // 타겟 이미지
    public float changeTime = 0.5f; // 바꾸는 시간
    void Start()
    {
        if (!image)
            if (!TryGetComponent(out image))
                Debug.LogWarning("이미지 컴포넌트가 없어요.");

        Time.timeScale = 1; // 타임스케일이 0일 때는 인보크가 동작하지 않기에 게임 오버 때 0으로 만든 것을 원복
        InvokeRepeating("ChangeImage", 0, changeTime); // 일정한 주기로 이미지 변경
    }

    void ChangeImage()
    {
        // 팀원님들이 가져온 이미지들 중 랜덤한 것으로 변경
        int randomIndex = Random.Range(1, 41);
        image.sprite = Resources.Load<Sprite>($"{randomIndex}");
    }
}
