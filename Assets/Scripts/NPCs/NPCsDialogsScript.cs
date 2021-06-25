using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsDialogsScript : MonoBehaviour
{
    [SerializeField] private string[] talkingText = new string[] { "Hello", "GET OUT FROM HERE!!!" } ;

    public string Talk()
    {
        if (GetComponent<NPCsAI>().FightMode)
        {
            Debug.Log("Figth mode is active; FightMode = " + GetComponent<NPCsAI>().FightMode);
            return talkingText[1];
        }
        else
        {
            Debug.Log("Figth mode isn't active; FightMode = " + GetComponent<NPCsAI>().FightMode);
            return talkingText[0];
        }
    }
}
