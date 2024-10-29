using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{

    [SerializeField] private GameObject levelCompleteUI; //ui for level completion message
    [SerializeField] private float delayBeforeNextLevel = 2f; //delay before next level loads

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowLevelCompleteUI();
            Invoke("LoadNextLevel", delayBeforeNextLevel);
        }
    }

    private void ShowLevelCompleteUI()
    {
        if (levelCompleteUI != null)
        {
            levelCompleteUI.SetActive(true);
        }
    }

    private void LoadNextLevel()
    {
        //load the next scene here
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
