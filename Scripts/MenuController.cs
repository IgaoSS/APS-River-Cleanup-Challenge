using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MenuController : MonoBehaviourPunCallbacks
{
    [SerializeField] private EnterMenu enterMenu;
    [SerializeField] private LobbyMenu lobbyMenu;

    private void Start()
    {
        enterMenu.gameObject.SetActive(false);
        lobbyMenu.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        enterMenu.gameObject.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        ChangeMenu(lobbyMenu.gameObject);
        lobbyMenu.photonView.RPC("UpdateList", RpcTarget.All);
    }

    public void ChangeMenu(GameObject menu)
    {
        enterMenu.gameObject.SetActive(false);
        lobbyMenu.gameObject.SetActive(false);

        menu.SetActive(true);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        lobbyMenu.UpdateList();
    }

    public void LeaveLobby()
    {
        NetworkController.Instance.LeaveLobby();
        ChangeMenu(enterMenu.gameObject);
    }

    public void StartGame(string sceneName)
    {
        NetworkController.Instance.photonView.RPC("StartGame", RpcTarget.All, sceneName);
    }
}
