using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchParentCTR : MonoBehaviour
{

    public void Pushed()
    {
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag("Switch"))
        {
            obs.SendMessage("Trigger");
        }
    }
}
