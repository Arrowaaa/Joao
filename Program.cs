﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Program
    {
        static List<Produto> produtos = new List<Produto>();
        static double saldo = 0;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\r\n ____  _  ____  _____  _____ _      ____    ____  ____    ____  _____ _          _  ____  ____  ____ \r\n/ ___\\/ \\/ ___\\/__ __\\/  __// \\__/|/  _ \\  /  _ \\/  _ \\  / ___\\/  __// \\ /\\     / |/  _ \\/  _ \\/  _ \\\r\n|    \\| ||    \\  / \\  |  \\  | |\\/||| / \\|  | | \\|| / \\|  |    \\|  \\  | | ||     | || / \\|| / \\|| / \\|\r\n\\___ || |\\___ |  | |  |  /_ | |  ||| |-||  | |_/|| \\_/|  \\___ ||  /_ | \\_/|  /\\_| || \\_/|| |-||| \\_/|\r\n\\____/\\_/\\____/  \\_/  \\____\\\\_/  \\|\\_/ \\|  \\____/\\____/  \\____/\\____\\\\____/  \\____/\\____/\\_/ \\|\\____/\r\n                                                                                                     \r\n");
            

            while (true)
            {
                MostrarMenu();
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        VenderProduto();
                        break;
                    case 3:
                        ComprarProduto();
                        break;
                    case 4:
                        GerarRelatorio();
                        break;
                    case 5:
                        Environment.Exit(0); // Sair do programa
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nMENU: ");
            Console.WriteLine("\n 1 - Cadastrar novo Produto");
            Console.WriteLine(" 2 - Realizar venda de produto");
            Console.WriteLine(" 3 - Realizar compra de produto");
            Console.WriteLine(" 4 - Gerar relatório do produto");
            Console.WriteLine(" 5 - Sair do programa");
            Console.Write("\nEscolha a Opção: ");
            
        }

        static void CadastrarProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nCADASTRAR PRODUTO: ");

            Console.Write("\n Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("\n Marca do Produto: ");
            string marca = Console.ReadLine();

            Console.Write("\n Preço do Produto: ");
            double preco = double.Parse(Console.ReadLine());

            Console.Write("\n Quantidade do Produto: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto novoProduto = new Produto(nome, marca, preco, quantidade);
            produtos.Add(novoProduto);

            Console.WriteLine("\n Produto cadastrado com sucesso!");
            
        }
        

        static void VenderProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("VENDER PRODUTO: ");

            Console.WriteLine("\n Lista de Produtos Disponíveis:");
            ListarProdutos();

            Console.Write("\n Escolha o número do produto a ser vendido: ");
            int escolha = int.Parse(Console.ReadLine()) - 1;

            if (escolha >= 0 && escolha < produtos.Count)
            {
                Produto produto = produtos[escolha];
                Console.Write("\nQuantidade de " + produto.Nome + " a ser vendida: ");
                int quantidadeVendida = int.Parse(Console.ReadLine());

                if (quantidadeVendida <= produto.Quantidade)
                {
                    double valorTotal = quantidadeVendida * produto.Preco;
                    Console.WriteLine("\nTotal a pagar: R$ " + valorTotal);

                    Console.Write("\n Digite o valor pago: ");
                    double valorPago = double.Parse(Console.ReadLine());

                    if (valorPago >= valorTotal)
                    {
                        double troco = valorPago - valorTotal;
                        Console.WriteLine("Troco: R$ " + troco);

                        produto.Quantidade -= quantidadeVendida; // Atualizar estoque
                        saldo += valorTotal; // Atualizar saldo
                        Console.WriteLine("Venda concluída com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Valor insuficiente para a compra.");
                    }
                }
                else
                {
                    Console.WriteLine($"Quantidade insuficiente de {produto.Nome} em estoque.");
                }
            }
            else
            {
                Console.WriteLine("\nProduto não encontrado.");
            }
            
        }

        static void ComprarProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n COMPRAR PRODUTO: ");

            Console.Write("\n Valor da compra: R$ ");
            double valorCompra = double.Parse(Console.ReadLine());

            saldo -= valorCompra; // Atualizar saldo
            Console.WriteLine("\n Compra realizada com sucesso!");
        }

        static void GerarRelatorio()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n RELATÓRIO DE PRODUTOS: ");
            ListarProdutos();

            Console.WriteLine("\n Saldo Total: R$ " + saldo);
        }

        static void ListarProdutos()
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + produtos[i].Nome + " - Marca: " + produtos[i].Marca + " - Preço: R$ " + produtos[i].Preco.ToString("F2") + " - Estoque: " + produtos[i].Quantidade);

            }
        }
    }

    class Produto
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto(string nome, string marca, double preco, int quantidade)
        {
            Nome = nome;
            Marca = marca;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}
