
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.UIElements;

public class BeholderController : MonoBehaviour
{
    public Transform target;
    Animator BeholderAnimator;
    public Transform selfPos;

    bool ISdie = false;
    bool IsAttack = false;
    bool IsRun = true;
    bool IsIdle = false;
    public bool sw = false;
    float maxheight = -0.5f;
    float minheight = -2.0f;
    float height;
    Vector3 direction;
    int BeholderHP = 3;
    // Start is called before the first frame update
    void OnEnable()
    {
        height = Random.Range(minheight, maxheight);
        BeholderAnimator = GetComponent<Animator>();
        direction = target.position;
        transform.LookAt(target);
        transform.position =  new Vector3(transform.position.x,height,transform.position.z);

    }
    public void Die()
    {
        ISdie = true;
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        StopCoroutine(AttackAndWait());
        BeholderAnimator.SetTrigger("Die");
        Destroy(gameObject, 2f);
        transform.Translate(0f, -1f, 0f);
        StopCoroutine(AttackAndWait());
        GameManager.instance.addcount();
    }

    IEnumerator AttackAndWait()
    {
  
        while (true)
        {
            if (sw == false)
            {
                BeholderAnimator.SetTrigger("Attack");
                float waitTime = 1.2f;
                sw = !sw;
                yield return new WaitForSeconds(waitTime);
                TimeSliderController.instance.Beholderattack();
            }
            else
            {
                float waitTime = 5f;
                sw = !sw;
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ISdie == true) return;
        float dis = Vector3.Distance(new Vector3(0f,height, 0f), transform.position);

        if (IsRun == true)
        {
            if (dis < 0) dis *= -1;

            if (dis <= 2.5f)
            {
                IsRun = false;
                IsIdle = true;
                BeholderAnimator.SetBool("Idle", true);
                BeholderAnimator.SetBool("Run", false);
                StartCoroutine(AttackAndWait());
                return;
            }
            //transform.Translate(direction * Time.deltaTime * 3f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f,height,0f), 2f * Time.deltaTime);
        }
        
    }

}
