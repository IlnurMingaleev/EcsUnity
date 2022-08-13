using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;
    public void Init()
    {
        EcsEntity playerEntity = ecsWorld.NewEntity();

        ref var player = ref playerEntity.Get<PlayerComponent>();
        ref var inputComponent = ref playerEntity.Get<InputComponent>();
        ref var moveComponent = ref playerEntity.Get<MoveComponent>();
        GameObject playerGameObject = Object.Instantiate(staticData.playerPrefab, sceneData.playerSpawnPoint.position, Quaternion.identity);
        player.rigidbody2D = playerGameObject.GetComponent<Rigidbody2D>();
        player.playerCollider = playerGameObject.GetComponent<Collider2D>();
        player.playerTransform = playerGameObject.GetComponent<Transform>();
        player.spriteRenderer = playerGameObject.GetComponent<SpriteRenderer>();
        player.animator = playerGameObject.GetComponent<Animator>();
        moveComponent.speed = staticData.playerSpeed;
        moveComponent.isMoving = false;
    }
}
