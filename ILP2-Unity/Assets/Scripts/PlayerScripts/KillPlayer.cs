using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Kills the player when it recieves the kill message from another object
    void PlayerDead(bool kill)
    {
        if(kill == true)
        {           
            Debug.Log("Player Dead");
        }
    }
}
