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
    private csFogWar.FogRevealer fogRevealer;

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
            // Retrieve the script 
            csFogWar script = GameObject.FindWithTag("FogOfWar").GetComponent<csFogWar>();

            // Create a fogrevealer
            fogRevealer = new csFogWar.FogRevealer(clientPlayer.GetComponent<Transform>(), 1, true);

            // Use script to add fogRevealer
            script.AddFogRevealer(fogRevealer);
        }
    }

    /**
        A client can ask the server to spawn a test object that is controlled entirely by the
        server and has the state of it broadcast to all of the clients
    */
    [Command]
    public void CmdCreateServerControlledTestObject()
    {
        Debug.Log("Creating a test object");

        GameObject testThing = Instantiate(serverBasedTestObject, new Vector3(clientPlayer.transform.position.x, clientPlayer.transform.position.y, clientPlayer.transform.position.z), Quaternion.identity);
        testThing.GetComponent<Rigidbody>().isKinematic = false; // We simulate everything on the server so only be kinematic on the clients
        testThing.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 5);

        // Tell everyone about this new shiny object
        NetworkServer.Spawn(testThing);
    }


    /**
        A client can request that the server spawns an object that the client can control directly
    */
    [Command]
    public void CmdCreateClientControlledPlayerObject(Vector3 initialPosition)
    {
        Debug.Log("Creating a player object for " + connectionToClient + " to control");
        GameObject clientP = Instantiate(clientPlayerObject, initialPosition, Quaternion.identity);

        // Tell everyone about it and hand it over to the client who asked for it
        NetworkServer.Spawn(clientP, connectionToClient);

        clientPlayer = clientP;
    }

    public void Update()
    {
        if (isOwned)
        {
            if (Input.GetKeyUp("space"))
            {
                CmdCreateServerControlledTestObject();
            }
            else if (Input.GetKeyUp("m"))
            {
            }
        }
    }
}
