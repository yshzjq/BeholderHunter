using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public GameObject effect;

    public Animator btnAni;

    public AudioSource ShootAudio;
    public AudioSource ChargeAudio;

    bool shootReady = false;

    float clicktime;
    float unclicktime;

    
    
    // Update is called once per frame

    public void clicking()
    {
        ChargeAudio.Stop();
        ChargeAudio.Play();
        btnAni.SetBool("Clicking",true);
        clicktime = Time.time;
    }


    public void unclicking()
    {
        ChargeAudio.Stop();
        unclicktime = Time.time;

        if (unclicktime - clicktime >=1.2f)
        {
            ShootAudio.Play();
            Fire();
            btnAni.SetTrigger("chargecomplete");
        }
        btnAni.SetBool("Clicking", false);
    }

    void Fire()
    {
        RaycastHit hit;

        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if(hit.collider.tag == "Enemy")
            {
                BeholderController bh = hit.collider.GetComponent<BeholderController>();
                bh.Die();
                Instantiate(effect,hit.point,Quaternion.LookRotation(hit.normal));
            }
        }
        
    }
}
