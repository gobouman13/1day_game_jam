using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTime : MonoBehaviour
{


    private float time;

    public Text timetext;


    // Start is called before the first frame update
    void Start()
    {
        time = 20.00f;
    }

    // Update is called once per frame
    void Update()
    {
        PhaseTimer();
    }
    public void PhaseTimer()
    {
        time -= Time.deltaTime;
        timetext.text = time.ToString("f2");

    }
}
