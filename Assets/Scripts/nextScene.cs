using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{

    public void next()
    {
        StartCoroutine(nextnext());
        
    }

    IEnumerator nextnext()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("IntroScene");
    }
}
