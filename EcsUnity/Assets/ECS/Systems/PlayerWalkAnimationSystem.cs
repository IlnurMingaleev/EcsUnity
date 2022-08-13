using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using System;

public class PlayerWalkAnimationSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent, InputComponent, MoveComponent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);
            ref var input = ref filter.Get2(i);
            ref var move = ref filter.Get3(i);

            float moveX = input.moveInput.x;
            float moveY = input.moveInput.y;
            if (Math.Abs(moveX) + Math.Abs(moveY) < float.Epsilon) return;
            else
            {
                player.animator.SetFloat("moveX", moveX);
                player.animator.SetFloat("moveY", moveY);
                if (moveX < 0)
                {
                    player.spriteRenderer.flipX = true;
                }
                if (moveY > 0)
                {
                    player.spriteRenderer.flipX = false;
                }
            }
        }
    }
}
