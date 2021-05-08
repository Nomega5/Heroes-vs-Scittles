using System.Collections.Generic;
using UnityEngine;

public class MusicBehavior : MonoBehaviour
{
//    public int nMusic;
    public List<GameObject> playlist;
    void Start()
    {
//        nMusic = 0;
        MusicChoice(0);
    }


    public void MusicChoice(int nMusic)
    {
        int i = 0;
        foreach(GameObject music in playlist)
        {
            playlist[i].SetActive(false);
            i += 1;
        }
        playlist[nMusic].SetActive(true);
    }
}
