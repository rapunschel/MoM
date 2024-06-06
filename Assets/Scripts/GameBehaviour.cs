using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using FischlWorks_FogWar;
public class GameBehaviour : CITEPlayer
{
    public GameObject serverBasedTestObject;
    public GameObject clientPlayerObject;
    private GameObject clientPlayer;

    // Start is called before the first frame update
    public override void OnStartLocalPlayer()
    {
        Debug.Log("Local GameBehaviour started as player " + playerID);

        // Find camera helpers and let them know who we are
        foreach (CameraPositioner helper in FindObjectsOfType<CameraPositioner>())
        {
            helper.setView(playerID);
        }

        if (isOwned)
        {
            CmdCreateClientControlledPlayerObject(GameObject.FindWithTag("player" + playerID).GetComponent<Transform>().position);
        }
    }


    /**
        A client can request that the server spawns an object that the client can control directly
    */
    [Command]
    public void CmdCreateClientControlledPlayerObject(Vector3 initialPosition)
    {
        Debug.Log("Creating a player object for " + connectionToClient + " to control");

        clientPlayer = Instantiate(clientPlayerObject, initialPosition, Quaternion.identity);
        clientPlayer.GetComponent<ClientPlayer>().clientID = playerID; //FindObjectOfType<CITENetworkManager>().GetPlayerID(connectionToClient);
        // Tell everyone about it and hand it over to the client who asked for it
        NetworkServer.Spawn(clientPlayer, connectionToClient);
    }

    public void Update()
    {
        if (isOwned)
        {
            if (Input.GetKeyUp("m"))
            {
            }
        }
    }
}
