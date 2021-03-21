using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void LoadSceneByIndex(int index)
    {
        StartCoroutine(LoadingSceneByIndex(index));
    }
    
    IEnumerator LoadingSceneByIndex(int index)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        _slider.gameObject.SetActive(true);
        
        while (!asyncOperation.isDone)
        {
            _slider.value = asyncOperation.progress;

            yield return null;
        }
    }
}
