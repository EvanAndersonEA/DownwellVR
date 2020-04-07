using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShootJump : MonoBehaviour
{
    public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_BooleanAction;

    [SerializeField]
    public GameObject boolet = null;

    [SerializeField]
    public GameObject vrCamera = null;

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
            SpawnBullet(boolet, vrCamera);
        }
        //for debug stuff
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet(boolet, vrCamera);
        }

        GetComponent<CapsuleCollider>().center = new Vector3(vrCamera.transform.position.x, 1, vrCamera.transform.position.z);
    }

    public void SpawnBullet(GameObject boolet, GameObject player)
    {
        freshBullet = Instantiate(boolet, player.transform.position - new Vector3(0, 1f, 0), Quaternion.identity);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0, 5, 0);
        freshBullet.GetComponent<Rigidbody>().velocity = new Vector3 (0, -25, 0);
    }
}
