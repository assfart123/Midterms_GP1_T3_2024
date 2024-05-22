using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject inGameUI;

    public void ToggleUIPanels()
    {
        // Toggle the visibility of the main menu and in-game UI panels
        mainMenuUI.SetActive(!mainMenuUI.activeSelf);
        inGameUI.SetActive(!inGameUI.activeSelf);
    }
}
