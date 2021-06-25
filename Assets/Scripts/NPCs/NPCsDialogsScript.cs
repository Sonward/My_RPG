using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsDialogsScript : MonoBehaviour
{
    [SerializeField] private string talkingText = "Hello";

    public string Talk()
    {
        return talkingText;
    }
}
