using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct FruitTarget
{
    public string fruitName;
    public int amount;
    public int prefabIdx;
    
}
[System.Serializable]
public class SerializableFruitTargetClass
{
    public List<FruitTarget> fruitTargets;
}
public class CatchTheFruit : MonoBehaviour
{

    //This the part where player data is gathered, namely level completed and level progression. For fruit cathing only
    // Start is called before the first frame update
    public static CatchTheFruit instance;
    public int levelIndex = 0;
    
    public List<SerializableFruitTargetClass> levelTargets;//used to track how many fruit left 
    public GameObject[] levelTemplateHolder;
    public GameObject[] fruitIconPrefabs;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        SpawnFruitTargetUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnFruitTargetUI()
    {
        
        //the algo for determining which template level used goes here, if still none assume template 1
        int templateIndex = 0;
        ///algo for determining which fruit prefab to be spawned in the UI goes here, otherwise assume fruit 1 and 2
        TargetVisualUpdater tvu = levelTemplateHolder[templateIndex].GetComponent<TargetVisualUpdater>();
       
        List<FruitTarget> cLevelTarget = levelTargets[levelIndex].fruitTargets;
        for(int i = 0; i < cLevelTarget.Count; i++)
        {
            List<GameObject> spawnedTargetUI = new List<GameObject>();
            for (int x = 0; x < cLevelTarget[i].amount; x++)
            {
                GameObject g = tvu.targets[i].targets[x];
                GameObject ins = Instantiate(fruitIconPrefabs[cLevelTarget[i].prefabIdx], g.transform.position, g.transform.rotation);
                ins.transform.SetParent(g.transform.parent);
                ins.GetComponent<RectTransform>().localScale = Vector3.one;
                spawnedTargetUI.Add(ins);
            }
            tvu.spawnedTargets[i].spawnedTargets = spawnedTargetUI;
            
        }
       /* for (int i=0;i< cLevelTarget[0].amount;i++)
        {
           
        }
        List<GameObject> spawnedTargetUI2 = new List<GameObject>();
        for (int i= 0; i < cLevelTarget[1].amount; i++)
        {
            GameObject g = tvu.target2[i];
            GameObject ins = Instantiate(fruitIconPrefabs[1], g.transform.position, g.transform.rotation);
            ins.transform.SetParent(g.transform.parent);
            ins.GetComponent<RectTransform>().localScale = Vector3.one;
            spawnedTargetUI2.Add(ins);
        }
        
        
        */

    }
    void UpdateFruitTargetUI()
    {
        int templateIndex = 0;
        TargetVisualUpdater tvu = levelTemplateHolder[templateIndex].GetComponent<TargetVisualUpdater>();
        List<FruitTarget> cLevelTarget = levelTargets[levelIndex].fruitTargets;
        //hacky tbh, should use broadcast or smth
        //should really use broadcast though;
        for(int i = 0; i < cLevelTarget.Count; i++)
        {
            if(cLevelTarget[i].amount < tvu.spawnedTargets[i].spawnedTargets.Count)
            {
                int lastidx = tvu.spawnedTargets[i].spawnedTargets.Count - 1;
                GameObject g = tvu.spawnedTargets[i].spawnedTargets[lastidx];
                Destroy(g);
                tvu.spawnedTargets[i].spawnedTargets.RemoveAt(lastidx);
            }
        }
    }
    public void UpdateLevelTarget(string fruitName)
    {
        List<FruitTarget> cLevelTarget = levelTargets[levelIndex].fruitTargets;
        
        for(int i=0;i< cLevelTarget.Count;i++)
        {
            if (cLevelTarget[i].fruitName == fruitName)
            {
                if(cLevelTarget[i].amount > 0)
                {
                    FruitTarget t = new FruitTarget();
                    t.amount = cLevelTarget[i].amount - 1;
                    t.fruitName = cLevelTarget[i].fruitName;
                    cLevelTarget[i] = t;
                    UpdateFruitTargetUI();
                }
                
            }
        }
        CheckTarget();
    }
    public void CheckTarget()
    {
        List<FruitTarget> cLevelTarget = levelTargets[levelIndex].fruitTargets;
        bool zeroTarget = true;
        for (int i = 0; i < levelTargets.Count; i++)
        {
                if (cLevelTarget[i].amount > 0)
                {
                    zeroTarget = false;
                }
        }
        if(zeroTarget == true)
        {
            NextLevelHandler();

        }
    }
    //Next Level Handler
    void NextLevelHandler()
    {
        Debug.Log("called");

        if (levelIndex >= levelTargets.Count)
        {
            //endgame
        }else
        {
            levelIndex++;
            SpawnFruitTargetUI();
        }
    }
    
}
