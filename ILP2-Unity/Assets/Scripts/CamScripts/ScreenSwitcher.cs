using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    public GameObject playerTracker;
    public int screenNum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerTracker.SendMessage("switchScreen", screenNum);     
    }
}
