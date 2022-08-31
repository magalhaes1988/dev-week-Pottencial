using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev_week_Pottencial.src.Models
{
    public class Person
    {
        private string _name;
        private int _idade;

        private int _cpf;

        private bool _ativado;

        private List<Contracts> _contratos;



        public bool Ativado
        {
            get { return _ativado; }
            set { _ativado = value; }
        }

        public Person()
        {
            this._name = "";
            this._idade = 0;
            this.Contratos = new List<Contracts>();
        }


        public int Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }



        public int Idade
        {
            get { return _idade; }
            set { _idade = value; }
        }


        public string Name { get => _name; set => _name = value; }
        public List<Contracts> Contratos
        {
            get { return _contratos; }
            set { _contratos = value; }
        }
    }
}