using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoCtrl : MonoBehaviour
{
    private VideoPlayer vp;
    private RawImage rawImage;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        rawImage = GetComponent<RawImage>();
    }

    public void VideoPlay()
    {
        vp.Play();
    }

    public void VideoStop()
    {
        vp.Pause();
    }

    public void VideoReplay()
    {
        vp.Stop();
        vp.Play();
    }
}
