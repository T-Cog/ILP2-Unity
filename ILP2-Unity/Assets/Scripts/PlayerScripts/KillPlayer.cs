using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    void PlayerDead(bool kill)
    {
        if(kill == true)
        {           
            Debug.Log("Player Dead");
        }
    }
}
