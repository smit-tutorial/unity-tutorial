using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeButtonCtrl : MonoBehaviour
{
    public float waitingTime = 3.0f;
    public int sceneNumber;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            StartCoroutine(DelayedChangeScene(waitingTime, sceneNumber));
        });
    }

    IEnumerator DelayedChangeScene(float time, int number)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(number);
    }
}
