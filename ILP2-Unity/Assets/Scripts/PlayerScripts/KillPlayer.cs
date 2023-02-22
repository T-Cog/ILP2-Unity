using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject restart;

    // Kills the player when it recieves the kill message from another object
    // Disables the player and enables the restart button and game over text
    void PlayerDead(bool kill)
    {
        if(kill == true)
        {
            gameOver.SetActive(true);
            restart.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("Player Dead");
        }
    }
}
