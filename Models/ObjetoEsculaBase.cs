using System;

namespace PlatziASPNETCore.Models
{
  public abstract class ObjetoEsculaBase
  {
    public string UniqueId { get; set; }
    public string Nombre { get; set; }
    public ObjetoEsculaBase()
    {
      UniqueId = Guid.NewGuid().ToString();
    }
    public override string ToString()
    {
      return $"{Nombre},{UniqueId}";
    }
  }
}
