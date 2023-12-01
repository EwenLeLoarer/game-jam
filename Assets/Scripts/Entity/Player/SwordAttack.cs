using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    List<GameObject> enemyGameObject = new();
    private void OnTriggerEnter(Collider other)
    {
        if (enemyGameObject.Contains(other.gameObject))
        {
            return;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(other.gameObject);
            var enemy = other.gameObject.GetComponent<Entity>();
            enemy.ActualHP--;
            enemy.HealthBar.UpdateHealthBar(enemy.MaxHP, enemy.ActualHP);
            enemyGameObject.Add(other.gameObject);
        }
    }

    private void OnEnable() => enemyGameObject.Clear();


    private void OnDisable() => enemyGameObject.Clear();
    


}
