namespace Api_Prueba.Models;

public class Habilidades
{
    public int Id { get; set; }

    public string NombreHabilidad  { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }
    public enum EPotencia { suabe,moderado,intenso,Repotente,Extremo }
}