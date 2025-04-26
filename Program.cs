using System;
using System.Collections.Generic;

class Tarefa
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }
}

class Program
{
    static List<Tarefa> tarefas = new List<Tarefa>();
    static int proximoId = 1;

    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("=== Gerenciador de Tarefas ===");
            Console.WriteLine("1. Adicionar tarefa");
            Console.WriteLine("2. Listar tarefas");
            Console.WriteLine("3. Marcar tarefa como concluída");
            Console.WriteLine("4. Remover tarefa");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarTarefa();
                    break;
                case "2":
                    ListarTarefas();
                    break;
                case "3":
                    ConcluirTarefa();
                    break;
                case "4":
                    RemoverTarefa();
                    break;
                case "5":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.\n");
                    break;
            }
        }
    }

    static void AdicionarTarefa()
    {
        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        Tarefa tarefa = new Tarefa
        {
            Id = proximoId++,
            Descricao = descricao,
            Concluida = false
        };

        tarefas.Add(tarefa);
        Console.WriteLine("Tarefa adicionada com sucesso!\n");
    }

    static void ListarTarefas()
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.\n");
            return;
        }

        Console.WriteLine("\nLista de Tarefas:");
        foreach (var tarefa in tarefas)
        {
            string status = tarefa.Concluida ? "Concluída" : "Pendente";
            Console.WriteLine($"ID: {tarefa.Id} | {tarefa.Descricao} | Status: {status}");
        }
        Console.WriteLine();
    }

    static void ConcluirTarefa()
    {
        ListarTarefas();
        Console.Write("Digite o ID da tarefa que deseja concluir: ");
        int id = int.Parse(Console.ReadLine());

        Tarefa tarefa = tarefas.Find(t => t.Id == id);

        if (tarefa == null)
        {
            Console.WriteLine("Tarefa não encontrada.\n");
            return;
        }

        tarefa.Concluida = true;
        Console.WriteLine("Tarefa marcada como concluída!\n");
    }

    static void RemoverTarefa()
    {
        ListarTarefas();
        Console.Write("Digite o ID da tarefa que deseja remover: ");
        int id = int.Parse(Console.ReadLine());

        Tarefa tarefa = tarefas.Find(t => t.Id == id);

        if (tarefa == null)
        {
            Console.WriteLine("Tarefa não encontrada.\n");
            return;
        }

        tarefas.Remove(tarefa);
        Console.WriteLine("Tarefa removida com sucesso!\n");
    }
}
