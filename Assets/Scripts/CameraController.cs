using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public AudioSource piano1;
    public AudioSource piano2;
    public AudioSource palos;
    public AudioSource corazon;
    public AudioSource piano3;

    public int sanity = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setMusic(piano2, 4);
        setMusic(palos, 3);
        setMusic(corazon, 2);
        setMusic(piano3, 1);
    }

    void setMusic(AudioSource instrument, int value)
    {
        if(sanity <= value && instrument.volume < 1)
        {
            instrument.volume += 0.5f;
        }
    }
}
