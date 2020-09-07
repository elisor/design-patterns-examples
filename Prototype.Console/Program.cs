using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Console
{
    /// <summary>

    /// MainApp startup class for Real-World 

    /// Prototype Design Pattern.
    /// https://www.dofactory.com/net/prototype-design-pattern#realworld
    /// https://refactoring.guru/pt-br/design-patterns/prototype
    /// https://medium.com/@gbbigardi/arquitetura-e-desenvolvimento-de-software-parte-5-prototype-f010238fbf48
    /// Objetivo / intenção: Permitir a criação de novos objetos a partir de um modelo original, ou como o próprio nome indica, um protótipo, que é clonado;
    /// Motivação: Evitar que as subclasses que criam objetos funcionem como o padrão Abstract Factory ou mesmo evitar criar um novo objeto utilizando a palavra new, o que diminui o custo de memória;
    /// Aplicabilidade: O padrão Prototype é aplicado quando existe a necessidade de clonar, literalmente, um objeto. Ou seja, quando a aplicação precisa criar cópias exatas de algum objeto em tempo de execução este padrão é altamente recomendado. Este padrão pode ser utilizado em sistemas que precisam ser independentes da forma como os seus componentes são criados, compostos e representados;
    /// Consequências: Prototype facilita bastante quando temos classes que precisam simplesmente serem clonadas de forma livre e que definam seu comportamento em runtime, mas exige a implementação de uma operação de clonagem em cada uma das classes concretas do protótipo. Esta tarefa pode ser inconveniente, no caso do reaproveitamento de classes preexistentes que não possuem tal operação, ou mesmo complexa, se for considerada a possibilidade de existirem referências circulares nos atributos de um objeto;
    /// Usos conhecidos: Quando utilizamos o Spring framework, por exemplo, um desenvolvedor pode configurar um Bean como “Prototype”. Esta configuração faz com que cada uma das referências a um Bean aponte para uma instância diferente. O comportamento padrão, ou Singleton, define que todas as referências a um Bean apontem para a mesma instância de uma classe.
    /// Este foi o padrão Prototype. Ele é bem útil em sistemas que precisamos clonar livremente os objetos e que suas definições sejam feitas em runtime. Na próxima parte desta série, vamos abordar o padrão Singleton, o último do grupo de criacionais.
    /// </summary>

    class Program

    {
        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            ColorManager colormanager = new ColorManager();

            // Initialize with standard colors

            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors

            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User clones selected colors

            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;

            // Wait for user

            System.Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'Prototype' abstract class

    /// </summary>

    abstract class ColorPrototype

    {
        public abstract ColorPrototype Clone();
    }

    /// <summary>

    /// The 'ConcretePrototype' class

    /// </summary>

    class Color : ColorPrototype

    {
        private int _red;
        private int _green;
        private int _blue;

        // Constructor

        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Create a shallow copy

        public override ColorPrototype Clone()
        {
            System.Console.WriteLine(
              "Cloning color RGB: {0,3},{1,3},{2,3}",
              _red, _green, _blue);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    /// <summary>

    /// Prototype manager

    /// </summary>

    class ColorManager

    {
        private Dictionary<string, ColorPrototype> _colors =
          new Dictionary<string, ColorPrototype>();

        // Indexer

        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}
