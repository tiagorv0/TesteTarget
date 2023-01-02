using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using TesteTecnicoTarget.Model;

namespace TesteTecnicoTarget.Storage
{
    public class JsonStorage : IJsonStorage
    {
        private static string _filePath;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly List<Faturamento> _context;
        private readonly JsonStorageOptions _options;

        public JsonStorage(IOptions<JsonStorageOptions> options)
        {
            _options = options.Value ?? new JsonStorageOptions();
            _filePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + _options.FilePath;
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };

            _context = ReadFile().ToList();
        }

        public IEnumerable<Faturamento> GetAll()
        {
            return _context;
        }

        private IEnumerable<Faturamento> ReadFile()
        {
            if (!FileExists())
                return new List<Faturamento>();

            var result = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(result))
                return new List<Faturamento>();

            try
            {
                return JsonSerializer.Deserialize<IEnumerable<Faturamento>>(result);
            }
            catch (JsonException ex)
            {
                throw new FileLoadException($"Erro ao iniciar arquivo: ${ex}");
            }
        }

        private bool FileExists()
        {
            return File.Exists(_filePath);
        }
    }
}
