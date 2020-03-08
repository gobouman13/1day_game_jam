using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private float[] defaultModeTime;

    private float nowModeTime;

    [SerializeField] private int nowModeLength;
    public bool gameMode;
    public int nowMode;
	public int killCount;

    public  MobSpawn MobSpawnSystem;
    public PhaseTime TimeScript;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameMode)
        {
            ChkModeTime();
        }
    }

    public void ChkModeTime()
    {
        nowModeTime += Time.deltaTime;
        if (nowModeTime > defaultModeTime[nowMode])
        {
            nowModeTime -= defaultModeTime[nowMode];
            nowMode++;
            if (nowMode >= nowModeLength) nowMode = 0;
            //MobSpawnSystem.ChangeMobMode(nowMode);
            Debug.Log("Changed Mode");
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Game Start");
        gameMode = true;

    }
    
}
