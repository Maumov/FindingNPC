using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : InteractionTarget
{
    public override void Interact() {
        Debug.Log("Interaccion con NPC: " + name);
    }
}
