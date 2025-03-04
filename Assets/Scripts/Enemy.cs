using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points); //This defines a type not a function.

    public static event EnemyDied OnEnemyDied; //static, this belongs to the class not each individual enemy. Property of the class itself not each instance of the class.
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      Destroy(collision.gameObject);

      // OnEnemyDied?.Invoke(); Is the same as the if statement.
      if (OnEnemyDied != null)
      {
          OnEnemyDied.Invoke(3); //Change me later
      }
      
    }
}
