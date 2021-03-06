using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] Rotator rotator;
    [SerializeField] PinSpawner pinSpawner;
    [SerializeField] CameraAnimator animator;
    [SerializeField] int numberOfPins;
    private int currentNumberOfPins = 0;

    public int GetTotalNumberOfPins() { return numberOfPins; }

    public int GetcurrentNumberOfPins() { return currentNumberOfPins; }

    public void AddPin()
    {
        currentNumberOfPins++;
    }

    public void GameOver()
    {
        DisableGameElements();
        animator.SetGameOverTrigger();
    }

    public void LevelComplete(int sceneIndex)
    {
        DisableGameElements();
        int nextLevelIndex = PlayerPrefs.GetInt(Level.NEXT_LEVEL_KEY, Level.LEVEL_TO_START);
        if (sceneIndex >= nextLevelIndex)
        {
            PlayerPrefs.SetInt(Level.NEXT_LEVEL_KEY, sceneIndex + 1);
        }

        animator.SetLevelCompleteTrigger();
    }
    private void DisableGameElements()
    {
        rotator.enabled = false;
        pinSpawner.enabled = false;
    }
}
