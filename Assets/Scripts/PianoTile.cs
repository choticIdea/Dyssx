using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PianoTile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tilePressedSprite;
    public GameObject tileNotPressedSprite;
    public int tileId;
    private float time = 1f;
    private float _time = 0;
    private bool isPressed = false;
    public int note = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            _time += Time.deltaTime;
            if(_time >= time)
            {
                isPressed = false;
                TileUnPressed();
                _time = 0;
            }
        }
    }
    public void TurnOnAndOff()
    {
       isPressed = true;
        tilePressedSprite.SetActive(true);
        tileNotPressedSprite.SetActive(false);
        SoundManager.singleton.PlayPianoTone(note - 1);
    }
   
    public void TileUnPressed()
    {
        tilePressedSprite.SetActive(false);
        tileNotPressedSprite.SetActive(true);
    }
    public void AnswerSwitch()
    {
        //stupid monolithic architecture, very unclean
        TileManager.instance.WriteAnswer(tileId);
        TurnOnAndOff();
    }
}
