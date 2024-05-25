namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa, escolha = string.Empty;
            while(true){
                Console.WriteLine(">> Digite a placa do veículo para estacionar: ");
                placa = Console.ReadLine();
                veiculos.Add(placa.ToUpper());

                Console.WriteLine("Deseja cadastrar mais algum veículo? [S/N]?");
                escolha = Console.ReadLine().ToUpper();
                
                if(string.IsNullOrEmpty(escolha) || escolha[0] != 'S'){
                    break;
                }
            }
        }

        public void RemoverVeiculo()
        {
            ListarVeiculos();
            Console.WriteLine(">> Digite a placa do veículo para remover:");

            string placa = string.Empty;
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine(">> Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                horas =  Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = 0; 
                valorTotal = precoInicial + (horas * precoPorHora);
                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("\nOs veículos estacionados são:");

                foreach(string veiculo in veiculos){
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
