using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerGamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] books;//redundant i know
    public int[] cupboardIds;
    public List<int> bookIds;
    public GameObject text;
    void Start()
    {
        InitLevel();   
    }
    public void InitLevel()
    {
        bookIds = new List<int>();
        for(int i = 0; i < books.Length; i++)
        {
            bookIds.Add(books[i].GetComponent<Book>().bookId);
        }
        text.GetComponent<TMPro.TMP_Text>().text = books[0].gameObject.name +" diletakkan di " + "lemari atas";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckBookPlaced(int bookId)
    {
        bool found = false;
        int idx = -1;
        for(int i = 0; i < books.Length; i++)
        {
            if(bookId == books[i].GetComponent<Book>().bookId)
            {
                found = true;
                idx = i;
                break;
            }
        }
        if (found)
        {
            bookIds.RemoveAt(idx);
            //play suara dr Irma, "Kamu benar" dsb
        }else
        {
            //play suara dr Irma, sepertinya kurang tepat deh, ayo coba lagi.
        }
    }
}
