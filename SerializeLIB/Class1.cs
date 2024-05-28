using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializeLIB
{
    public class Serializer
    {
        public async Task SerializeAsync<T>(T obj, string filePath)
        {
            using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, obj);
            await createStream.DisposeAsync();
        }

        public async Task<T> DeserializeAsync<T>(string filePath)
        {
            using FileStream openStream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(openStream);
        }
    }
}