using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev_week_Pottencial.src.Models
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string name, int idade, int cpf, bool ativado = true)
        {
            this.Name = name;
            this.Idade = idade;
            this.Cpf = cpf;
            this.Ativado = _ativado;
            this.Contratos = new List<Contracts>();
        }
        private string _name;
        private int _idade;

        private int _cpf;

        private bool _ativado;

        private List<Contracts> _contratos;
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string Name {  
            get { return _name; }
            set { _name = value; } 
        }
        public int Idade
        {
            get { return _idade; }
            set { _idade = value; }
        }
        public int Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public bool Ativado
        {
            get { return _ativado; }
            set { _ativado = value; }
        }
        
      
        public List<Contracts> Contratos
        {
            get { return _contratos; }
            set { _contratos = value; }
        }
    }
}