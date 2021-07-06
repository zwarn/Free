using ui;
using UnityEngine;
using Animation = animation.Animation;

namespace model
{
    public abstract class Skill : ScriptableObject
    {
        public Sprite image;
        public string name;

        public abstract Animation Execute(State state, Character subject, Direction direction);
    }
}