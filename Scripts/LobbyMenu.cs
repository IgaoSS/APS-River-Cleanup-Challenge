using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text listPlayers;
    [SerializeField] private Button startGame;

    [PunRPC]
    public void UpdateList()
    {
        listPlayers.text = NetworkController.Instance.GetListPlayers();
        startGame.interactable = NetworkController.Instance.OwnerRoom();
    }
}