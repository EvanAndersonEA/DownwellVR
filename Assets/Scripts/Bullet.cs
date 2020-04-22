using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeleft;

    void Update()
    {
        timeleft -= Time.deltaTime;
        if(timeleft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
