using System.Collections.Generic;
using model;
using UnityEngine;
using view;

namespace animation
{
    public class TakeDamageAnimation : Animation
    {
        private float _duration = 0.5f;
        private CharacterView _characterView;

        public TakeDamageAnimation(CharacterView characterView)
        {
            _characterView = characterView;
        }

        protected override void OnStart()
        {
            // EffectController.Instance().ShowDamageEffect(_characterView);
        }

        protected override void OnUpdate(float deltaTime)
        {
            _currentTime += deltaTime;

            if (_currentTime >= _duration)
            {
                Finished = true;
            }
        }
    }
}