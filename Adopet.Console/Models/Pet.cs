namespace Adopet.Console;

public class Pet(Guid id, string? nome, PetType tipo)
{
    public Guid Id { get; set; } = id;
    public string? Nome { get; set; } = nome;
    public PetType Tipo { get; set; } = tipo;

    public override string ToString()
    {
        return $"{Id} - {Nome} - {Tipo}";
    }
}
