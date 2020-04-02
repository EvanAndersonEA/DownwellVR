using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public int lives = 3;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hurt")
        {
            lives--;
        }
        else
        {

        }
    }
}
