using System.Collections.Generic;

namespace Redirector.Configuration
{
  public interface IRedirectMap 
  {
    string DefaultDestination { get; set; }
    IDictionary<string,string> Mappings { get; set; }
  }
}