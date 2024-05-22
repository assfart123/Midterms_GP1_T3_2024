using UnityEngine;
using UnityEngine.UI;

public class CloseGame : MonoBehaviour
{
    void Start()
    {
        // Assuming the button is attached to the OnClick event in the Unity Editor,
        // you don't need to add any code here.
    }

    // Method to be called when the button is clicked
    public void QuitGame()
    {
        // Close the game
        Application.Quit();
    }
}
