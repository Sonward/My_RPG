using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour
{
    public GameObject Player;
    SpriteRenderer PistolSprite;
    Vector3 MousePosition;

    // Start is called before the first frame update
    void Start()
    {
        MousePosition = Player.GetComponent<HeroMove>().MousePosition3D;
        PistolSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition = Player.GetComponent<HeroMove>().MousePosition3D;

        if (MousePosition.x < Player.transform.position.x)
        {
            PistolSprite.flipY = true;
        }
        else
        {
            PistolSprite.flipY = false;
        }
    }
}
