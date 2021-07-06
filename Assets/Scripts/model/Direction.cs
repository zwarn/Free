using System;
using System.Collections.Generic;
using System.Linq;
using ui;
using UnityEngine;

namespace model
{
    [CreateAssetMenu(fileName = "Direction", menuName = "Direction", order = 0)]
    public class Direction : ScriptableObject
    {
        public Vector2Int value;
        public Sprite image;

        private Direction(Vector2Int value)
        {
            this.value = value;
        }

        public static Vector2Int operator +(Vector2Int pos, Direction direction) => pos + direction.value;
        public static Vector2Int operator +(Direction direction, Vector2Int pos) => direction.value + pos;
        public static Vector2Int operator -(Vector2Int pos, Direction direction) => pos - direction.value;
        public static Vector2Int operator -(Direction direction, Vector2Int pos) => direction.value - pos;

        public static List<Direction> AllDirection()
        {
            return Resources.FindObjectsOfTypeAll<Direction>().OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}