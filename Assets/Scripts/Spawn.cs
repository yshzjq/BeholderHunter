using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] prefab;

    void Start()
    {
        StartCoroutine(WaitAndSpawn());
    }

    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            float waitTime = Random.Range(3.0f, 5.0f);
            yield return new WaitForSeconds(waitTime);

            for (int i = 0; i < Random.Range(1, 2); i++)
            {
                int iPrefab = Random.Range(0, prefab.Length);
                int iPos = Random.Range(0, pos.Length);

                GameObject obj = Instantiate(prefab[iPrefab], pos[iPos].position,Quaternion.identity);

                
            }
        }
    }
    
}
