using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelWelcome : MonoBehaviour
{
    [SerializeField] private GameObject welcomeCanvas;
    [SerializeField] private float displayDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideCanvasAfterDelay());
    }

    private IEnumerator HideCanvasAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        welcomeCanvas.SetActive(false);
    }
}
