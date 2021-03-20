using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_nextSceneName);

        while (!asyncOperation.isDone)
        {
            _slider.value = asyncOperation.progress;

            yield return null;
        }
    }
}
