using System;

namespace API.NET_integrada_ao_mongoDB.Models
{
  public class InfectadoDto
  {
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
  }
}