using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Redirector.Configuration
{
  public class RedirectMap : IRedirectMap
  {
    public static RedirectMap Instance { get; private set; }

    public static void Initialize(string mappingFile)
    {
      var options = new JsonSerializerOptions
      {
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true
      };

      Instance = JsonSerializer.Deserialize<RedirectMap>(File.ReadAllText(mappingFile), options);
    }

    public string DefaultDestination { get; set; }
    
    public IDictionary<string, string> Mappings { get; set; }
  }
}