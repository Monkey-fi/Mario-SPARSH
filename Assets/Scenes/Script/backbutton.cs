using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backbutton : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void OnBackButton()
    {
        // Check if there is a previous scene to go back to
        if (SceneManager.sceneCountInBuildSettings > 1)
        {
            // Load the previous scene, ensuring it exists
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int previousSceneIndex = Mathf.Clamp(currentSceneIndex - 1, 0, SceneManager.sceneCountInBuildSettings - 1);

            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("Not enough scenes in build settings.");
        }
    }
}