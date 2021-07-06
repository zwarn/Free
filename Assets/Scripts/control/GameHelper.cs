using System;
using System.Collections.Generic;
using System.Linq;
using model;
using Unity.Mathematics;
using UnityEngine;

namespace control
{
    public static class GameHelper
    {
        public static bool isFree(State state, Vector2Int position)
        {
            var board = state.Board;
            var size = board.Size;
            bool onBoard = position.x >= 0 && position.y >= 0 && position.x < size.x && position.y < size.y;
            bool noCharacters = board.Characters.TrueForAll(chara => !chara.Position.Equals(position));
            return onBoard && noCharacters;
        }

        public static Character CharacterAtPosition(State state, Vector2Int position)
        {
            return state.Board.Characters.Find(character => character.Position == position);
        }

        public static List<Direction> FindPathTo(State state, Vector2Int from,
            Predicate<Vector2Int> predicate)
        {
            Dictionary<Vector2Int, List<Direction>> paths = new Dictionary<Vector2Int, List<Direction>>();
            List<Tuple<Vector2Int, List<Direction>>> newlyFound = new List<Tuple<Vector2Int, List<Direction>>>();
            newlyFound.Add(new Tuple<Vector2Int, List<Direction>>(from, new List<Direction>()));

            while (newlyFound.Count != 0)
            {
                var candidates = newlyFound.ToList();
                newlyFound.Clear();
                candidates.ForEach(candidate =>
                {
                    Direction.AllDirection().ForEach(direction =>
                    {
                        Vector2Int pos = candidate.Item1 + direction;
                        if (!paths.ContainsKey(pos) && isFree(state, pos))
                        {
                            List<Direction> path = candidate.Item2.ToList();
                            path.Add(direction);
                            var found = new Tuple<Vector2Int, List<Direction>>(pos, path);
                            newlyFound.Add(found);
                            paths.Add(pos, path);
                        }
                    });
                });
                var foundResult = newlyFound.Find(tuple => predicate(tuple.Item1));
                if (foundResult != null)
                {
                    return foundResult.Item2;
                }
            }

            if (paths.Count == 0)
            {
                return null;
            }

            return null;

            // Func<Vector2Int, int> orderBy = pos => pos.x - to.x + pos.y - to.y;
            // var best = paths.Keys.OrderBy(orderBy).First();
            // return paths[best];
        }

        public static Predicate<Vector2Int> InRange(State state, int range)
        {
            return pos =>
            {
                return state.Board.Characters.OfType<Hero>().Any(hero => Manhatten(hero.Position, pos) <= range);
            };
        }

        private static int Manhatten(Vector2Int pos1, Vector2Int pos2)
        {
            return math.abs(pos1.x - pos2.x) + math.abs(pos1.y - pos2.y);
        }

        public static Hero GetHero(State state, Vector2Int position, int range)
        {
            return state.Board.Characters.OfType<Hero>().First(hero => Manhatten(hero.Position, position) <= range);
        }
    }
}