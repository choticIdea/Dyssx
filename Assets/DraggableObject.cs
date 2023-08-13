using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableObject : MonoBehaviour, IDragHandler
{
    public Image thisImage;
    public Vector3 startPosition;
    public Vector3 designatedPosition;
    public bool proper = false;
  
    void Start()
    {
        thisImage = GetComponent<Image>();
        startPosition = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        thisImage.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Snap();
        thisImage.raycastTarget = true;
    }
    void Snap()
    {
        if(proper)
            transform.position = designatedPosition;
        else
        {
            transform.position = startPosition;
        }
    }
   //bagaimana caranya agar si draggable objek ini snap ke posisi awal? atau ke designated position
   //1. set posisi start di void Start
   //2. begitu on enddrag panggil snap function. Jika variabel properLoc=true, maka taruh di designated pos, else dont



    
}