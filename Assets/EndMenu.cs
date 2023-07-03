using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
      //  Application.Quit();
    }
}
