using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent, InputComponent, MoveComponent> filter;
    public void Run()
    {
        foreach (var i in filter) 
        {
            ref var player = ref filter.Get1(i);
            ref var input = ref filter.Get2(i);
            ref var move = ref filter.Get3(i);

            player.rigidbody2D.velocity = input.moveInput * move.speed;

        }
    }
}
