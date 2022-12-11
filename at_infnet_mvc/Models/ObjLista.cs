namespace at_infnet_mvc.Models
{
    public class ObjLista
    {
        
        public List<Pessoa> AninversariantesDoDia { get; set; }
        public List<Pessoa> ListaOrdenada { get; set; }

        public ObjLista(List<Pessoa> aniversariantesDoDia, List<Pessoa> listaOrdenada)
        {
            this.AninversariantesDoDia = aniversariantesDoDia;
            this.ListaOrdenada = listaOrdenada;
        }
    }
}
