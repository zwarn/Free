using System;
using System.Collections.Generic;
using UnityEngine;

namespace animation
{
    public class AnimationController : MonoBehaviour
    {
        private static AnimationController _instance = null;

        public static AnimationController Instance()
        {
            return _instance;
        }

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            _effectController = EffectController.Instance();
        }

        private readonly Queue<Animation> _pendingAnimations = new Queue<Animation>();
        private Animation _currentAnimation;
        private EffectController _effectController;

        public void Show(List<Animation> animations)
        {
            animations.ForEach(animation => _pendingAnimations.Enqueue(animation));
            PullFirstAnimation();
        }

        public bool Finished()
        {
            return _currentAnimation == null;
        }

        private void PullFirstAnimation()
        {
            if (_currentAnimation == null && _pendingAnimations.Count > 0)
            {
                _currentAnimation = _pendingAnimations.Dequeue();
            }
        }

        private void Update()
        {
            if (_currentAnimation == null)
            {
                return;
            }

            _currentAnimation.Animate(Time.deltaTime);
            if (_currentAnimation.Finished)
            {
                _currentAnimation = null;
                PullFirstAnimation();
                _effectController.Clean();
            }
        }
    }
}