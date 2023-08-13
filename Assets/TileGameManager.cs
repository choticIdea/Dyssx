using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGameManager : MonoBehaviour
{
    public static TileGameManager instance;
    public GameObject[] variationHolder;
    public int curVariation = 0;
    public float nextLevelTimer = 0.2f;
    float _timer = 0f;
    public bool nextLevelFlag = false;
    // Start is called before the first frame update
     void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (nextLevelFlag)
        {
            //continuing from Switch Variation since coroutine is uncool and I am too stupid to refactor into threads
            _timer += Time.deltaTime;
            if(_timer > nextLevelTimer)
            {
                variationHolder[curVariation].SetActive(true);
                _timer = 0f;
                nextLevelFlag = false;
            }
        }
    }
    public void SwitchVariation()
    {
        if(curVariation < variationHolder.Length)
        {
            curVariation++;
        }
        foreach(GameObject g in variationHolder)
        {
            g.SetActive(false);
        }
        nextLevelFlag=true;
       
    }
}
