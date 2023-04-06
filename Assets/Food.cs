using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
RandomizePosition();
            UIManager.Instance.count += 1;
            UIManager.Instance.UpdateUI();
        }
            
    }
}
