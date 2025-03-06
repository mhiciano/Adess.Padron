namespace Adess.Padron.Domain.Models;

public class Cedula
{
    public Cedula(string cedula)
    {
        if (cedula == null || cedula.Length != 11) throw new ArgumentNullException(string.Format("Las cedula {0} no tiene el formato correcto", cedula));

        MunCed = cedula.Substring(0,3);
        SeqCed = cedula.Substring(3,7);
        VerCed = cedula.Substring (10,1);
    }

    public string MunCed { get; set; }
    public string SeqCed { get; set; }
    public string VerCed { get; set; }
    public string NumeroCedula => MunCed + SeqCed + VerCed;
}
