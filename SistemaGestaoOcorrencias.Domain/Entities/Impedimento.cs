using SistemaGestaoOcorrencias.Domain.Enums;

namespace SistemaGestaoOcorrencias.Domain.Entities;

public class Impedimento
{
    public TipoImpedimento Tipo {get;}
    public DateTime DataRegistro {get;}
    public bool Resolvido {get; private set;}
    public DateTime? DataResolucao {get; private set;}

    public Impedimento (TipoImpedimento tipo)
    {
        Tipo = tipo;
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
