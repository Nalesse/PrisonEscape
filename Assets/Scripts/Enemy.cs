using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private GameManager gameManager;
    private Transform player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * this.speed));
        var enemyPos = transform.position;
        enemyPos.x = player.position.x;
        transform.position = enemyPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Caught Player");
            gameManager.GameOver();
        }
    }
}
