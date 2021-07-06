using System.Collections.Generic;
using animation;
using control;
using UnityEngine;
using Animation = animation.Animation;

namespace model
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Skill/Attack", order = 0)]
    public class Attack : Skill
    {
        public int damage;

        public override Animation Execute(State state, Character subject, Direction direction)
        {
            var target = subject.Position + direction.value;
            var attacked = GameHelper.CharacterAtPosition(state, target);
            if (attacked != null)
            {
                attacked.TakeDamage(state, damage);
            }

            return new AttackAnimation(subject.View, subject.Position,
                new List<Vector2Int>() {subject.Position + direction}, this);
        }
    }
}