using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance;

    [Space(10)]
    [Header("Player Settings")]

    public int playerDamage;
    public int playerHP;

    [Space(10)]
    [Header("Player Anim Settings")]

    public Color takeDamageColor;
    public float takeDamageDuration;

    [Space(10)]
    [Header("Player Anim Settings")]

    public GameObject HitPrefab;

    [Space(10)]
    [Header("Mob Settings")]

    public int mobDamage;
    public int mobHP;
    public float mobSpeed;
    public float fastMobSpeed;
    public float mobReloadDur;
    public Sprite[] mobSprites;
    public Sprite[] fastMobSprites;

    [Space(10)]
    [Header("Mob Anim Settings")]

    public Color mobTakeDamageColor;
    public float mobTakeDamageDuration;

    [Space(10)]
    [Header("Waves Settings")]

    public float waveReloadDur;
    public int mobsPerWave;
    public float fastMobChance;
    public float spawnDelay;



    private void Awake()
    {
        Instance = this;
    }
}
