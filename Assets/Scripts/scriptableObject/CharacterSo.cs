using System.Collections.Generic;
using model;
using UnityEngine;

namespace scriptableObject
{
    [CreateAssetMenu(fileName = "Character", menuName = "Character", order = 0)]
    public class CharacterSo : ScriptableObject
    {
        public Sprite Sprite;
        public string Name;
        public int maxHp;
    }
}