using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _derction = Vector2.right;

    private List<Transform> _segments = new List<Transform>();

    public Transform segmentPrefab;

    public int initialSize = 4;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _derction != Vector2.down)
        {
            _derction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _derction != Vector2.up)
        {
            _derction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _derction != Vector2.right)
        {
            _derction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _derction != Vector2.left)
        {
            _derction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        
        for (int i = _segments.Count - 1; i > 0 ; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + _derction.x,
            Mathf.Round(transform.position.y) + _derction.y,
            0
            );

    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
Grow();
        }
        else if(collision.tag == "Obstacle")
        {
            ResetState();
        }
        else if (collision.tag == "Player")
        {
            ResetState();
        }

    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(transform);

        for (int i = 0; i < initialSize; i++)
        {
            _segments.Add(Instantiate(segmentPrefab));
        }

        transform.position = Vector3.zero;

        UIManager.Instance.count = 0;
        UIManager.Instance.UpdateUI();
    }
}
