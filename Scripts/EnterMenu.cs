using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class EnterMenu : MonoBehaviour
{
    [SerializeField] private Text playerNameMenu;
    [SerializeField] private Text roomNameMenu;

    public void CreateRoom()
    {
        NetworkController.Instance.SetNickname(playerNameMenu.text);
        NetworkController.Instance.CreateRoom(roomNameMenu.text);
    }

    public void EnterRoom()
    {
        NetworkController.Instance.SetNickname(playerNameMenu.text);
        NetworkController.Instance.EnterRoom(roomNameMenu.text);
    }
}
