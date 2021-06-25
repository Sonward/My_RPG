using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsAI : MonoBehaviour
{
    private GameObject player;
    private bool fightMode = false;
    enum FightStates { dontFight, fight }
    FightStates previousState;
    FightStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState =  FightStates.dontFight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 20, 1 << 6) != null)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, 20, 1 << 6);
            player = playerCollider.gameObject;
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
            fightMode = true;
        }
        else 
        {
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            fightMode = false; 
        }
    }
}
