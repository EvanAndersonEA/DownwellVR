using UnityEngine;
using Valve.VR;

public class Enemy_Behaviour : MonoBehaviour
{
    private GameObject player;
    private float distanceToTriggerFollow = 4.0f;
    private float speedOfFollowing = 1.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player_Collider");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceToTriggerFollow)
        {
            float step = speedOfFollowing * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            //transform.LookAt(player.transform);

        }
    }
}
