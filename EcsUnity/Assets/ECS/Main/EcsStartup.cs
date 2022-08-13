using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class EcsStartup : MonoBehaviour
{
    private EcsWorld ecsWorld;
    private EcsSystems fixedUpdateSystems;
    private EcsSystems updateSystems;
    public SceneData sceneData;
    public StaticData configuration;


    private void Start()
    {
        ecsWorld = new EcsWorld(); 
        updateSystems = new EcsSystems(ecsWorld);
        fixedUpdateSystems = new EcsSystems(ecsWorld);
        RuntimeData runtimeData = new RuntimeData();

        updateSystems
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new PlayerWalkAnimationSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData);


        fixedUpdateSystems
            .Add(new PlayerMoveSystem())
            .Add(new PlayerIdleAnimationSystem());

        updateSystems.Init();
        fixedUpdateSystems.Init();
    }

    private void Update()
    {
        updateSystems?.Run(); 
    }
    private void FixedUpdate()
    {
        fixedUpdateSystems?.Run();
    }

    private void OnDestroy()
    {
        updateSystems?.Destroy(); 
        updateSystems = null;
        fixedUpdateSystems?.Destroy();
        fixedUpdateSystems = null;
        ecsWorld?.Destroy();
        ecsWorld = null;
    }
}
