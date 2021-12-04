using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sistem_darah : MonoBehaviour
{
    public float darah_player;
    public string info;

    // Start is called before the first frame update
    void Start()
    {
        darah_player = 100f;    
    }

    // Update is called once per frame
    void Update()
    {
        if (darah_player > 0)
        {
            Debug.Log("Player Hidup");
        }
        else
        {
            Debug.Log("Player Mati");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            darah_player -= 20f;
            Debug.Log("Darah = " + darah_player);
            info = "You stepped on Poisoned Mushroom";

        }

        if (other.tag == "Enemy")
        {
            darah_player -= 40f;
            Debug.Log("Darah = " + darah_player);
            info = "You were killed by Giant Troll";

        }

        if (other.tag == "Flame")
        {
            darah_player -= 30f;
            Debug.Log("Darah = " + darah_player);
            info = "You burn yourself to the death";

        }
    }
}
