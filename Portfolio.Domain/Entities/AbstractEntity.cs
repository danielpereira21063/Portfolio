namespace Portfolio.Domain.Entities
{
    public abstract class AbstractEntity
    {
        public int Id { get; protected set; }
        public DateTime DataCadastro { get; protected set; }

        public AbstractEntity()
        {
            if (DataCadastro == DateTime.MinValue)
            {
                DataCadastro = DateTime.Now;
            }
        }
    }
}
