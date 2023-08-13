using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetWrapper
{
    public List<GameObject> targets = new List<GameObject>();
}
[System.Serializable]
public class SpawnedTargetWrapper
{
    public List<GameObject> spawnedTargets = new List<GameObject>();
}


public class TargetVisualUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    
    public List<TargetWrapper> targets;

    public List<SpawnedTargetWrapper> spawnedTargets;
    //public List<GameObject> target2;
    //public List<GameObject> spawnedTargets2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
