using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        private GameObject HitPrefab;

        [SerializeField] private Transform HitPos;

        private void Start()
        {
            Controller.Attack += Hit;
            LoadData();
        }

        private void Hit(int damage)
        {
            GameObject temp = Instantiate(HitPrefab, HitPos.position, Quaternion.identity, gameObject.transform) as GameObject;
            temp.GetComponent<Hit.Controller>().damage = damage;
        }

        private void LoadData()
        {
            HitPrefab = Config.Instance.HitPrefab;
        }

        private void OnDestroy()
        {
            Controller.Attack -= Hit;
        }
    }
}

