using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameplayScope : LifetimeScope
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private ObjectSelector objectSelector;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<GameplayEntryPoint>(Lifetime.Scoped);
        builder.RegisterComponent(inputHandler);
        builder.RegisterComponent(objectSelector);
        builder.Register<Grid>(Lifetime.Scoped);
        builder.Register<ObjectPlacer>(Lifetime.Scoped);
    }
}
