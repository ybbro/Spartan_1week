using UnityEngine;

public class FireWork : MonoBehaviour
{
    public enum fireColor
    {
        파랑, // 0
        빨강, // 1
        보라, //2
        초록 // 3
    }

    public fireColor 이펙트_색상;

    Animator anim;
    RectTransform rectTransform;

    private void Awake()
    {
        TryGetComponent(out anim);
        TryGetComponent(out rectTransform);
    }

    private void OnEnable() // 해당 스크립트가 활성화 될 때 발동(오브젝트 활성화에도 발동)
    {
        anim.SetInteger("Color", (int)이펙트_색상);

        // 이펙트를 생성할 랜덤 위치
        // +, - 랜덤한 부호 뽑기
        int sign = 0;
        while (sign == 0) // sign이 0이면 다시 뽑기 >> -1, 1 이 나오면 루프 빠져나오게끔
        {
            sign = Random.Range(-1, 2); // -1, 0, 1 셋 중 하나의 값이 나옴
        }

        // 이펙트가 나타날 수 있는 위치 범위
        int posX_min = 250,
            posX_max = 300,
            posY_min = 0,
            posY_max = 500;

        // 랜덤 위치
        int posX = sign * Random.Range(posX_min, posX_max);
        int posY = Random.Range(posY_min, posY_max);

        // 이동
        rectTransform.anchoredPosition = new Vector2(posX, posY);

        // 사운드 이펙트 호출
        if(AudioManager.Instance)
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.fireWork_sfx);
    }

    // 애니메이션 끝나는 지점에 이벤트로 해당 메서드. 비활성화
    public void EffectEnd()
    {
        gameObject.SetActive(false);
    }
}
