using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Animations : MonoBehaviour
    {
        private SpriteRenderer spr;

        private float takeDamageDuration;
        private Color takeDamageColor;

        private void Start()
        {
            spr = GetComponent<SpriteRenderer>();
            LoadData();
        }

        public void TakeDamage()
        {
            StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            float duration = takeDamageDuration / 2;

            Color startColor = Color.white;
            Color targetColor = takeDamageColor;

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                spr.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);

            elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                spr.color = Color.Lerp(targetColor, startColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        private void LoadData()
        {
            takeDamageColor = Config.Instance.mobTakeDamageColor;
            takeDamageDuration = Config.Instance.mobTakeDamageDuration;
        }
    }
}
