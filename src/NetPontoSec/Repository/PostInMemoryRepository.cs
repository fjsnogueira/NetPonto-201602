namespace NetPontoSec.Repository
{
    using System.Linq;
    using NetPontoSec.Models;

    public class PostInMemoryRepository : GenericRepository<Post>, IPostRepository
    {
        public PostInMemoryRepository()
            : base(InMemoryDatabase.Posts)
        {
            lock (InMemoryDatabase.Posts)
            {
                if (InMemoryDatabase.Posts.Any())
                {
                    return;
                }


                this.Context.Add(
                    new Post
                    {
                        Title = "Estratégias para um Novo Paradigma Globalizado",
                        Abstract =
                                "Não obstante, o surgimento do comércio virtual maximiza as possibilidades por conta de todos os recursos funcionais envolvidos. Pensando mais a longo prazo, o desafiador cenário globalizado cumpre um papel essencial na formulação do impacto na agilidade decisória. A certificação de metodologias que nos auxiliam a lidar com o comprometimento entre as equipes talvez venha a ressaltar a relatividade da gestão inovadora da qual fazemos parte. ",
                        Body =
                                "<p>Não obstante, o surgimento do comércio virtual maximiza as possibilidades por conta de todos os recursos funcionais envolvidos. Pensando mais a longo prazo, o desafiador cenário globalizado cumpre um papel essencial na formulação do impacto na agilidade decisória. A certificação de metodologias que nos auxiliam a lidar com o comprometimento entre as equipes talvez venha a ressaltar a relatividade da gestão inovadora da qual fazemos parte.</p> <p>No entanto, não podemos esquecer que o entendimento das metas propostas obstaculiza a apreciação da importância do fluxo de informações.É importante questionar o quanto o novo modelo estrutural aqui preconizado nos obriga à análise de alternativas às soluções ortodoxas.A prática cotidiana prova que a necessidade de renovação processual assume importantes posições no estabelecimento das condições inegavelmente apropriadas.Nunca é demais lembrar o peso e o significado destes problemas, uma vez que a execução dos pontos do programa facilita a criação do sistema de formação de quadros que corresponde às necessidades. Caros amigos, o desenvolvimento contínuo de distintas formas de atuação exige a precisão e a definição dos métodos utilizados na avaliação de resultados.</p>",
                        Id = 1,
                        AuthorId = 1,
                        AuthorName = "Alice",
                        Visits = 12
                    });

                this.Context.Add(
                    new Post
                    {
                        Title = "Oportunidades para Verificação",
                        Abstract =
                                "Nunca é demais lembrar o peso e o significado destes problemas, uma vez que o início da atividade geral de formação de atitudes oferece uma interessante oportunidade para verificação das formas de ação ",
                        Body =
                                "<p>Nunca é demais lembrar o peso e o significado destes problemas, uma vez que o início da atividade geral de formação de atitudes oferece uma interessante oportunidade para verificação das formas de ação.</p> <p>No entanto, não podemos esquecer que o entendimento das metas propostas obstaculiza a apreciação da importância do fluxo de informações.É importante questionar o quanto o novo modelo estrutural aqui preconizado nos obriga à análise de alternativas às soluções ortodoxas.A prática cotidiana prova que a necessidade de renovação processual assume importantes posições no estabelecimento das condições inegavelmente apropriadas.Nunca é demais lembrar o peso e o significado destes problemas, uma vez que a execução dos pontos do programa facilita a criação do sistema de formação de quadros que corresponde às necessidades. Caros amigos, o desenvolvimento contínuo de distintas formas de atuação exige a precisão e a definição dos métodos utilizados na avaliação de resultados.</p>",
                        Id = 2,
                        AuthorId = 2,
                        AuthorName = "Bob",
                        Visits = 42
                    });
            }
        }
    }
}
