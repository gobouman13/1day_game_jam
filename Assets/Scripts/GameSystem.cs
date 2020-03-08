using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private float[] defaultModeTime;

    private float nowModeTime;

    [SerializeField] private int nowModeLength;
    private int nowMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChkModeTime();   
    }

    void ChkModeTime()
    {
        nowModeTime += Time.deltaTime;
        if (nowModeTime > defaultModeTime[nowMode])
        {
            nowModeTime -= defaultModeTime[nowMode];
            nowMode++;
            if (nowMode >= nowModeLength) nowMode = 0;
            Debug.Log("Changed Mode");
        }
    }
}
