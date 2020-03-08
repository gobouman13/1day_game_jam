using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	GameSystem gameSystem;

	int maxTime,nowTime;
	int minutes,second;
	float comma;

	int countGame,maxGame;


    // Start is called before the first frame update
    void Start()
    {

		maxGame = 4;
		
		gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {
		if(gameSystem.gameMode){
			maxTime = (int)Mathf.Ceil(gameSystem.defaultModeTime[gameSystem.nowMode]);
			nowTime = (int)Mathf.Ceil(maxTime - gameSystem.nowModeTime);
			second = 0;
			minutes = 0;
			int tmpTime = nowTime;
			while(tmpTime >= 60){
				minutes++;
				tmpTime -= 60;
			}
			second = tmpTime;
			transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((float)nowTime / (float)maxTime * 1620 + 300,100);
			if(second < 10)transform.GetChild(2).gameObject.GetComponent<Text>().text = minutes + ":0" + second;
			else transform.GetChild(2).gameObject.GetComponent<Text>().text = minutes + ":" + second;
			transform.GetChild(4).gameObject.GetComponent<Text>().text = countGame + " / " + maxGame;
		}
    }
}
