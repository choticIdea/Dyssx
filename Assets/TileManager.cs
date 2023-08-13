using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PianoTileStates{
    CountingDown,
    AnswerDemo,
    AnswerSession,

}
[System.Serializable]
public class LampSequence{
    
    public List<int> lampSequencesIndex;
}
public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lamps;
    public List<LampSequence> sequence;
    public GameObject demoSign;
    public List<LampSequence> answerSequence;
    public float lampSwitchTimer;
    private float _lampTimer = 0;
    public int lampAnimIndex = 0;
    public int levelIndex = 0;
    public static TileManager instance;
    public PianoTileStates state;
    //used in  conjunction with  demo state
    public float levelTimer = 0.2f;
    private float _levelTimer = 0f;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        state = PianoTileStates.CountingDown;
        demoSign.SetActive(false);
        _levelTimer = 0f;
    }
    void Start()
    {
        _lampTimer = 0;
        SwitchLampManualAnimation();
        InitAnswerSequence();
        demoSign.SetActive(false);

    }
    void InitAnswerSequence()
    {
        answerSequence = new List<LampSequence>();
        for(int i = 0; i < sequence.Count; i++)
        {
            LampSequence l = new LampSequence();
            l.lampSequencesIndex = new List<int>();
            answerSequence.Add(l);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(state == PianoTileStates.CountingDown)
        {
           if(_levelTimer < levelTimer)
            {
                _levelTimer += Time.deltaTime;
                if(_levelTimer > levelTimer)
                {
                    _levelTimer = 0;
                    state = PianoTileStates.AnswerDemo;
                    demoSign.SetActive(true);
                }
            }
        }else if(state == PianoTileStates.AnswerDemo)
        {
            _lampTimer += Time.deltaTime;
            if (_lampTimer > lampSwitchTimer)//should add answer state
            {
                SwitchLampManualAnimation();
                _lampTimer = 0;
            }
        }else if(state == PianoTileStates.AnswerSession)
        {
         /*   _lampTimer += Time.deltaTime;
            if (_lampTimer > lampSwitchTimer)//should add answer state
            {
                SwitchLampManualAnimation();
                _lampTimer = 0;
            }*/
            if (answerSequence[levelIndex].lampSequencesIndex.Count >= sequence[levelIndex].lampSequencesIndex.Count)
            {
                VerifyAnswer();
            }
        }
       

    }
    void VerifyAnswer()
    {
        if(answerSequence[levelIndex].lampSequencesIndex.Count > sequence[levelIndex].lampSequencesIndex.Count)
        {
            Debug.Log("False");
            ////Kurang tepat
            answerSequence[levelIndex].lampSequencesIndex = new List<int>();
        }
        else
        {
            bool same = true;
            for (int i =0;i<answerSequence[levelIndex].lampSequencesIndex.Count;i++)
            {
                if(answerSequence[levelIndex].lampSequencesIndex[i] != sequence[levelIndex].lampSequencesIndex[i])
                {
                    same = false;
                    break;
                }
            }
            if (same)
            {
                Debug.Log("Correct");
                //Output kamu pintar !
                if(levelIndex < sequence.Count-1)
                {
                    levelIndex += 1;
                    lampAnimIndex = 0;
                    //Reset the states to counting down, so that it wont jump into answer demo instantly
                    _levelTimer = 0f;
                    state = PianoTileStates.CountingDown;
                    foreach (GameObject lamp in lamps)
                    {
                        lamp.GetComponent<Button>().enabled = false;
                    }

                }
                else
                {
                    //reset the game and prompt next variation
                    state = PianoTileStates.CountingDown;
                    levelIndex = 0;
                    lampAnimIndex = 0;
                    instance = null;//very dirty, there will be a potential bug where if the game is restarted, this variable wont be filled
                    TileGameManager.instance.SwitchVariation();
                    
                }
                    
                //else 
                //  next variation   

            }else
            {
                Debug.Log("False");
                //Kurang tepat
                answerSequence[levelIndex].lampSequencesIndex = new List<int>();
            }
        }
    }
    public void ResetTileGameVariationState()
    {
        //this is a function to plug into a button script, so that we could make next level/variation or button;
        state = PianoTileStates.CountingDown;
        demoSign.SetActive(false);
        foreach (GameObject lamp in lamps)
        {
            lamp.GetComponent<Button>().enabled = false;
        }
    }
    void SwitchLampManualAnimation()
    {
        //lets move this to the lamp script
      //  foreach (GameObject l in lamps)
       // {
        //    l.GetComponent<PianoTile>().TileUnPressed();
       // }
        //very dirty
        
       
        if (state == PianoTileStates.AnswerDemo)
        {
            if (lampAnimIndex < sequence[levelIndex].lampSequencesIndex.Count)
            {
                lamps[sequence[levelIndex].lampSequencesIndex[lampAnimIndex]].GetComponent<PianoTile>().TurnOnAndOff();
                lampAnimIndex++;
                
            }
            else
            {
                state = PianoTileStates.AnswerSession;
                foreach (GameObject lamp in lamps)
                {
                    lamp.GetComponent<Button>().enabled = true;
                    demoSign.SetActive(false);
                }

            }
        }


    }
    public void WriteAnswer(int lampId)
    {
        //tightly coupled
        if(state == PianoTileStates.AnswerSession)
            answerSequence[levelIndex].lampSequencesIndex.Add(lampId);
    }

}
