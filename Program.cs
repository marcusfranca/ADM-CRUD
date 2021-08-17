using System;

namespace C_
{
    class Program
    {
        static void Main(string[] args)
        {
            byte op;
             
            do {
                Console.WriteLine("\nBIG DATABASE: 1 - Inserir | 2 - Selecionar todos  | 3 - Selecionar por Id| 4 - deletar tabela | 5 - deletar por id | 6 - atualizar dados | 0 - Sair do Banco \n");
                Console.Write("Escolha >>> ");
                op = byte.Parse(Console.ReadLine());

                DatabaseCommands dc = new DatabaseCommands();
                dc.conectionDatabase();


                switch (op)
                {
                    case 0:
                    {
                        Console.WriteLine("Saindo...");
                        break;
                    }
                    case 1:
                        {
                            Console.WriteLine("Insira Usuário: ");
                            string usuario = Console.ReadLine();

                            Console.WriteLine("Insira Senha: ");
                            string senha = Console.ReadLine();

                            dc.setUserDatabase(usuario, senha);
                            Console.WriteLine("------ DATABASE -------------------");
                            dc.selectAllUserDatabase();
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Usuário inserido no banco de dados");
                            break;
                        }

                    case 2:
                        {
                            dc.selectAllUserDatabase();
                            Console.WriteLine("Usuários selecionados com sucesso!");
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Digite o id do usuário: " + "\n");
                            int id = int.Parse(Console.ReadLine());
                            dc.selectByIdUserDatabase(id);
                            Console.WriteLine("Usuário selecionado com sucesso!");
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("------ DATABASE -------------------");
                            dc.selectAllUserDatabase();
                            Console.WriteLine("-----------------------------------");
                            
                            Console.WriteLine("Você tem certeza que quer deletar a tabela inteira? (S/N) ");
                            string resposta = Console.ReadLine();
                            
                            if(resposta == "S" || resposta == "s") {
                                dc.deteleUserDatabase();
                                Console.WriteLine("Tabela deletada com sucesso!");
                            } else {
                                Console.WriteLine("OK, tabela não excluída.");
                            }

                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("------ DATABASE -------------------");
                            dc.selectAllUserDatabase();
                            Console.WriteLine("-----------------------------------");

                            Console.WriteLine("\nDigite o id do usuário: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Você tem certeza que quer deletar o(a) usuário(a)? (S/N) ");
                            string resposta = Console.ReadLine();
                            if(resposta == "S" || resposta == "s") {
                                dc.deleteByIdDatabase(id);
                                Console.WriteLine("Usuário deletado com sucesso!");
                            } else {
                                Console.WriteLine("OK, usuário(a) não excluído(a).");
                            }
                
                            break;
                        }
                    case 6:
                    {
                        Console.WriteLine("------ DATABASE -------------------");
                        dc.selectAllUserDatabase();
                        Console.WriteLine("-----------------------------------");
                       
                        Console.WriteLine("Insira o id de qual usuário que será atualizado");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira um novo Usuário: ");
                        string usuario = Console.ReadLine();
                        Console.WriteLine("Insira uma novo Senha: ");
                        string senha = Console.ReadLine();

                        Console.WriteLine("Você tem certeza que quer alterar os dados usuário(a) e senha? (S/N) ");
                        string resposta = Console.ReadLine();
                        if(resposta == "s" || resposta == "S") {
                            dc.updateByIdDatabase(id, usuario, senha);
                            Console.WriteLine("Dados atualizados com sucesso!");
                        } else {
                            Console.WriteLine("OK, dado do(a) usuário(a) não alterado.");   
                        }
                        
                        break;
                    }
                }
            } while(op != 0);           
        }
    }
}
