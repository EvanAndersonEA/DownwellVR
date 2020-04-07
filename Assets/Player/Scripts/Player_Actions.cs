﻿using UnityEngine;

public class Player_Actions : MonoBehaviour
{
    [HideInInspector] public int player_Lifes = 3;
    private float impulse = 500.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Danger_Collider")
        {
            Debug.Log("DANGER");
            player_Lifes--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bouncing_Collider")
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * impulse);
            Destroy(collision.gameObject);
        }
    }
}