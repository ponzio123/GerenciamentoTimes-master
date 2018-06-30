namespace FutebolModelBiblioteca.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FutebolModelBiblioteca.ModelFutebol>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FutebolModelBiblioteca.ModelFutebol context)
        {
            if (true)
            {
                context.Jogadores.RemoveRange(context.Jogadores);
                context.Times.RemoveRange(context.Times);
                context.SaveChanges();
            }
            Time t = new Time() { Nome = "Flamengo", DataFundacao = new DateTime(1903, 11, 15) };
            Time t2 = new Time() { Nome = "Coritiba", DataFundacao = new DateTime(1909, 10, 12) };
            Time t3 = new Time() { Nome = "Atletico Paranaense", DataFundacao = new DateTime(1924, 03, 12) };
            t.Jogadores.Add(new Jogador() { Nome = "Paquetá", Numero = 11, Nascimento = new DateTime(1995,12,12) });
            t.Jogadores.Add(new Jogador() { Nome = "Diego", Numero = 10, Nascimento = new DateTime(1989, 11, 12) });
            t2.Jogadores.Add(new Jogador() { Nome = "Alecsandro", Numero = 9, Nascimento = new DateTime(1991, 9, 12) });
            t2.Jogadores.Add(new Jogador() { Nome = "Kleber", Numero = 83, Nascimento = new DateTime(1995, 8, 12) });
            t3.Jogadores.Add(new Jogador() { Nome = "Bergson", Numero = 30, Nascimento = new DateTime(1990, 5, 12) });
            t3.Jogadores.Add(new Jogador() { Nome = "Guilherme", Numero = 17, Nascimento = new DateTime(1999, 2, 12) });
            context.Times.Add(t);
            context.Times.Add(t2);
            context.Times.Add(t3);
            context.SaveChanges();
        }
    }
}
