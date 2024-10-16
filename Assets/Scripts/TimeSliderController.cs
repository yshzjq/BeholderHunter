using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSliderController : MonoBehaviour
{
    public static TimeSliderController instance;
    AudioSource hitsound;
    public GameObject hitdisplace;
    Slider timeSliderController;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        hitsound = GetComponent<AudioSource>();
        timeSliderController = GetComponent<Slider>();
        
    }
    public void End()
    {
        PlayerPrefs.SetInt("Score", GameManager.instance.killcnt);
        Debug.Log("End �ε� �Ŵ��� ���� ����");
        SceneManager.LoadScene("EndScene");
    }

    IEnumerator hitplace()
    {
        hitdisplace.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hitdisplace.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        hitdisplace.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hitdisplace.SetActive(false);

    }

    public void Beholderattack()
    {
        timeSliderController.value -= 30f;
        hitsound.Play();
        StartCoroutine(hitplace());

    }
    void Update()
    {
        timeSliderController.value -= (10f*Time.deltaTime);

        if(timeSliderController.value <= 0.1f)
        {
            Debug.Log("���ǹ� ����");
            End();
        }
    }
}
