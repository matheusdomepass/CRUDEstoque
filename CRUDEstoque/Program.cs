using System;
using System.Collections.Generic;

class EstoqueItem
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

class Estoque
{
    private List<EstoqueItem> itens = new List<EstoqueItem>();
    private int proximoId = 1;

    public void AdicionarItem(string nome)
    {
        var item = new EstoqueItem { Id = proximoId++, Nome = nome };
        itens.Add(item);
        Console.WriteLine("Item adicionado ao estoque.");
    }

    public void ListarItens()
    {
        if (itens.Count > 0)
        {
            Console.WriteLine("Lista de Itens no Estoque:");
            foreach (var item in itens)
            {
                Console.WriteLine($"ID: {item.Id}, Nome: {item.Nome}");
            }
        }
        else
        {
            Console.WriteLine("O estoque está vazio.");
        }
    }

    public void AtualizarItem(int id, string novoNome)
    {
        var item = itens.Find(i => i.Id == id);
        if (item != null)
        {
            item.Nome = novoNome;
            Console.WriteLine("Item atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine("Item não encontrado.");
        }
    }

    public void DeletarItem(int id)
    {
        var item = itens.Find(i => i.Id == id);
        if (item != null)
        {
            itens.Remove(item);
            Console.WriteLine("Item deletado do estoque.");
        }
        else
        {
            Console.WriteLine("Item não encontrado.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Estoque estoque = new Estoque();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Adicionar Item");
            Console.WriteLine("2. Listar Itens");
            Console.WriteLine("3. Atualizar Item");
            Console.WriteLine("4. Deletar Item");
            Console.WriteLine("5. Sair");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome do item a ser adicionado: ");
                    string nomeAdicionar = Console.ReadLine();
                    estoque.AdicionarItem(nomeAdicionar);
                    break;
                case "2":
                    estoque.ListarItens();
                    break;
                case "3":
                    Console.Write("Digite o ID do item a ser atualizado: ");
                    int idAtualizar = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Digite o novo nome do item: ");
                    string novoNome = Console.ReadLine();
                    estoque.AtualizarItem(idAtualizar, novoNome);
                    break;
                case "4":
                    Console.Write("Digite o ID do item a ser deletado: ");
                    int idDeletar = Convert.ToInt32(Console.ReadLine());
                    estoque.DeletarItem(idDeletar);
                    break;
                case "5":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }
}
