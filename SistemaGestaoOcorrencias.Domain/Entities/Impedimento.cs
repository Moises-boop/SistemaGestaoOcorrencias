namespace SistemaGestaoOcorrencias.Domain.Entities;

public class Impedimento
{
    public string Tipo {get;}
    public DateTime DataRegistro {get;}
    public bool Resolvido {get; private set;}
    public DateTime? DataResolucao {get; private set;}

    public Impedimento (string tipo)
    {
        Tipo = string.IsNullOrEmpty(tipo) ? throw new ArgumentException ("O tipo do impedimento não pode ser nulo em branco") : tipo;
        DataRegistro = DateTime.Now();
        Resolvido = false;
    }

    public void Resolver()
    {
        if (Resolvido == true)
            throw new ArgumentException ("O impedimento já foi resolvido");
        Resolvido = true;
        DataResolucao = DateTime.Now();
    }

    public bool ImpedimentoAtivo()
    {
        if (Resolvido)
            return false;
            
        return true;
    }


}