using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void restartLevel()
    {
        SceneManager.LoadScene("level 1 Take 3");
    }
}
