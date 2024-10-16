using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void startgame()
    {
        StartCoroutine(startwait());

    }

    IEnumerator startwait()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Tutorial");
    }

}
