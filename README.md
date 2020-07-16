# Návod

Tento repositář obsahuje testovací data pro má školení. Projekt má podobu NuGet balíčku:

    https://www.nuget.org/packages/Holec.SkoleniUtils

Samotný NuGet balíček má několik závislostí, které se automaticky resolvují.

- Entity Framework Core - výchozí ORM
- Entity Framework Core Sqlite - jednoduchá databáze pro testování
- Entity Framework Core Proxies - lazy loading, aby studenti nemuseli řešit záležitosti kolem EF



## Zapojení do projektu

**Přidejte NuGet balíček Holec.SkoleniUtils**

Zaregistrujte třídu UnitOfWork, která bude poskytovat data pro aplikaci. Stačí v souboru **Startup.cs** a metodě **ConfigureServices** přidat nový řádek:


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabase();
        //.... zbytek nastavení
    }

Spusťte seedování dat, abyste měli výchozí data pro testování. To provedete opět ve **Startup.cs** a metodě **Configure**:


    public void ConfigureServices(IServiceCollection services, UnitOfWork uow)
    {
        uow.Seed();
        //.... zbytek nastavení
    }

