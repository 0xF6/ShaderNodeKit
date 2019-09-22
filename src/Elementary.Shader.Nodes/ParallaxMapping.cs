namespace Elementary.Shader.Nodes
{
    using System.Reflection;
    using UnityEditor.ShaderGraph;
    using UnityEngine;

    [Title("Math", "Advanced")]
    public class ParallaxMapping : CodeFunctionNode
    {
        public ParallaxMapping() => name = "Parallax Mapping";

        protected override MethodInfo GetFunctionToConvert() =>
            GetType().GetMethod("_Function",
                BindingFlags.Static | BindingFlags.NonPublic);


        static string _Function(
            [Slot(0, Binding.None)] Vector2 texCoords,
            [Slot(1, Binding.None)] Vector3 viewDir,
            [Slot(2, Binding.None)] out DynamicDimensionVector Out
        )
        {
            return @"
{
    float height = texture(depthMap, texCoords).r;
    vec2 p = viewDir.xy / viewDir.z * (height * height_scale);
	Out = texCoords - p;
}
";
        }
    }
}