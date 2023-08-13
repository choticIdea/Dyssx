using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    const float speed = 90f;
    public string fruitName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -speed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bucket")
        {
            //UI update or event system
            CatchTheFruit.instance.UpdateLevelTarget(fruitName);
            Destroy(this.gameObject);
        }
    }
}
