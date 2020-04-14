using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Start_Game : MonoBehaviour
{
    [SerializeField] private SteamVR_ActionSet m_ActionSet = null;
    [SerializeField] private SteamVR_Action_Boolean m_BooleanAction = null;
    [SerializeField] private GameObject start_Menu = null;
    [SerializeField] private AudioSource mainSong = null;
    [SerializeField] private GameObject start_Platform = null;
    private bool hasTheGameStarted = false;

    private void Awake()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    private void Update()
    {
        if (!hasTheGameStarted)
        {
            if (m_BooleanAction.GetStateDown(SteamVR_Input_Sources.Any))
            {
                StartGame();
                hasTheGameStarted = false;

            }
        }
    }

    private void StartGame()
    {
        start_Menu.SetActive(false);
        start_Platform.SetActive(false);
        mainSong.Play();
    }
}
