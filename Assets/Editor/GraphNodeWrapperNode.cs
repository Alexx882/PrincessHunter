using System;
using UnityEngine;
using Unity.VisualScripting;

[UnitCategory("My Custom Nodes")]
public class GraphNodeWrapperNode : Unit
{
    [DoNotSerialize] public ControlInput enter;

    [DoNotSerialize] public ControlOutput exit;

    [DoNotSerialize] public ValueInput inputValue;

    protected override void Definition()
    {
        enter = ControlInput(nameof(enter), Enter);
        exit = ControlOutput(nameof(exit));
        inputValue = ValueInput<WrapperNodeTarget>(nameof(inputValue));
        Succession(enter, exit);
    }

    public ControlOutput Enter(Flow flow)
    {
        flow.GetValue<WrapperNodeTarget>(inputValue).run();

        return exit;
    }
}