using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using System;

public class PlayerIdleAnimationSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent, InputComponent, MoveComponent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);
            ref var input = ref filter.Get2(i);
            ref var move = ref filter.Get3(i);

            float lastMoveX = input.moveInput.x;
            float lastMoveY = input.moveInput.y;
            player.animator.SetFloat("lastMoveX", lastMoveX);
            player.animator.SetFloat("lastMoveY", lastMoveY);
            if (lastMoveX != 0 || lastMoveY != 0) 
            {
                move.isMoving = true;
                LastInput(lastMoveX, "lastMoveX", player.animator);
                LastInput(lastMoveY, "lastMoveY", player.animator);
            }
            else
            {
                move.isMoving = false;
            }
            if (lastMoveX < 0)
            {
                player.spriteRenderer.flipX = true;
            }
            if (lastMoveX > 0)
            {
                player.spriteRenderer.flipX = false;
            }
            player.animator.SetBool("isWalking", move.isMoving);
        }
    }
    public void LastInput(float lastInput, string nameOfParamater, Animator anim)
    {
        if (lastInput > 0)
        {
            anim.SetFloat(nameOfParamater, 1f);
        }
        else if (lastInput < 0)
        {
            anim.SetFloat(nameOfParamater, -1f);
        }
        else
        {
            anim.SetFloat(nameOfParamater, 0f);
        }

    }


}
