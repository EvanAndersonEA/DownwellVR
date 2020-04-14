using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Game : MonoBehaviour
{
    [SerializeField] private GameObject start_Menu;
    [SerializeField] private AudioSource mainSong;
    [SerializeField] private GameObject start_Platform;

    public Start_Game()
    {
        start_Menu.SetActive(false);
        start_Platform.SetActive(false);
        //mainSong 
    }
}
