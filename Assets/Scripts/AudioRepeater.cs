using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRepeater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 해당 구문이 없으면 타이틀 씬으로 다시 돌아와도 배경음이 다시 재생되지 않습니다.
        AudioManager.Instance.ChangeBGM(AudioManager.Instance.play_bgm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
