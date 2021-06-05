using API.NET_integrada_ao_mongoDB.Data.Collections;
using API.NET_integrada_ao_mongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.NET_integrada_ao_mongoDB.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class InfectadoController : ControllerBase
  {
    Data.MongoDB _mongoDB;
    IMongoCollection<Infectado> _infectadosCollection;

    public InfectadoController(Data.MongoDB mongoDB)
    {
      _mongoDB = mongoDB;
      _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
    }

    [HttpPost]
    public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
    {
      var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

      _infectadosCollection.InsertOne(infectado);

      return StatusCode(201, "Infectado adicionado com sucesso");
    }

    [HttpGet]
    public ActionResult ObterInfectados()
    {
      var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

      return Ok(infectados);
    }
  }
}
