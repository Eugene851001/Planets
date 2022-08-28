using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Behaviour
{
    public class Attack : IThinker
    {
        public Enemy Context { get; set; }

        private Player _player;

        public Attack(Player player)
        {
            _player = player;
        }

        public void Think()
        {
            Context.DZenit = 0;
            Context.DAzimut = 0;

            Context.Attack(_player);

            if (!Utils.IsInRange(
                new Vector2(_player.Zenit, _player.Azimut), 
                new Vector2(Context.Zenit, Context.Azimut), 
                Context.AttackRange))
            {
                var state = new Following(_player);
                state.Context = Context;

                Context.ChangeState(state);
            }
        }
    }
}
