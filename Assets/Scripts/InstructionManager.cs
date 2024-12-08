using UnityEngine;
using UnityEngine.UI;

public class InstructionsManager : MonoBehaviour
{
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] KeyCode startKey = KeyCode.Return;

    void Start()
    {
        instructionsPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(startKey))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        instructionsPanel.SetActive(false);

        Time.timeScale = 1f;
    }
}
