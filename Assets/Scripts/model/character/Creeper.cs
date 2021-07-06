using System.Collections.Generic;
using control;
using scriptableObject;
using UnityEngine;
using Animation = animation.Animation;

namespace model
{
    public class Creeper : Character
    {
        public Direction Direction;

        public static CharacterSo characterSo => Resources.Load<CharacterSo>("Character/Creeper");

        public Creeper(Vector2Int position, bool friend = false) : base(position, characterSo,
            friend)
        {
        }

        public override List<Animation> Act(State state)
        {
            return new List<Animation>();
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