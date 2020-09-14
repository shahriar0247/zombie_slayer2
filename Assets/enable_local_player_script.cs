using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enable_local_player_script : NetworkBehaviour
{
    public Behaviour[] components_to_enable;

    void Start()
    {
        if (isLocalPlayer)
        {
            for (int i = 0; i < components_to_enable.Length; i++)
            {
                components_to_enable[i].enabled = true;
            }
        }
    }

}
