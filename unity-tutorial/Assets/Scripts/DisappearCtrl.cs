using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCtrl : MonoBehaviour
{
    public float waitingTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear(waitingTime));
    }

    // Update is called once per frame
    IEnumerator Disappear(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
