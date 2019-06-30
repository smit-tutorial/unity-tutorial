using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Do not destroy the target Object when loading a new Scene
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
