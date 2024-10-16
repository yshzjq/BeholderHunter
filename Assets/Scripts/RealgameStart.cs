using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealgameStart : MonoBehaviour
{
    // Start is called before the first frame update
    public void startgame()
    {
        StartCoroutine(startwait());

    }

    IEnumerator startwait()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameScene");
    }
}
