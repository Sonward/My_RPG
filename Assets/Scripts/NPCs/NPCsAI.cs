using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsAI : MonoBehaviour
{
    private Transform player;
    private bool fightMode;
    enum FightStates { dontFight, fight }
    FightStates previousState;
    FightStates currentState;

    public bool FightMode { get => fightMode; }

    public Transform Player { get => player; }

    // Start is called before the first frame update
    void Start()
    {
        currentState =  FightStates.dontFight;
        fightMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 20, 1 << 6) != null)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, 20, 1 << 6);
            player = playerCollider.transform;
        }
        else
        {
            player = null;
        }

        if (player != null) { previousState = currentState; currentState = FightStates.fight; }
        else { previousState = currentState; currentState = FightStates.dontFight; }

        if (previousState != currentState) { ChangeFightMode(); }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(player);
        }
    }

    private void ChangeFightMode()
    {
        if (currentState == FightStates.fight)
        {
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<NPCsFightScript>().enabled = true;
            fightMode = true;
        }
        else 
        {
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<NPCsFightScript>().enabled = false;
            fightMode = false; 
        }
    }

    public void GetDialog()
    {
        Debug.Log(GetComponent<NPCsDialogsScript>().Talk());
    }
}
