using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    [Serializable]
    private struct ParticleEntry
    {
        public string name;
        public ParticleSystem system;

        public ParticleEntry(string name, ParticleSystem system)
        {
            this.name = name;
            this.system = system;
        }
    }

    [SerializeField] private List<ParticleEntry> particleEntries = null;

    private void OnEnable() => Enemy.Died += OnEnemyDied;

    private void OnDisable() => Enemy.Died -= OnEnemyDied;

    private void OnEnemyDied(Enemy enemy)
    {
        var enemyDeathParticles = particleEntries.Find(x => x.name == "EnemyDeath").system;
        transform.position = enemy.transform.position;
        enemyDeathParticles.Play();
    }
}
