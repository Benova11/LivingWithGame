using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextLevel);
    }
}
