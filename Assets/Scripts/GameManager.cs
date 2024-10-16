using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text ScoreText;
    public int killcnt;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        killcnt = 0;
        ScoreText.text = "KILL : " + killcnt;
    }

    public void addcount()
    {
        killcnt++;
        ScoreText.text = "KILL : " + killcnt;
    }
}
