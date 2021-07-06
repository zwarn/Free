using System.Collections.Generic;
using model;
using UnityEngine;

namespace scriptableObject
{
    [CreateAssetMenu(fileName = "Hero", menuName = "Hero", order = 0)]
    public class HeroSo : CharacterSo
    {
        public List<Skill> PossibleSkills;
        public Sprite Portrait;
    }
}