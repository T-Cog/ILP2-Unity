using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public List<GameObject> screens;

    void switchScreen(int whichScreen)
    {
        transform.position = screens[whichScreen - 1].transform.position;
    }
}
