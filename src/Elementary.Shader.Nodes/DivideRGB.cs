namespace Elementary.Shader.Nodes
{
    using UnityEditor.ShaderGraph;
    using System.Reflection;
    [Title("Math")]
    public class DivideRGB : CodeFunctionNode
    {
        public DivideRGB() => name = "Divide RGB";

        protected override MethodInfo GetFunctionToConvert() =>
            GetType().GetMethod("_Function",
                BindingFlags.Static | BindingFlags.NonPublic);


        static string _Function(
            [Slot(0, Binding.None)] Vector1 R,
            [Slot(1, Binding.None)] Vector1 G,
            [Slot(2, Binding.None)] Vector1 B,
            [Slot(3, Binding.None)] Vector1 Divider,
            [Slot(4, Binding.None)] out DynamicDimensionVector Out
        )
        {
            return @"
{
	Out = ((R + G + B) / Divider);
}
";
        }
    }
}
