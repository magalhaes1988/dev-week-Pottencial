using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev_week_Pottencial.src.Models
{
    public class Contracts
    {

        public Contracts()
        {
            this.DataCriacao = DateTime.Now;
            this.Valor = 0;
            this.TokenId = "0000";
        }

        public Contracts(string tokenId, double valor)
        {
            this.DataCriacao = DateTime.Now;
            this.Valor = valor;
            this.TokenId = tokenId;
        }

        private DateTime _datacriacao;

        private string _tokenId;


        private double _valor;
        


        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        

        public string TokenId
        {
            get { return _tokenId; }
            set { _tokenId = value; }
        }
        
        public DateTime DataCriacao
        {
            get { return _datacriacao; }
            set { _datacriacao = value; }
        }
        
    }
}