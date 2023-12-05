using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Animations : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            Controller.PlayAnim += AnimPlay;
        }

        private void AnimPlay(string trigger)
        {
            Debug.Log("animator trigger " + trigger);
            _animator.SetTrigger(trigger);
        }

        private void OnDestroy()
        {
            Controller.PlayAnim -= AnimPlay;
        }
    }
}
