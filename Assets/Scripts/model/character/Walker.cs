using System.Collections.Generic;
using animation;
using control;
using scriptableObject;
using UnityEngine;
using Animation = animation.Animation;

namespace model
{
    public class Walker : Character
    {
        public static CharacterSo characterSo => Resources.Load<CharacterSo>("Character/Walker");
        public int movement = 2;
        public Skill attackSkill = Resources.Load<Attack>("Skill/Attack");

        public Walker(Vector2Int position, bool friend = false) : base(position, characterSo,
            friend)
        {
        }

        public override List<Animation> Act(State state)
        {
            List<Animation> result = new List<Animation>();

            var inRange = GameHelper.InRange(state, 1);
            if (!inRange.Invoke(Position))
            {
                GetInRange(state, result);
            }

            if (inRange.Invoke(Position))
            {
                AttackHero(state, result);
            }

            return result;
        }

        private void AttackHero(State state, List<Animation> result)
        {
            Hero target = GameHelper.GetHero(state, Position, 1);
            if (target != null)
            {
                target.TakeDamage(state, 1);
                result.Add(new AttackAnimation(View, Position,
                    new List<Vector2Int>() {target.Position}, attackSkill));
            }
        }

        private void GetInRange(State state, List<Animation> result)
        {
            var path = GameHelper.FindPathTo(state, Position, GameHelper.InRange(state, 1));
            if (path == null)
            {
                return;
            }

            for (int i = 0; i < movement && i < path.Count; i++)
            {
                var direction = path[i];
                result.Add(new MoveAnimation(Position, Position + direction, View, direction));
                Position += direction;
            }
        }

        public override Character Copy()
        {
            Creeper copy = new Creeper(Position);
            copy.hp = hp;
            copy.SetView(View);
            return copy;
        }
    }
}