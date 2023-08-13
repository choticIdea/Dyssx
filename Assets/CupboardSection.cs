using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardSection : MonoBehaviour
{
    public int acceptedObjectID;
    public GameObject snappedPositions;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Book>() != null)
        {
            Book book = collision.gameObject.GetComponent<Book>();
            bool found = false;
            if (acceptedObjectID == book.bookId)
            {
                //
                found = true;
                collision.gameObject.transform.position = snappedPositions.transform.position;
                collision.gameObject.GetComponent<DraggableObject>().enabled = false;
                //level checking
                transform.parent.GetComponent<DrawerGamemanager>().CheckBookPlaced(book.bookId);
                //  if(currentSnap < snappedPositions.Length)
                //    currentSnap++;
                
                //this line of code deal with UI sophistry, it will snap object basically. But it is not good enough, the object cant be dragged again afterwards
                //TODO : design an algorithm (not a complex one) that deal with this UI beast
            }
            
            if (found)
                Debug.Log("Correct");
            else
                Debug.Log("Wrong");
                //mgkin dibalikkan ke tempatnya si buku ini
        }else if (collision.gameObject.tag == "Wrong")
        {
            Debug.Log("Wrong");
        }
    }
}
