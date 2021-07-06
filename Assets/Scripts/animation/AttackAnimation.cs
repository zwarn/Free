using System.Collections.Generic;
using model;
using UnityEngine;
using view;

namespace animation
{
    public class AttackAnimation : Animation
    {
        private float _duration = 0.5f;
        private CharacterView _characterView;
        private Vector2Int _position;
        private Skill _skill;
        private List<Vector2Int> _targets;

        public AttackAnimation(CharacterView characterView, Vector2Int position, List<Vector2Int> targets, Skill skill)
        {
            _characterView = characterView;
            _position = position;
            _targets = targets;
            _skill = skill;
        }

        protected override void OnStart()
        {
            EffectController.Instance().ShowSelection(_characterView);
            _targets.ForEach(target => EffectController.Instance().ShowAttackEffect((Vector2) target, _skill));
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