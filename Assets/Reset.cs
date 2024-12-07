
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField] private KeyCode resetKey = KeyCode.R;
    [SerializeField] private float holdDuration = 2f; // Time in seconds to hold key
    private float resetTimer = 0f;

    void Update()
    {
        if (Input.GetKey(resetKey))
        {
            resetTimer += Time.deltaTime;

            if (resetTimer >= holdDuration)
            {
                RestartScene();
            }
        }
        else
        {
            resetTimer = 0f; // Reset the timer if key is released
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
