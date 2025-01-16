# Mustachio Extism Plugin

This [Extism](https://extism.org) plugin allows you to use [Postmark's Mustachio templating engine](https://github.com/ActiveCampaign/mustachio) from anywhere you can run Extism plugins

## Usage

The plugin has one action, `combine`, that accepts the following JSON input:

```json
{
  "template": "Your Mustachio Template",
  "model_json": "A String containing the model data to combine with the Mustachio Template, serialized as JSON"
}
```

### Example payload


```json
{
  "template": "Dear {{name}}, this is definitely a personalized note to you. Very truly yours, {{sender}}",
  "model_json": "{\"name\": \"John\", \"sender\": \"Sally\"}" 
}
```

## Build and run

```
dotnet build ./MustachioPlugin.csproj

extism call ./bin/Debug/net8.0/wasi-wasm/AppBundle/MustachioPlugin.wasm combine  --input '{"template": "The number is {{ a }}", "model_json": "{\"a\": 20}"}"' --wasi
# => The number is 20
```

## Publish

```
dotnet publish ./MustachioPlugin.csproj
```

Now you can find a trimmed `MustachioPlugin.wasm` file in `bin/Release/net8.0/wasi-wasm/AppBundle`

*If you're using `dotenvx` to set `WASI_SDK_PATH`*
```
dotenvx run -- dotnet build
dotenvx run -- dotnet publish
```

## Extism C# PDK Plugin Documentation

See more documentation at https://github.com/extism/dotnet-pdk and
[join us on Discord](https://extism.org/discord) for more help.
