using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	int maxTime,nowTime;
	int minutes,second;
	float comma;

	int countGame,maxGame;

	public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 300;
		nowTime = maxTime;

		maxGame = 4;

		gameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(gameStart){
			comma += Time.deltaTime;
			if(comma > 0){
				comma--;
				nowTime--;
				second = 0;
				minutes = 0;
				int tmpTime = nowTime;
				while(tmpTime >= 60){
					minutes++;
					tmpTime -= 60;
				}
				second = tmpTime;
			
				transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((float)nowTime / (float)maxTime * 720 + 300,50);
				transform.GetChild(2).gameObject.GetComponent<Text>().text = minutes + ":" + second;
				transform.GetChild(4).gameObject.GetComponent<Text>().text = countGame + " / " + maxGame;
			}
		}
    }
}
