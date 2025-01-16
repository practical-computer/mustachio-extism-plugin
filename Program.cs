using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using Extism;
using Mustachio;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MustachioPlugin;
public class Program
{
    public static void Main()
    {
        // Note: a `Main` method is required for the app to compile
    }

    [UnmanagedCallersOnly(EntryPoint = "combine")]
    public static int MustachioCombine() {
        var parameters = Pdk.GetInputJson(SourceGenerationContext.Default.MustachioInput);
        var input = new MustachioInput(parameters.template, parameters.model_json);

        // Parse the template
        var template = Mustachio.Parser.Parse(input.template);

        // Build the ExpandoObject
        dynamic? model = JsonConvert.DeserializeObject<ExpandoObject>(input.model_json);

        var content = template(model);
        Pdk.SetOutput(content);
        return 0;
    }
}

[JsonSerializable(typeof(MustachioInput))]
public partial class SourceGenerationContext : JsonSerializerContext {}

public record MustachioInput(string template, string model_json);