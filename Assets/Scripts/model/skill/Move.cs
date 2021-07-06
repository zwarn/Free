using animation;
using control;
using UnityEngine;
using Animation = animation.Animation;

namespace model
{
    [CreateAssetMenu(fileName = "Move", menuName = "Skill/Move", order = 0)]
    public class Move : Skill
    {
        public override Animation Execute(State state, Character subject, Direction direction)
        {
            Animation result = new EmptyAnimation();
            var target = subject.Position + direction.value;
            if (GameHelper.isFree(state, target))
            {
                result = new MoveAnimation(subject.Position, target, subject.View, direction);
                subject.Position += direction.value;
            }

            return result;
        }
    }
}