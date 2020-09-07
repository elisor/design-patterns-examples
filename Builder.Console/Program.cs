using System;
using System.Collections.Generic;

namespace Builder.Console
{
    /// <summary>

    /// MainApp startup class for Structural

    /// Builder Design Pattern.

    /// https://medium.com/@gbbigardi/arquitetura-e-desenvolvimento-de-software-parte-4-builder-848867107f71
    /// https://www.dofactory.com/net/builder-design-pattern
    /// Objetivo / intenção: Separar a lógica de construção de nossos objetos, toda esta complexidade, dos mesmos, permitindo que esse processo de construção possa criar diferentes implementações;
    /// Motivação: A criação do objeto talvez seja complexa e precise de uma quantidade de código significativa, deixando a representação do mesmo um pouco extensa e difícil de manter. Com isso, criamos outro tipo de objeto, responsável por construir nossos objetos, isolando esta complexidade de sua representação final, e sempre que possível, programando para interfaces, tanto para o builder como para o objeto a ser criado.
    /// Aplicabilidade: Este padrão é muito utilizado quando desejamos, além de isolar a complexidade de criação de nossos objetos, criar diferentes implementações, baseadas em uma interface comum. Isto pode ser feito de diversas maneiras, seja possuindo diversas implementações de uma interface de builder ou mesmo recebendo parâmetros na construção deste builder, que serão utilizados no método build(), geralmente usado para criar nossos objetos finais.
    /// Estrutura: Abaixo temos um exemplo de estrutura onde temos um classe mais a ponta, a Director, que é responsável por chamar o método de construção do Builder, este que é uma interface, com suas implementações especializadas, como no caso o ConcreteBuilder, que possui em sua implementação a lógica para construir nossa classe final, a Product;
    /// Consequências: Conseguimos variar a representação interna de um produto, encapsular e separar o código da construção e da representação de objetos e maior controle no processo de construção, mas em contrapartida, temos que instanciar um ConcreteBuilder específico para cada tipo de objeto que queremos produzir, seja através de diferentes implementações ou de seus argumentos de instanciação.

    /// </summary>

    public class Program

    {
        /// <summary>

        /// Entry point into console application.

        /// </summary>

        public static void Main()
        {
            // Create director and builders

            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // Construct two products

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            // Wait for user

            System.Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'Director' class

    /// </summary>

    class Director

    {
        // Builder uses a complex series of steps

        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    /// <summary>

    /// The 'Builder' abstract class

    /// </summary>

    abstract class Builder

    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    /// <summary>

    /// The 'ConcreteBuilder1' class

    /// </summary>

    class ConcreteBuilder1 : Builder

    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("PartA");
        }

        public override void BuildPartB()
        {
            _product.Add("PartB");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    /// <summary>

    /// The 'ConcreteBuilder2' class

    /// </summary>

    class ConcreteBuilder2 : Builder

    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("PartX");
        }

        public override void BuildPartB()
        {
            _product.Add("PartY");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    /// <summary>

    /// The 'Product' class

    /// </summary>

    class Product

    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            System.Console.WriteLine("\nProduct Parts -------");
            foreach (string part in _parts)
                System.Console.WriteLine(part);
        }
    }
}