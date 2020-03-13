using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShootJump : MonoBehaviour
{
    public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_BooleanAction;

    [SerializeField]
    GameObject boolet;

    [SerializeField]
    GameObject player;

    GameObject freshBullet;

    private void Awake()
    {
        m_BooleanAction = SteamVR_Actions.default_GrabPinch;
    }

    private void Start()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    void Update()
    {
        if (m_BooleanAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            SpawnBullet(boolet, player);
        }
        //for debug stuff
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet(boolet, player);
        }
    }

    public void SpawnBullet(GameObject boolet, GameObject player)
    {
        freshBullet = Instantiate(boolet, player.transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
        player.GetComponent<Rigidbody>().velocity = new Vector3 (0, 1, 0);
        freshBullet.GetComponent<Rigidbody>().velocity = new Vector3 (0, -25, 0);
    }
}
