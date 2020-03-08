using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public void BackTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void BackMain()
    {
        SceneManager.LoadScene(1);
    }
}
