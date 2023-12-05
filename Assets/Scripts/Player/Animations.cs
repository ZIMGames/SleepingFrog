using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Animations : MonoBehaviour
    {
        private Animator _animator;
        private Vector3 scale;
        private string curDir;
        private SpriteRenderer spr;
        /////////////////////////////////cfg values
        private float takeDamageDuration;
        private Color takeDamageColor;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            curDir = "left";
            spr = GetComponent<SpriteRenderer>();
            scale = transform.localScale;
            Controller.PlayAnimation += PlayAnim;
            Controller.TakedDamage += TakeDamage;
            LoadData();
        }

        private void PlayAnim(string dir)
        {
            TurnPlayer(dir);
            _animator.SetTrigger("Attack");
        }

        private void TurnPlayer(string dir)
        {

            if (curDir != dir)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, scale.y, scale.z);
                curDir = dir;
            }
        }

        private void TakeDamage()
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
            takeDamageDuration = Config.Instance.takeDamageDuration;
            takeDamageColor = Config.Instance.takeDamageColor;
        }

        private void OnDestroy()
        {
            Controller.PlayAnimation -= PlayAnim;
            Controller.TakedDamage -= TakeDamage;
        }
    }
}
