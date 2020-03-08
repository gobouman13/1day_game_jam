using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] public float[] defaultModeTime;

    public float nowModeTime;

    [SerializeField] private int nowModeLength;
    public bool gameMode;
    public int nowMode;

	public int killCount;

    private MobSpawn MobSpawnSystem;
    
>>>>>>> ef94865859777c23306e0d8aa4b2cd312827dcc9
	public int killCount;
    
    public  MobSpawn MobSpawnSystem;
>>>>>>> 8a7492e26484ff72ad543f43b1f14a7d9d27673e
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
