# Protobuf Library Optimized for Unity

An optimized protobuf serialization library designed for Unity game engine.

Forked and modified from [protobuf-net v2.4.14](https://github.com/protobuf-net/protobuf-net/tree/2.4.14)

## Key Features

- **Custom ProtoActivator**: Supports user-defined instance factory for custom caching implementation
- **Object Pool Support**: Maximizes object reuse and reduces GC pressure
- **Unity Compatible**: Fully tested and optimized for Unity runtime environment

## Improvements Over Original

- Added `ProtoActivator.RegisterCustomFactory()` for custom instance creation with object pool support
- Support for non-public constructors in protobuf message classes
- Improved memory management suitable for Unity's garbage collection

## Installation

Open Unity Package Manager and add package from git URL:
```
https://github.com/XuToWei/Protobuf-Unity.git
```

## Usage Example

```csharp
// Register custom object pool factory
ProtoActivator.RegisterCustomFactory<object>((type, nonPublic) => 
{
    // Your custom object pool logic here
    // The nonPublic parameter indicates whether to access non-public constructors
    if (type == typeof(MyMessage))
    {
        return ObjectPool.Get<MyMessage>();
    }
    // Return null to fallback to default Activator.CreateInstance
    return null;
});

// Use protobuf serialization
var message = Serializer.Deserialize<MyMessage>(stream);

// Clear custom factory when no longer needed
ProtoActivator.ClearCustomFactory();
```