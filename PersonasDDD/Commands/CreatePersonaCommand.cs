namespace PersonasDDD.Commands
{
    public record CreatePersonaCommand(Guid personId, string Nombre)  //record para que no mutue
    {

    }
}
