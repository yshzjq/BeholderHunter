using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }
}
