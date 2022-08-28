using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Behaviour
{
    public class Following : IThinker
    {
        private Player _player;
        private Enemy _enemy;

        public Enemy Context { get => _enemy; set => _enemy = value; }

        public Following(Player player)
        {
            _player = player;
        }

        public void Think()
        {
            _enemy.SetDestination(_player.Zenit, _player.Azimut);

            //TODO: change square to circle
            if (Utils.IsInRange(
                new Vector2(_player.Zenit, _player.Azimut), 
                new Vector2(_enemy.Zenit, _enemy.Azimut), 
                _enemy.AttackRange))
            {
                var newState = new Attack(_player);
                newState.Context = _enemy;
                _enemy.ChangeState(newState);
            }
        }
    }
}
