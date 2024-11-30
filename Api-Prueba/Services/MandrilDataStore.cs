using Api_Prueba.Models; 
namespace Api_Prueba.Services;

public class MandrilDataStore{
    public static MandrilDataStore Instance{get;} = new MandrilDataStore(); 


    public  List<Mandril>? Mandrils { get; set; } 

    public MandrilDataStore()
    {
        Mandrils = new List<Mandril>
            {
                new Mandril
                {
                    Id = 1,
                    Nombre = "Mini Mandril",
                    Apellido = "Rodriguez",
                    Habilidades = new List<Habilidades>
                    {
                        new Habilidades
                        {
                            Id = 1,
                            NombreHabilidad = "Saltar",
                            Potencia = Habilidades.EPotencia.moderado
                        }
                    }
                },
                new Mandril
                {
                    Id = 2,
                    Nombre = "Mega Mandril",
                    Apellido = "Fernandez",
                    Habilidades = new List<Habilidades>
                    {
                        new Habilidades
                        {
                            Id = 2,
                            NombreHabilidad = "Correr",
                            Potencia = Habilidades.EPotencia.intenso
                        },
                        new Habilidades
                        {
                            Id = 3,
                            NombreHabilidad = "Trepar",
                            Potencia = Habilidades.EPotencia.Extremo
                        }
                    }
                }
            };
    }
}