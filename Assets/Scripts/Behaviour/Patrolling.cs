using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Behaviour
{
    public class Patrolling: IThinker
    {
        private Vector2 destination;
        private const float delta = 2;

        private Player _player;

        public Enemy Context { get; set; }

        public Patrolling(Player player)
        {
            _player = player;
        }

        public void Think()
        {
            Context.SetDestination(destination.x, destination.y);
            if (CheckDestination(Context))
            {
                destination = new Vector2(GetRandZenit(), GetRandAzimut());
            }

            if (Utils.IsInRange(
                new Vector2(_player.Zenit, _player.Azimut), 
                new Vector2(Context.Zenit, Context.Azimut), 
                Context.FollowRange))
            {
                var state = new Following(_player);
                state.Context = Context;

                Context.ChangeState(state);
            }
        }

        private bool CheckDestination(Enemy enemy)
        {
            if (destination == null) return false;

            return Math.Abs(enemy.Zenit - destination.x) < delta
                && Math.Abs(enemy.Azimut - destination.y) < delta;
        }

        private static float GetRandZenit() => HelpGetRand(180);

        private static float GetRandAzimut() => HelpGetRand(360);

        private static float HelpGetRand(int interval)
        {
            var rand = new System.Random(Environment.TickCount);
            return (float)(rand.NextDouble()) * interval;
        }
    }
}
