namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            { 
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                
                throw new Exception("Capacidade máxima de hóspedes excedida.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Verifica se a suíte e os dias reservados estão devidamente configurados
            if (Suite == null || DiasReservados <= 0)
            {
                throw new InvalidOperationException("Suite ou DiasReservados não estão configurados corretamente.");
            }

            // Cálculo básico: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplicação do desconto de 10% para 10 ou mais dias reservados
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica o desconto (90% do valor original)
            }

            return valor;
        }
    }
}