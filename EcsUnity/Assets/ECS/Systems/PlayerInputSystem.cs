using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<InputComponent> filter;
    public void Run()
    {
        foreach (var i in filter) 
        {
            ref var input = ref filter.Get1(i);

            input.moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        }
    }
}
