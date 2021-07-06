using Unity.Mathematics;
using UnityEngine;
using view;

namespace animation
{
    public class EmptyAnimation : Animation
    {
        public EmptyAnimation()
        {
            Finished = true;
        }

        protected override void OnUpdate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnStart()
        {
            throw new System.NotImplementedException();
        }
    }
}