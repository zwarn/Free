using animation;
using control;
using UnityEngine;
using Animation = animation.Animation;

namespace model
{
    [CreateAssetMenu(fileName = "Wait", menuName = "Skill/Wait", order = 0)]
    public class Wait : Skill
    {
        public override Animation Execute(State state, Character subject, Direction direction)
        {
            return new EmptyAnimation();
        }
    }
}