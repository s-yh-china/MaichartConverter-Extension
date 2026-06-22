using System.Text.Json.Serialization;

namespace MaichartConverter;

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(SortedDictionary<int, string>))]
[JsonSerializable(typeof(Program.TrackGroup))]
internal partial class MaichartConverterJsonContext : JsonSerializerContext;