using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for level config
public struct levelConfig
{
    int variationIndex;
    int actualLevelIndex;

}
public struct levelLayout
{
    public GameObject[] drawerPos;
    public bool isVerticalLayout;//false=horizontal, true=vertical
    public int[] drawerAnchorIndex;
    public int[] bookNumbers;
}
public class DrawerGameLevels : MonoBehaviour
{
   
    //public GameObject[] levelTemplates;
    public levelConfig[] levelTemplates;
    public int levelIndex = 0;
    public levelLayout[] verticalLayouts;
    public levelLayout[] horizontalLayouts;
    public GameObject[] levels;
    public GameObject[] horizontalDrawerAnchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SwitchLevel()
    {
        if(levelIndex < levels.Length)
        {
            levelIndex++;
            HideLevel(levelIndex);
        } else
        {
            //congratulatory??
        }
        //make a function to reset

    }
    void HideLevel(int idx)
    {
       for(int i = 0; i < levels.Length; i++)
        {
            
                levels[i].SetActive(false);
            
        }
        for (int i = 0; i < levels.Length; i++)
        {
            if (i == idx)
            {
                levels[i].SetActive(true);
            }
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
