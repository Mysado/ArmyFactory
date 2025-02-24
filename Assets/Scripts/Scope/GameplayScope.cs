using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameplayScope : LifetimeScope
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private ObjectSelector objectSelector;
    [SerializeField] private ObjectMover objectMover;
    [SerializeField] private PlaceableDataContainer placeableDataContainer;
    [SerializeField] private PlaceablePanelView placeablePanelView;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<GameplayEntryPoint>(Lifetime.Scoped);

        builder.Register<Grid>(Lifetime.Scoped);
        builder.Register<ObjectPlacer>(Lifetime.Scoped);
        
        builder.RegisterInstance(placeableDataContainer);
        
        builder.RegisterComponent(inputHandler);
        builder.RegisterComponent(objectSelector);
        builder.RegisterComponent(objectMover);
        builder.RegisterComponent(placeablePanelView);
    }
}
