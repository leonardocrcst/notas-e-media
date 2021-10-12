using System;

namespace revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[3];
            int cadastrados = 0;
            string resposta;
            do
            {
                resposta = MenuUsuario(cadastrados);
                switch (resposta)
                {
                    case "1":
                        if (cadastrados < 3)
                        {
                            Aluno aluno = new Aluno();
                            Console.Write("Nome do aluno: ");
                            aluno.Nome = Console.ReadLine();
                            Console.Write("Nota: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                            {
                                aluno.Nota = nota;
                                alunos[cadastrados] = aluno;
                                cadastrados++;
                            }
                            else
                            {
                                Console.Write("Nota inválida. Você deverá repetir o processo informando uma nota válida (entre 0.00 e 10.00)");
                            }
                        }
                        break;
                    case "2":
                        foreach (Aluno a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                string conc = Program.RecuperaConceito(a.Nota).ToString();
                                Console.WriteLine($"{a.Nome}. Nota: {a.Nota} ({conc})");
                            }
                        }
                        break;
                    case "3":
                        if (cadastrados > 0)
                        {
                            decimal total = 0;
                            decimal media = 0;
                            for (int i = 0; i < alunos.Length; i++)
                            {
                                if (!string.IsNullOrEmpty(alunos[i].Nome))
                                {
                                    total += alunos[i].Nota;
                                }
                            }
                            media = total / cadastrados;
                            Console.WriteLine($"Média da classe: {media}");
                        }
                        else
                        {
                            Console.WriteLine("Não existem alunos cadastrados");
                        }
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "X":
                        Console.WriteLine("Até a próxima!");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (resposta != "X");
        }

        private static string MenuUsuario(int total)
        {
            string resposta;
            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine("|     Meus alunos      |");
            Console.WriteLine("------------------------");
            Console.WriteLine("1 - Cadastrar aluno");
            Console.WriteLine($"2 - Listar alunos ({total})");
            Console.WriteLine("3 - Média geral");
            Console.WriteLine("4 - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");
            Console.Write("O que você deseja fazer? ");
            resposta = Console.ReadLine();
            return resposta.ToUpper();
        }

        private static Conceito RecuperaConceito(decimal nota)
        {
            Conceito retorno;
            switch (nota)
            {
                case decimal d when (d <= 3):
                    retorno = Conceito.E;
                    break;
                case decimal d when (d > 3 && d <= 5):
                    retorno = Conceito.D;
                    break;
                case decimal d when (d > 5 && d <= 7):
                    retorno = Conceito.C;
                    break;
                case decimal d when (d > 7 && d <= 9):
                    retorno = Conceito.B;
                    break;
                default:
                    retorno = Conceito.A;
                    break;
            }
            return retorno;
        }
    }
}
