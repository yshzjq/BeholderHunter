using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public Text killText;
    public Text RankText;
    int killcnt;
    // Start is called before the first frame update
    void Start()
    {
        killcnt = PlayerPrefs.GetInt("Score");
        killText.text = "처리한 비홀더 수 : " + killcnt;
        RankText.fontSize = 150;

        if (killcnt >= 20)
        {
            RankText.text = "S";
            RankText.color = Color.yellow;
        }
        else if (killcnt >= 15)
        {
            RankText.text = "A";
            RankText.color = Color.red;
        }
        else if (killcnt >= 10)
        {
            RankText.text = "B";
            RankText.color = Color.blue;
        }
        else if (killcnt >= 5) {
            RankText.text = "C";
            RankText.color = Color.green;
        }
        else if (killcnt >= 0)
        {
            RankText.fontSize = 120;
             RankText.text = "자격 미달";
            RankText.color = Color.black;
        }


    }

}
