//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public PropertyComponent property { get { return (PropertyComponent)GetComponent(PlayerComponentsLookup.Property); } }
    public bool hasProperty { get { return HasComponent(PlayerComponentsLookup.Property); } }

    public void AddProperty(float newStrength, float newEndurance, float newPower, float newAgile, float newIntelligence, float newMechanical, float newBiological, float newPsionic) {
        var index = PlayerComponentsLookup.Property;
        var component = (PropertyComponent)CreateComponent(index, typeof(PropertyComponent));
        component.strength = newStrength;
        component.endurance = newEndurance;
        component.power = newPower;
        component.agile = newAgile;
        component.intelligence = newIntelligence;
        component.mechanical = newMechanical;
        component.biological = newBiological;
        component.psionic = newPsionic;
        AddComponent(index, component);
    }

    public void ReplaceProperty(float newStrength, float newEndurance, float newPower, float newAgile, float newIntelligence, float newMechanical, float newBiological, float newPsionic) {
        var index = PlayerComponentsLookup.Property;
        var component = (PropertyComponent)CreateComponent(index, typeof(PropertyComponent));
        component.strength = newStrength;
        component.endurance = newEndurance;
        component.power = newPower;
        component.agile = newAgile;
        component.intelligence = newIntelligence;
        component.mechanical = newMechanical;
        component.biological = newBiological;
        component.psionic = newPsionic;
        ReplaceComponent(index, component);
    }

    public void RemoveProperty() {
        RemoveComponent(PlayerComponentsLookup.Property);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherProperty;

    public static Entitas.IMatcher<PlayerEntity> Property {
        get {
            if (_matcherProperty == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.Property);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherProperty = matcher;
            }

            return _matcherProperty;
        }
    }
}
