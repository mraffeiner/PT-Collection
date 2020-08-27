using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    [Serializable]
    private struct NameSystemPair
    {
        public string name;
        public ParticleSystem system;

        public NameSystemPair(string name, ParticleSystem system)
        {
            this.name = name;
            this.system = system;
        }
    }

    [SerializeField] private List<NameSystemPair> nameSystemPairs = null;

    private void OnEnable() => Enemy.Died += OnEnemyDied;

    private void OnDisable() => Enemy.Died -= OnEnemyDied;

    private void OnEnemyDied(Enemy enemy)
    {
        var enemyDeathParticles = nameSystemPairs.Find(x => x.name == "EnemyDeath").system;
        transform.position = enemy.transform.position;
        enemyDeathParticles.Play();
    }
}
