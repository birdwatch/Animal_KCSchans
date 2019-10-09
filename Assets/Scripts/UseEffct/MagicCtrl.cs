using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCtrl : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;

    private bool isPlayed = false;
    private int time = 0;

    // Update is called once per frame
    void Update()
    {
        if (isPlayed) PlayAnime();
        time += 1;
    }

    public void Play()
    {
        if (!isPlayed)
        {
            isPlayed = true;
            sr.enabled = true;
        }
    }

    public void Quit()
    {
        isPlayed = false;
        sr.enabled = false;
        time = 0;
    }

    private void PlayAnime()
    {
        if(time <= 50)
        {
            transform.localScale = new Vector3(0.02f * time, 0.02f * time, 1f);
        }

        transform.Rotate(0f, 0f, 1.5f);
    }
}
