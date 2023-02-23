using UnityEngine;
//Enabled SceneManagement for this script
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //User defined function that calls the SceneManager to load the scene titled "Game"
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
