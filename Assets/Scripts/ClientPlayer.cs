using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class ClientPlayer : NetworkBehaviour
{
    [SyncVar(hook = "OnColourChanged")] public Color theColour; // all objects have a colour set by their owner
    private static Color ourColour;
    private static bool firstTime = true;
    private Vector3 moveTarget;
    private bool moveTargetChanged = false;

    public GameObject joystick;
    private float runSpeed = 0.1f;

    private Vector3 joyMove;
    private float dirX;
    private float dirZ;

    public override void OnStartClient()
    {
        // Tell our object to be our own colour when it spawns so we can recognize it
        if (hasAuthority)
        {
            // The very first time we create a random colour to keep using when spawning new objects
            if (firstTime)
            {
                ourColour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                firstTime = false;
                // Create the joystick and place it in the canvas
                joystick = Instantiate(joystick, new Vector3(256, 256, 0), Quaternion.identity,
                GameObject.FindGameObjectWithTag("joystickCanvas").transform);
                // Place player at fixed coordinates in beginning
                UpdatePosition(new Vector3(723, 233, 0));
            }

            // Tell everyone about it through the SyncVar that we have authority over
            // This triggers OnColourChanged for everyone
            CmdPleaseChangeMyColour(ourColour);
        }
    }

    /**
     * Ask the server to change the colour of the object
     */
    [Command]
    public void CmdPleaseChangeMyColour(Color newColour)
    {
        theColour = newColour;
    }

    /**
     * Called when someone changes colour on an object they own
     */
    public void OnColourChanged(Color oldColor, Color newColour)
    {
        Material ourMaterial = new Material(Shader.Find("Standard"));
        ourMaterial.color = newColour;
        GetComponent<Renderer>().material = ourMaterial;
    }


    // Update is called once per frame
    void Update()
    {
        if (hasAuthority)
        {

            dirX = joystick.GetComponent<FixedJoystick>().Horizontal;
            dirZ = joystick.GetComponent<FixedJoystick>().Vertical;
            if (dirX != 0 || dirZ != 0)
            {
                joyMove = this.GetComponent<Rigidbody>().position;
                joyMove.x = this.GetComponent<Rigidbody>().position.x + dirX * runSpeed;
                joyMove.z = this.GetComponent<Rigidbody>().position.z + dirZ * runSpeed;
                CmdSetMoveTarget(joyMove);
                this.GetComponent<Rigidbody>().MovePosition(joyMove);
            }
        }
    }

    private void UpdatePosition(Vector3 inputPosition)
    {
        Camera cam = Camera.main;
        inputPosition.z = cam.transform.position.y;
        Vector3 moveTarget = cam.ScreenToWorldPoint(inputPosition);
        CmdSetMoveTarget(moveTarget);

        this.GetComponent<Rigidbody>().MovePosition(moveTarget);
    }

    [Command]
    private void CmdSetMoveTarget(Vector3 target)
    {
        moveTarget = target;
        moveTargetChanged = true;
    }

    private void FixedUpdate()
    {
        if (isServer)
        {
            if (moveTargetChanged)
            {
                moveTargetChanged = false;
                this.GetComponent<Rigidbody>().MovePosition(moveTarget);
            }
        }
    }
}
