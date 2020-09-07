using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Console
{
    /// <summary>

    /// MainApp startup class for Real-World 

    /// Singleton Design Pattern.

    /// </summary>

    class Program

    {
        /// <summary>

        /// Entry point into System.Console application.
        /// https://www.dofactory.com/net/singleton-design-pattern#realworld
        /// https://refactoring.guru/pt-br/design-patterns/singleton
        /// </summary>

        static void Main()
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                System.Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                System.Console.WriteLine("Dispatch Request to: " + server);
            }

            // Wait for user

            System.Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'Singleton' class

    /// </summary>

    class LoadBalancer

    {
        private static LoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();

        // Lock synchronization object

        private static object syncLock = new object();

        // Constructor (protected)

        protected LoadBalancer()
        {
            // List of available servers

            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through

            // 'Double checked locking' pattern which (once

            // the instance exists) avoids locking each

            // time the method is invoked

            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }

            return _instance;
        }

        // Simple, but effective random load balancer

        public string Server
        {
            get

            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }
}
