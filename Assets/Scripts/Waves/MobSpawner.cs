using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waves
{
    public class MobSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject mob;
        [SerializeField] private Transform[] spawnPos;
        private List<GameObject> tempObjs = new List<GameObject>();

        private Sprite[] mobSpr, fastMobSpr;
        private float waveReloadDur;
        private int mobsPerWave;
        private float fastMobChance;
        private float spawnDelay;

        private void Start()
        {
            Controller.SpawnMobs += HandleSpawning;
            LoadData();
        }

        private void HandleSpawning(bool spawn)
        {

            if (spawn)
            {
                StartCoroutine(Spawn());
            }
            else
            {
                StopAllCoroutines();
                ClearTempObjs();
            }
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                for (int i = 0; i < mobsPerWave; i++)
                {
                    tempObjs.Add(SpawnMobObj());
                    yield return new WaitForSeconds(spawnDelay);
                }
                yield return new WaitForSeconds(waveReloadDur);

            }
        }

        private GameObject SpawnMobObj()
        {
            Sprite spr;

            GameObject newMob = Instantiate(mob) as GameObject;
            newMob.transform.position = spawnPos[Random.Range(0, spawnPos.Length)].position;

            int chance = Random.Range(0, 101);
            if (chance <= fastMobChance)
            {
                spr = fastMobSpr[Random.Range(0, fastMobSpr.Length)];
                newMob.GetComponent<Enemy.Controller>().isFast = true;
            }
            else
            {
                spr = mobSpr[Random.Range(0, mobSpr.Length)];
            }

            newMob.GetComponent<SpriteRenderer>().sprite = spr;

            return newMob;
        }

        private void ClearTempObjs()
        {
            Debug.Log("Clear monsters");

            foreach (var obj in tempObjs)
            {
                if (obj.gameObject != null)
                {
                    Debug.Log("Destroy monster");
                    Destroy(obj.gameObject);
                }
            }

            tempObjs.Clear();
        }

        private void LoadData()
        {
            Config cfg = Config.Instance;

            waveReloadDur = cfg.waveReloadDur;
            mobsPerWave = cfg.mobsPerWave;
            fastMobChance = cfg.fastMobChance;
            spawnDelay = cfg.spawnDelay;
            mobSpr = cfg.mobSprites;
            fastMobSpr = cfg.fastMobSprites;
        }

        private void OnDestroy()
        {
            Controller.SpawnMobs -= HandleSpawning;
        }
    }
}
