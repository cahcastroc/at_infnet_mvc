using at_infnet_mvc.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace at_infnet_mvc.Service
{
    public class PessoaService
    {
        public readonly ModelContext db;

        public PessoaService(ModelContext db)
        {
            this.db = db;
        }

        public List<Pessoa> ListaPessoas()
        {
            return db.pessoas.ToList();
        }

     
        public List<Pessoa> BuscaPessoa(string nome) {

            return db.pessoas.Where(p => p.Nome.Contains(nome)).ToList();
        }

        public void AdicionaPessoa(Pessoa pessoa) {

            db.pessoas.Add(pessoa);
            db.SaveChanges();
        }
        
        public Pessoa BuscaPessoaId(int id) {
            
            Pessoa pessoa = db.pessoas.First(p => p.Id == id);
            if (pessoa == null)
            {
                return null;
            }
            return pessoa;
        }

        public void EditaPessoa(Pessoa pessoa) {

            
            db.Entry(pessoa).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void DeletaPessoa(Pessoa pessoa) {
            
                db.pessoas.Remove(pessoa);
                db.SaveChanges();                
        }

        public List<Pessoa> AniversariantesDoDia()
        {
            return db.pessoas.Where(p => p.Aniversario.Day == DateTime.Now.Day && p.Aniversario.Month == DateTime.Now.Month).ToList();
        }
        public List<Pessoa> OrdenacaoAniversarios()
        {

            return db.pessoas.AsEnumerable().OrderBy(p =>
             {
                 var ordemAniversario = new DateTime(DateTime.Today.Year, p.Aniversario.Month, p.Aniversario.Day);
                 if (DateTime.Today.Month > p.Aniversario.Month)
                 {
                     ordemAniversario = new DateTime(DateTime.Today.Year + 1, p.Aniversario.Month, p.Aniversario.Day);
                 }
                 if (DateTime.Today.Month == p.Aniversario.Month && DateTime.Today.Day > p.Aniversario.Day)
                 {
                     ordemAniversario = ordemAniversario.AddYears(1);
                 }
                 return ordemAniversario.Subtract(DateTime.Today).TotalDays;
             }).ToList();
        }        

    }
}
