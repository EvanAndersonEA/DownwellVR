using UnityEngine;
using Valve.VR;

public class Center_Position : MonoBehaviour
{
    [SerializeField] private SteamVR_ActionSet m_ActionSet = null;
    [SerializeField] private SteamVR_Action_Boolean m_BooleanAction = null;
    [SerializeField] private GameObject playerRig = null;
    [SerializeField] private GameObject player = null;

    private void Awake()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    private void Update()
    {
        if (m_BooleanAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            float offset_x = player.transform.position.x * -1;
            float offset_z = player.transform.position.z * -1;

            playerRig.transform.position = new Vector3(
                playerRig.transform.position.x + offset_x,
                playerRig.transform.position.y,
                playerRig.transform.position.z + offset_z);

        }
    }
}
