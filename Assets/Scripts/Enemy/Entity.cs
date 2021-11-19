﻿using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
    public Enemy enemy;
    public Character targetCharacter;
    public ObjectPool pool;
    private Phase currentPhase;

    void Start()
    {
        enemy = EnemyBuilder.enemies[0];
        enemy.Start();
        currentPhase = enemy.phases[0];

        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Characters/Enemies/" + enemy.sprite);
    }

    void Update()
    {
        enemy.SetPosition(transform.position);
        currentPhase.Run(enemy, targetCharacter, pool);
        currentPhase.IncrementAttackTime(Time.deltaTime);
    }

    private Phase GetPhase(string name)
    {
        foreach (Phase phase in enemy.phases)
        {
            if (phase.name == name) return phase;
        }
        return null;
    }
}