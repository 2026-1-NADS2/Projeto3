namespace POO1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HermesDB banco = new HermesDB(@"..\..\..\BancoPi.db");

            Fornecedor forn = new Fornecedor($"teste", "teste123", "teste@gmail.com", 12345678000101);
            banco.InsertForn(forn);
            forn.MkAnuncio("Banana","Caixos de banana","Fruta","Bananal",10,"São Paulo","15 dias","Bananal@gmail.com", banco);

            Comprador comp = new Comprador($"teste", "teste123", "teste@gmail.com", 12345678000101, 100);
            banco.InsertComp(comp);
        }
    }
}
