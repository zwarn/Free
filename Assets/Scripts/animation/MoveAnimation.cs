using model;
using Unity.Mathematics;
using UnityEngine;
using view;

namespace animation
{
    public class MoveAnimation : Animation
    {
        private Vector3 _from;
        private Vector3 _to;
        private CharacterView _characterView;
        private Direction _direction;
        private float _duration = 0.5f;

        public MoveAnimation(Vector2Int from, Vector2Int to, CharacterView characterView, Direction direction)
        {
            _from = (Vector2) from;
            _to = (Vector2) to;
            _characterView = characterView;
            _direction = direction;
        }

        protected override void OnStart()
        {
            EffectController.Instance().ShowSelection(_characterView);
            EffectController.Instance().ShowMoveEffect(_to, _direction);
        }

        protected override void OnUpdate(float deltaTime)
        {
            _currentTime += deltaTime;
            float t = _currentTime / _duration;

            _characterView.transform.localPosition = math.lerp(_from, _to, t);

            if (_currentTime >= _duration)
            {
                Finished = true;
            }
        }
    }
}