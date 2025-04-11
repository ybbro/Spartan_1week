using UnityEngine;

public class FireWorkManage : MonoBehaviour
{
    public float fireDelay = 0.5f;
    
    int index = 0;

    void Start()
    {
        InvokeRepeating("CallEffect", 0, fireDelay);
    }

    void CallEffect()
    {
        // 이펙트 활성화
        transform.GetChild(index).gameObject.SetActive(true);
        // 다음 호출할 이펙트로
        if (++index >= transform.childCount)
            index = 0;
    }
}
