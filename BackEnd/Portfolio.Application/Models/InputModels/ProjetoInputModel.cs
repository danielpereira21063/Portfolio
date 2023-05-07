namespace Portfolio.Application.Models.InputModels
{
    public class ProjetoInputModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public string UrlGitHub { get; set; }
        public bool Inativo { get; set; }
    }
}
