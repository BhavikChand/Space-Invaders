using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
  [FormerlySerializedAs("bullet")]
  public GameObject bulletPrefab;

  public Transform shottingOffset;

  void Start()
  {
    Enemy.OnEnemyDied += EnemyOnOnEnemyDied; //At start we sign up to the OnEnemyDied
  }

  private void OnDestroy()
  {
    Enemy.OnEnemyDied -= EnemyOnOnEnemyDied; //If the player died, destroy the subscription observer pattern. 
  }

  private void EnemyOnOnEnemyDied(int points) //Looks like the delegate
  {
    //I want to know about points here.
    Debug.Log($"I know about the dead enemy... points:{points}");
  }

  // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        // Destroy(shot, 3f);
      }
    }
}
