using Agenda.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Models;
using MySql.Data.MySqlClient;

namespace Agenda.Services
{
    public class AgendaService
    {
        private readonly AppDbContext _context;

        public AgendaService(AppDbContext context)
        {
            _context = context;
        }

        public List<Pessoa> Buscar()
        {
            List<Pessoa> agendas = new List<Pessoa>();
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select * from agendas";
            command.CommandType = CommandType.Text;

            var result = command.ExecuteReader();

            while (result.Read())
            {
                agendas.Add(new Pessoa
                {
                    Id = Convert.ToInt32(result["id"]),
                    Nome = result["nome"].ToString(),
                    Telefone = result["telefone"].ToString(),
                    Logradouro = result["logradouro"].ToString(),
                    Numero = result["numero"].ToString(),
                    Bairro = result["bairro"].ToString(),
                    Cidade = result["cidade"].ToString(),
                });
            }
            result.Close();
            command.Connection.Close();

            return agendas;
        }

        public Pessoa BuscarPorId(int id)
        {
            Pessoa agenda = new Pessoa();
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "select * from agendas where id=@Id";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new MySqlParameter("@Id",id));

            var result = command.ExecuteReader();

            while (result.Read())
            {
                agenda.Id = Convert.ToInt32(result["id"]);
                agenda.Nome = result["nome"].ToString();
                agenda.Telefone = result["telefone"].ToString();
                agenda.Logradouro = result["logradouro"].ToString();
                agenda.Numero = result["numero"].ToString();
                agenda.Bairro = result["bairro"].ToString();
                agenda.Cidade = result["cidade"].ToString();
            }
            result.Close();
            command.Connection.Close();

            return agenda;
        }

        public void Salvar(Pessoa pessoa)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "insert into agendas(nome,telefone,logradouro,numero,bairro,cidade) " +
                "values (@Nome,@Telefone,@Logradouro,@Numero,@Bairro,@Cidade)";
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new MySqlParameter("@Nome", pessoa.Nome));
            command.Parameters.Add(new MySqlParameter("@Telefone", pessoa.Telefone));
            command.Parameters.Add(new MySqlParameter("@Logradouro", pessoa.Logradouro));
            command.Parameters.Add(new MySqlParameter("@Numero", pessoa.Numero));
            command.Parameters.Add(new MySqlParameter("@Bairro", pessoa.Bairro));
            command.Parameters.Add(new MySqlParameter("@Cidade", pessoa.Cidade));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void Update(Pessoa pessoa)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "update agendas set nome=@Nome,telefone=@Telefone," +
                "logradouro=@Logradouro,numero=@Numero,bairro=@Bairro,cidade=@Cidade where " +
                "id=@Id";
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new MySqlParameter("@Id", pessoa.Id));
            command.Parameters.Add(new MySqlParameter("@Nome", pessoa.Nome));
            command.Parameters.Add(new MySqlParameter("@Telefone", pessoa.Telefone));
            command.Parameters.Add(new MySqlParameter("@Logradouro", pessoa.Logradouro));
            command.Parameters.Add(new MySqlParameter("@Numero", pessoa.Numero));
            command.Parameters.Add(new MySqlParameter("@Bairro", pessoa.Bairro));
            command.Parameters.Add(new MySqlParameter("@Cidade", pessoa.Cidade));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void Delete(int id)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.Connection.Open();
            command.CommandText = "delete from agendas where id=@Id";
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new MySqlParameter("@Id", id));

            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
