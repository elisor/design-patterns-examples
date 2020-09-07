using System;

namespace Abstract.Factory.Console
{
    class Program
    {
        /// <summary>

        /// MainApp startup class for Real-World

        /// Abstract Factory Design Pattern.
        /// https://medium.com/@gbbigardi/arquitetura-e-desenvolvimento-de-software-parte-2-abstract-factory-f603ccc6a1ea
        /// </summary>
        /// 
        /// Entendendo diferença entre classe Abstrata e Interface
        /// https://pt.stackoverflow.com/questions/3603/classe-abstrata-x-interface
        /// Objetivo / intenção: Permite a criação de famílias de objetos relacionados ou dependentes por meio de uma única interface e sem que a classe concreta seja especificada. Também é conhecido como Kit;
        /// Motivação: O objetivo em empregar o padrão é isolar a criação de objetos de seu uso e criar famílias de objetos relacionados sem ter que depender de suas classes concretas. Isto permite novos tipos derivados de ser introduzidas sem qualquer alteração ao código que usa a classe base;
        /// Aplicabilidade: Cenários onde uma família de produtos ou classes precisa ser instanciado, sem dependência de suas classes concretas, como no exemplo do livro, onde você tem elementos visuais(produtos), como Window, ScrollBar, Menu e etc.Esses elementos visuais têm diferentes implementações para cada família de implementação gráfica, como o Microsoft Windows, o MAC, e X do Linux;
        /// Consequências: Temos a vantagem de utilizamos apenas classes abstratas ou interfaces, o que diminui muito o acoplamento entre as classes do sistema, assim como podemos adicionar, modificar ou remover produtos da família de forma rápida. Mas temos como ponto negativo que a adição ou remoção de famílias exige a modificação da AbstractFactory, o que causa um grande overhead, pois deve-se modificar todas as implementações da Factory e o cliente que usa a AbstractFactory;


        class Program

        {
            /// <summary>

            /// Entry point into console application.

            /// </summary>

            public static void Main()
            {
                // Create and run the African animal world

                ContinentFactory africa = new AfricaFactory();
                AnimalWorld world = new AnimalWorld(africa);
                world.RunFoodChain();

                // Create and run the American animal world

                ContinentFactory america = new AmericaFactory();
                world = new AnimalWorld(america);
                world.RunFoodChain();

                // Wait for user input

                System.Console.ReadKey();
            }
        }


        /// <summary>

        /// The 'AbstractFactory' abstract class

        /// </summary>

        abstract class ContinentFactory

        {
            public abstract Herbivore CreateHerbivore();
            public abstract Carnivore CreateCarnivore();
        }

        /// <summary>

        /// The 'ConcreteFactory1' class

        /// </summary>

        class AfricaFactory : ContinentFactory

        {
            public override Herbivore CreateHerbivore()
            {
                return new Wildebeest();
            }
            public override Carnivore CreateCarnivore()
            {
                return new Lion();
            }
        }

        /// <summary>

        /// The 'ConcreteFactory2' class

        /// </summary>

        class AmericaFactory : ContinentFactory

        {
            public override Herbivore CreateHerbivore()
            {
                return new Bison();
            }
            public override Carnivore CreateCarnivore()
            {
                return new Wolf();
            }
        }

        /// <summary>

        /// The 'AbstractProductA' abstract class

        /// </summary>

        abstract class Herbivore

        {
        }

        /// <summary>

        /// The 'AbstractProductB' abstract class

        /// </summary>

        abstract class Carnivore

        {
            public abstract void Eat(Herbivore h);
        }

        /// <summary>

        /// The 'ProductA1' class

        /// </summary>

        class Wildebeest : Herbivore

        {
        }

        /// <summary>

        /// The 'ProductB1' class

        /// </summary>

        class Lion : Carnivore

        {
            public override void Eat(Herbivore h)
            {
                // Eat Wildebeest

                System.Console.WriteLine(this.GetType().Name +
                  " eats " + h.GetType().Name);
            }
        }

        /// <summary>

        /// The 'ProductA2' class

        /// </summary>

        class Bison : Herbivore

        {
        }

        /// <summary>

        /// The 'ProductB2' class

        /// </summary>

        class Wolf : Carnivore

        {
            public override void Eat(Herbivore h)
            {
                // Eat Bison

                System.Console.WriteLine(this.GetType().Name +
                  " eats " + h.GetType().Name);
            }
        }

        /// <summary>

        /// The 'Client' class 

        /// </summary>

        class AnimalWorld

        {
            private Herbivore _herbivore;
            private Carnivore _carnivore;

            // Constructor

            public AnimalWorld(ContinentFactory factory)
            {
                _carnivore = factory.CreateCarnivore();
                _herbivore = factory.CreateHerbivore();
            }

            public void RunFoodChain()
            {
                _carnivore.Eat(_herbivore);
            }
        }
    }
}
