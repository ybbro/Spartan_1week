using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRepeater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.ChangeBGM(AudioManager.Instance.play_bgm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
